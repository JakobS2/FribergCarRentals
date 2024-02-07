using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;
using Microsoft.IdentityModel.Tokens;

namespace FribergCarRentals.Pages.Car
{
    public class CreateModel : PageModel
    {
        private readonly ICar carRep;

        public CreateModel(ICar carRep)
        {
            this.carRep = carRep;
        }

        public IActionResult OnGet()
        {
            var admin = HttpContext.Session.GetString("IsAdmin");
            if (admin.IsNullOrEmpty())
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        [BindProperty]
        public Model.Car Car { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            carRep.AddCar(Car);
            carRep.Save();

            return RedirectToPage("./Index");
        }
    }
}
