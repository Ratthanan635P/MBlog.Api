using MBlog.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBlog.Domain.Interfaces.Repositories
{
	public interface IUserRepository
	{
		string AddUser(string userName, string password, string salt);
		string SoftDelete(string userName);
		UserDto GetUserByUserName(string userName);
		TokenAccess GetTokenAccess(string userName, string password, string salt);
	}
}
