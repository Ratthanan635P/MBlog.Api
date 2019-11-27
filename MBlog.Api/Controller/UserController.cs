using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBlog.Api.Models;
using MBlog.Api.Services;
using MBlog.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MBlog.Api.Controller
{

	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public IActionResult Authenticate([FromBody]AuthenticateModel model)
		{
			string status = "";
			try
			{
				var user = _userService.LogInUser(model.Username, model.Password);				
				if (user.ErrorMessage != "PASS")
					return BadRequest(new { message = status });

				return Ok(user);
			}
			catch (Exception ex)
			{
				status = ex.Message;
			}
			return BadRequest(new { message = status });
		}

		//[HttpGet]
		//public IActionResult GetAll()
		//{
		//	var users = _userService.GetAll();
		//	return Ok(users);
		//}
	}

}