using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;
using Microsoft.IdentityModel.Tokens;

namespace FribergCarRentals.Pages.Rental
{
    public class IndexModel : PageModel
    {
        private readonly IRental rentalRep;

        public IndexModel(IRental rentalRep)
        {
            this.rentalRep = rentalRep;
        }

        public IList<Model.Rental> Rental { get;set; } = default!;

        public IActionResult OnGet()
        {
			var currentUser = HttpContext.Session.GetString("User");
			if (currentUser.IsNullOrEmpty())
			{
				return RedirectToPage("../User/Login");
			}

			var admin = HttpContext.Session.GetString("IsAdmin");
            if (admin.IsNullOrEmpty())
            {
                int CurrentUserId = Convert.ToInt32(HttpContext.Session.GetString("User"));
                Rental = rentalRep.GetAllByUserId(CurrentUserId);
                return Page();
            }
            Rental = rentalRep.GetAll();
            return Page();
        }
    }
}
