
using MBlog.Api.Entities;
using MBlog.Api.Helpers;
using MBlog.Domain.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MBlog.Api.Services
{
	public interface IUserDataServices
	{
		UserData Authenticate(string username, string password);
		IEnumerable<UserData> GetAll();
	}
	public class UserDataServices : IUserDataServices
	{
		// users hardcoded for simplicity, store in a db with hashed passwords in production applications
		private List<UserData> _users = new List<UserData>
		{
			new UserData { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
		};

		private readonly AppSettings _appSettings;

		public UserDataServices(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
		}

		public UserData Authenticate(string username, string password)
		{
			var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

			// return null if user not found
			if (user == null)
				return null;

			// authentication successful so generate jwt token
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			user.Token = tokenHandler.WriteToken(token);
			
			return user.WithoutPassword();
		}
	//	public RefreshToken GenerateRefreshToken(User user)
	//	{
	//		// Create the refresh token
	//		RefreshToken refreshToken = new RefreshToken()
	//		{
	//			Token = GenerateRefreshToken(),
	//			Expiration = DateTime.UtcNow.AddMinutes(35) // Make this configurable
	//		};

	//// Add it to the list of of refresh tokens for the user
	//		user.RefreshTokens.Add(refreshToken);

	//		// Update the user along with the new refresh token
	//		UserRepository.Update(user);

	//		return refreshToken;
	//	}

		//public string GenerateRefreshToken()
		//{
		//	var randomNumber = new byte[32];
		//	using (var rng = RandomNumberGenerator.Create())
		//	{
		//		rng.GetBytes(randomNumber);
		//		return Convert.ToBase64String(randomNumber);
		//	}
		//}
		public IEnumerable<UserData> GetAll()
		{
			return _users.WithoutPasswords();
		}
	}
}
