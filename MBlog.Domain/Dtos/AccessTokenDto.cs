using System;
using System.Collections.Generic;
using System.Text;

namespace MBlog.Domain.Dtos
{
	public class AccessTokenDto
	{
		public string RefeshToken { get; set; }
		public string AccessToken { get; set; }
	}
}
