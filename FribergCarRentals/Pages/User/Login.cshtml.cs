using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;

namespace FribergCarRentals.Pages.User
{
	public class LoginModel : PageModel
	{
		private readonly IUser userRep;

		public LoginModel(IUser userRep)
		{
			this.userRep = userRep;
		}
		[BindProperty]
		public Model.User User { get; set; } = default!;
		public IActionResult OnGet()
		{
			if (!String.IsNullOrEmpty(HttpContext.Session.GetString("User")))
			{
				HttpContext.Session.SetString("IsAdmin", "");
				HttpContext.Session.SetString("User", "");

				return RedirectToPage("./Index");
			}
			return Page();
		}

		//[BindProperty]
		//public User User { get; set; } = default!;

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public IActionResult OnPost(Model.User user)
		{
			
			Model.User currentUser = userRep.GetByEmail(user.Email);
			if (currentUser == null)
			{
                ModelState.AddModelError("ErrorEmail", "User with this Email does not exsist");
                return Page();
			}
			else
			{
				if (currentUser.Password == user.Password)
				{
					HttpContext.Session.SetString("User", currentUser.UserId.ToString());
					if (currentUser.IsAdmin)
					{
						HttpContext.Session.SetString("IsAdmin", "IsAdmin");
					}
				}
				else
				{
                    ModelState.AddModelError("ErrorPassword", "Incorrect password");
                    return Page();				
				}
			}
			var car = HttpContext.Session.GetInt32("tempCar");
			if (car == null)
			{
				return RedirectToPage("/Car/Index");

			}
			return RedirectToPage("/Rental/Create");
		}
	}
}
