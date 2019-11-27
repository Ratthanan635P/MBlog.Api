using MBlog.Domain.Dtos;
using MBlog.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBlog.DataAccess.Repositoies
{
	public class UserRepository : IUserRepository
	{
		public string AddUser(string userName, string password, string salt)
		{
			throw new NotImplementedException();
		}

		public TokenAccess GetTokenAccess(string userName, string password, string salt)
		{
			throw new NotImplementedException();
		}

		public UserDto GetUserByUserName(string userName)
		{
			throw new NotImplementedException();
		}

		public string SoftDelete(string userName)
		{
			throw new NotImplementedException();
		}
	}
}
