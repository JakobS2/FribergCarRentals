using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;
using Microsoft.IdentityModel.Tokens;

namespace FribergCarRentals.Pages.Car
{
    public class EditModel : PageModel
    {
        private readonly ICar carRep;

        public EditModel(ICar carRep)
        {
            this.carRep = carRep;
        }

        [BindProperty]
        public Model.Car Car { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var admin = HttpContext.Session.GetString("IsAdmin");
            if (admin.IsNullOrEmpty())
            {
                return RedirectToPage("./Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            var car =  carRep.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            carRep.EditCar(Car);
            carRep.Save();

            return RedirectToPage("./Index");
        }

    }
}
