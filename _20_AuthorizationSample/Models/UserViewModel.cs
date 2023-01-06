using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationSample.Models;

public class UserViewModel
{
	[Required]
	public string UserName { get; set; }

	[Required]
	public string Password { get; set; }
}