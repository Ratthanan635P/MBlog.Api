using MBlog.Domain.Dtos;
using MBlog.Domain.Entities;
using MBlog.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MBlog.Domain.Services
{
	public class UserService : IUserService
	{
		//// users hardcoded for simplicity, store in a db with hashed passwords in production applications
		//private List<UserData> _users = new List<UserData>
		//{
		//	new UserData { Id = 1, UserName = "Test", Salt = "User", Password = "test" }
		//};

		//private readonly AppSettings _appSettings;

		//public UserService(IOptions<AppSettings> appSettings)
		//{
		//	_appSettings = appSettings.Value;
		//}

		//public User Authenticate(string username, string password)
		//{
		//	var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);

		//	// return null if user not found
		//	if (user == null)
		//		return null;

		//	// authentication successful so generate jwt token
		//	var tokenHandler = new JwtSecurityTokenHandler();
		//	var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
		//	var tokenDescriptor = new SecurityTokenDescriptor
		//	{
		//		Subject = new ClaimsIdentity(new Claim[]
		//		{
		//			new Claim(ClaimTypes.Name, user.Id.ToString())
		//		}),
		//		Expires = DateTime.UtcNow.AddDays(7),
		//		SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		//	};
		//	var token = tokenHandler.CreateToken(tokenDescriptor);
		//	user.AccessToken = tokenHandler.WriteToken(token);

		//	return user.WithoutPassword();
		//}

		//public IEnumerable<User> GetAll()
		//{
		//	return _users.WithoutPasswords();
		//}
	}
}
