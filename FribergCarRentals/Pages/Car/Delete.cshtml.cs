using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;
using Microsoft.IdentityModel.Tokens;

namespace FribergCarRentals.Pages.Car
{
    public class DeleteModel : PageModel
    {
        private readonly ICar carRep;

        public DeleteModel(ICar carRep)
        {
            this.carRep = carRep;
        }

        [BindProperty]
        public Model.Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
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

            var car = carRep.GetById(id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            carRep.DeleteCar(id);
            carRep.Save();

            return RedirectToPage("./Index");
        }
    }
}
