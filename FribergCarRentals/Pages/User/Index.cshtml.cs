using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentals.Data;
using Microsoft.IdentityModel.Tokens;

namespace FribergCarRentals.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly IUser userRep;

        public IndexModel(IUser userRep)
        {
            this.userRep = userRep;
        }

        public IList<Model.User> User { get;set; } = default!;

        public IActionResult OnGet()
        {
            var admin = HttpContext.Session.GetString("IsAdmin");
            if (admin.IsNullOrEmpty())
            {
                return RedirectToPage("/Car/Index");
            }
            User = userRep.GetAll();
            return Page();
        }
    }
}
