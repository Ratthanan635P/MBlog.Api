using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBlog.Api.Models;
using MBlog.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MBlog.Api.Controller
{

	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private IUserDataServices _userService;

		public UserController(IUserDataServices userService)
		{
			_userService = userService;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public IActionResult Authenticate([FromBody]AuthenticateModel model)
		{
			var user = _userService.Authenticate(model.Username, model.Password);

			if (user == null)
				return BadRequest(new { message = "Username or password is incorrect" });

			return Ok(user);
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var users = _userService.GetAll();
			return Ok(users);
		}
	}

}