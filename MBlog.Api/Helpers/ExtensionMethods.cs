
using MBlog.Api.Entities;
using MBlog.Domain.Dtos;
using MBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBlog.Api.Helpers
{
	public static class ExtensionMethods
	{
		public static IEnumerable<UserData> WithoutPasswords(this IEnumerable<UserData> users)
		{
			return users.Select(x => x.WithoutPassword());
		}

		public static UserData WithoutPassword(this UserData user)
		{
			user.Password = null;
			return user;
		}
	}
}
