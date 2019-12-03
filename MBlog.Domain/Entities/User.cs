using MBlog.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBlog.Domain.Entities
{
	public class User:BaseEntity
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public string RefeshToken { get; set; }
		public string AccessToken { get; set; }
		public Enums.Status ActiveStatus { get; set; }
		public Enums.Roles Role { get; set; }
	}
}
