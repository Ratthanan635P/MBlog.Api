using System;
using System.Collections.Generic;
using System.Text;

namespace MBlog.Domain.Entities
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime? UpdateTime { get; set; }
		public DateTime CreateTime { get; set; }
		public bool IsDelete { get; set; }
	}
}
