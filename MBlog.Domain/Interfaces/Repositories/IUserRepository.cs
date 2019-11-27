using MBlog.Domain.Dtos;
using MBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBlog.Domain.Interfaces.Repositories
{
	public interface IUserRepository
	{
		//Update 
	//	string SoftDelete(string userName);		
		//เช็ค Account โดย Username มีหรือไม่มี
	//	bool CheckUserByUserName(string userName);
		//เพิ่ม Record UserAccount ใช้ email,password=Hash(password+salt(Random)),salt(Random)
		string AddUser(string email, string password, string salt);
		//ดึง Salt โดย Username 
		//string GetSaltByUser(string userName);
		//Update For Forgotpassword
		string UpdateUser(string email, string password, string salt);
		//ดึง Salt และ Password โดย Username เพื่อ Check
		User GetUserByEmail(string email);
		//Update ActiveStatus to false
		string UpdateActiveStatus(string email);
	}
}
