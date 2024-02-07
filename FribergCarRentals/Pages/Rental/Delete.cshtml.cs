using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;

namespace FribergCarRentals.Pages.Rental
{
    public class DeleteModel : PageModel
    {
        private readonly IRental rentalRep;

        public DeleteModel(IRental rentalRep)
        {
            this.rentalRep = rentalRep;
        }

        [BindProperty]
        public Model.Rental Rental { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = rentalRep.GetById(id);

            if (rental == null)
            {
                return NotFound();
            }
            else
            {
                Rental = rental;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            rentalRep.DeleteRental(id);
            rentalRep.Save();

            return RedirectToPage("./Index");
        }
    }
}
