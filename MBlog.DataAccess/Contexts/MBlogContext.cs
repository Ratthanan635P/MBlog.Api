using MBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MBlog.DataAccess.Contexts
{
	public class MBlogContext:DbContext
	{
		public DbSet<User> Users { get; set; }
		private static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(config=>config.AddConsole());
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLoggerFactory(loggerFactory).UseSqlServer("Server=localhost;Database=MBlogDB;Trusted_Connection=True;Integrated Security = false;User Id =sa;Password=yourStrong(!)Password");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());				
		}
	}
}
