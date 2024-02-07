using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;

namespace FribergCarRentals.Pages.Car
{
    public class IndexModel : PageModel
    {
        private readonly ICar carRep;

        public IndexModel(ICar carRep)
        {
            this.carRep = carRep;
        }

        public IList<Model.Car> Car { get;set; } = default!;

        public IActionResult OnGet()
        {
            Car = carRep.GetAll();
            return Page();
        }
    }
}
