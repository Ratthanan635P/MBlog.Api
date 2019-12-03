
using MBlog.Domain.Dtos;
using MBlog.Domain.Entities;
using MBlog.Domain.Helpers;
using MBlog.Domain.Interfaces.Repositories;
using MBlog.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MBlog.Domain.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private static Random random = new Random();
		private readonly AppSettings _appSettings;

		public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
		{
			_userRepository = userRepository;
			_appSettings = appSettings.Value;
		}
		public string ForgotPassword(string email)
		{
			//string status = "";
			var user = _userRepository.GetUserByEmail(email);
			if (user != null)
			{
				string newpassword = RandomPassword();
				string newSalt = RandomCode();
				string hashPassword = HashSHA256(newpassword + newSalt);
				var result = _userRepository.UpdateUser(email, hashPassword, newSalt);
				if (result == "Success")
				{
					//senddata();
					return result;// newpassword;
				}
				else
				{
					return "Update password fail";
				}
			}
			else
			{
				return "No AccountEmail";
			}


		}
			
		public UserDto LogInUser(string email, string password)
		{
			string status="";
			UserDto User = new UserDto();
			var result = _userRepository.GetUserByEmail(email);
			if (result != null)
			{
				if (result.ActiveStatus == Enums.Status.InActive)
				{
					if (CheckUser(result, password))
					{
						status = "PASS";
					}
					else
					{
						status = "Password is wrong!";
					}
				}
				else
				{
					status = "Account is Active!";
				}
			}
			else
			{
				status = "No AccountEmail";
			}
			User.ErrorMessage = status;
			User.Id = result.Id;
			User.AccessToken = Authenticate(result);

			//	เช็ค user มีหรือไหม
			//string AddUser(string email, string password, string salt);
			////ดึง Salt โดย Username 
			////string GetSaltByUser(string userName);
			////Update For Forgotpassword
			//string UpdateUser(string email, string password, string salt);
			////ดึง Salt และ Password โดย Username เพื่อ Check
			//User GetUserByEmail(string email);
			return User;
		}

		public string RegisterUser(string email, string password)
		{
			var data = _userRepository.GetUserByEmail(email);
			if (data != null)
			{
				return "Email is exist!";
			}
			else
			{
				string newSalt = RandomCode();
				string newPassword = HashSHA256(password + newSalt);
				var result = _userRepository.AddUser(email, newPassword, newSalt);
				return result;
			}
			//throw new NotImplementedException();
		}
		private bool CheckUser(User user, string password)
		{
			string currentPassword = HashSHA256(password + user.Salt);
			return (user.Password == currentPassword) ? true : false;
		}
		private string HashSHA256(string psw)
		{
			SHA256 sHA256hash = SHA256.Create();
			byte[] bytes = sHA256hash.ComputeHash(Encoding.UTF8.GetBytes(psw));
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < bytes.Length; i++)
			{
				builder.Append(bytes[i].ToString("x2"));
			}
			string hashPSW = builder.ToString();
			return hashPSW;
		}
		public string RandomCode()
		{
			const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, random.Next(20, 25))
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}
		public string RandomPassword()
		{
			const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, random.Next(8, 10))
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}
		public bool UpdateUser(string email, string password)
		{
			string newSalt = RandomCode();
			string hashPassword = HashSHA256(password + newSalt);
			var result = _userRepository.UpdateUser(email, hashPassword, newSalt);
			return (result == "Success") ? true : false;	
		}
		public string Authenticate(User user)
		{
			// authentication successful so generate jwt token
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes("JENG123456789101guhijoklsdfhgjklfsdgxfhcgj");
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString()),
					new Claim(ClaimTypes.Role, user.Role.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return  tokenHandler.WriteToken(token);			
		}
		private string createEmailBody(string userName, string message)
		{
			string body = string.Empty;
			//using (StreamReader reader = new StreamReader(HttpContext.MapPath("/htmlTemplate.html")))
			//{
			//	body = reader.ReadToEnd();
			//}
			body = body.Replace("{UserName}", userName);
			body = body.Replace("{message}", message);
			return body;
		}
		private async void senddata()
		{
			var message = new MailMessage();
			message.To.Add(new MailAddress("jenggig@gmail.com"));
			message.From = new MailAddress("Amit Mohanty <amitmohanty@email.com>");
			message.Bcc.Add(new MailAddress("Amit Mohanty <amitmohanty@email.com>"));
			message.Subject = "subject";
			message.Body = createEmailBody("testhfh","gghhhhhhdh");
			message.IsBodyHtml = true;
			using (var smtp = new SmtpClient())
			{
				await smtp.SendMailAsync(message);
				await Task.FromResult(0);
			}
		}
		public UserDto GetDataUser(string email)
		{
			var user = _userRepository.GetUserByEmail(email);
			if (user == null)
			{
				return null;
             }
			UserDto userDto = new UserDto()
			{ 
				Id =user.Id,
            };
			return userDto;
		}
	}
}
