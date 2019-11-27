using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MBlog.Api.Helpers
{
	public class ValidateMethods
	{
		public int LengthEmail { get; private set; }
		public int LengthPassword { get; private set; }
		public int LengthMax { get; private set; }

		public ValidateMethods()
		{
			LengthEmail = 4;
			LengthPassword = 6;
			LengthMax = 50;
		}
		public bool CheckRegEx_UserName(string username)
		{
			//var patterns = @"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{"+App.LengthEmail+","+App.LengthMax + "}$";
			var patterns = @"^(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{4,50}$";
			//var patterns = @"^(?=.*[A - Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{"+App.LengthEmail.ToString()+","+App.LengthMax.ToString() + "}$";
			Regex rx = new Regex(patterns, RegexOptions.IgnoreCase);
			username = username.ToUpper();
			bool isCheck = rx.IsMatch(username);
			return isCheck;
		}
		public bool CheckRegEx_Password(string password)
		{
			//var patterns= @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{" + App.LengthPassword + "," + App.LengthMax + "})";
			var patterns = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,50})";
			Regex rx = new Regex(patterns, RegexOptions.IgnoreCase);
			//password = password;
			return rx.IsMatch(password);
		}
	}
}
