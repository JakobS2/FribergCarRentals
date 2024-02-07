using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;

namespace FribergCarRentals.Pages.Rental
{
    public class RentalConfirmationModel : PageModel
    {
        private readonly IRental rentalRep;

        public RentalConfirmationModel(IRental rentalRep)
        {
			this.rentalRep = rentalRep;
		}

        public Model.Rental Rental { get; set; } = default!;

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("tempId") == null)
            {
                 return RedirectToPage("/Car/Index");
            }

            var rental = rentalRep.GetById((int)HttpContext.Session.GetInt32("tempId"));
            Rental = rental;
            HttpContext.Session.Remove("tempId");
            return Page();
        }
    }
}
