using System;
using System.Collections.Generic;
using System.Text;

namespace MBlog.Domain.Dtos
{
	public class UserDto
	{
		public int Id { get; set; }
		public string ErrorMessage { get; set; }
		public string AccessToken { get; set; }
	}
}
