using MBlog.DataAccess.Contexts;
using MBlog.Domain.Dtos;
using MBlog.Domain.Entities;
using MBlog.Domain.Helpers;
using MBlog.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBlog.DataAccess.Repositoies
{
	public class UserRepository : IUserRepository
	{
		private readonly MBlogContext _context;
		public UserRepository(MBlogContext context)
		{
			_context = context;
		}
		public string AddUser(string email, string password, string salt)
		{
			try
			{
				User user = new User()
				{
					UserName = email,
					ActiveStatus = Enums.Status.InActive,
					IsDelete = false,
					CreateTime = DateTime.Now,
					Password = password,
					Salt = salt
				};
				_context.Users.Add(user);
				_context.SaveChanges();
				return "Success";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public bool CheckUserByUserName(string email)
		{
			var result= _context.Users.SingleOrDefault(x => x.UserName == email);
			if (result == null)
			{
				return false;
             }
			else
			{
				return true;
             }
		}


		public User GetUserByEmail(string email)
		{
			var result = _context.Users.SingleOrDefault(x => x.UserName == email);
			if (result == null)
			{
				return null;
			}
			else
			{
				return result;
			}
		}

		public string SoftDelete(string email)
		{
			var result = _context.Users.SingleOrDefault(x => x.UserName == email);
			if (result == null)
			{
				return "no account user";
			}
			else
			{
				result.IsDelete = true;
				_context.SaveChanges();
				return "Success";
			}
		}

		public string UpdateActiveStatus(string email)
		{
			var result = _context.Users.SingleOrDefault(x => x.UserName == email);
			if (result == null)
			{
				return "no account user";
			}
			else
			{
				result.ActiveStatus=Enums.Status.InActive;
				_context.SaveChanges();
				return "Success";
			}
		}

		public string UpdateUser(string email, string password, string salt)
		{
			var result = _context.Users.SingleOrDefault(x => x.UserName == email);
			if (result == null)
			{
				return "no account user";
			}
			else
			{
				result.Password = password;
				result.Salt = salt;
				result.ActiveStatus = Enums.Status.Active;
				_context.SaveChanges();
				return "Success";
			}
		}
	}
		
}
