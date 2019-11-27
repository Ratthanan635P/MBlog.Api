using MBlog.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBlog.Domain.Interfaces.Services
{
	 public interface IUserService
	{
		UserDto LogInUser(string email, string password);
		bool UpdateUser(string email, string password);
		string ForgotPassword(string email);
		string RegisterUser(string email, string password);
	}
}
