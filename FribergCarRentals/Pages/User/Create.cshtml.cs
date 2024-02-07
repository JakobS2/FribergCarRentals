using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;

namespace FribergCarRentals.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly IUser userRep;

        public CreateModel(IUser userRep)
        {
            this.userRep = userRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Model.User User { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            userRep.AddUser(User);
            userRep.Save();

            return RedirectToPage("/User/Login");
        }
    }
}
