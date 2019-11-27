using MBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBlog.DataAccess.Configuretions
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(x => x.UserName).HasMaxLength(100);
			builder.Property(x => x.Password).HasMaxLength(100);
			builder.Property(x => x.Salt).HasMaxLength(100);
			builder.Property(x => x.RefeshToken).HasMaxLength(100);
			builder.Property(x => x.AccessToken).HasMaxLength(100);
		}
	}
}
