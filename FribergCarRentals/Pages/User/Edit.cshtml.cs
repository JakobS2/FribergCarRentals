using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;

namespace FribergCarRentals.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly IUser userRep;

        public EditModel(IUser userRep)
        {
            this.userRep = userRep;
        }

        [BindProperty]
        public Model.User User { get; set; } = default!;

        public IActionResult OnGet(int id)
        {

            var user = userRep.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
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

            userRep.EditUser(User);
            userRep.Save();

            return RedirectToPage("./Index");
        }
    }
}
