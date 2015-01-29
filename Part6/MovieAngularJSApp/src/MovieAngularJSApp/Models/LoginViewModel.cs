using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAngularJSApp.Models
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "User name")]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }
	}
}