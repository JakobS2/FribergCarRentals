using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;

namespace FribergCarRentals.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly IUser userRep;

        public DeleteModel(IUser userRep)
        {
            this.userRep = userRep;
        }

        [BindProperty]
        public Model.User User { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = userRep.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            userRep.DeleteUser(id);
            userRep.Save();

            return RedirectToPage("./Index");
        }
    }
}
