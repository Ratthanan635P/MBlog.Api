using System;
using System.Collections.Generic;
using System.Text;

namespace MBlog.Domain.Dtos
{
	public class TokenAccess
	{
		public string RefeshToken { get; set; }
		public string AccessToken { get; set; }
	}
}
