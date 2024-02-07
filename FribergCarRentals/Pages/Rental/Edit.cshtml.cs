using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentals.Data;

namespace FribergCarRentals.Pages.Rental
{
    public class EditModel : PageModel
    {
        private readonly IRental rentalRep;
        private readonly ICar carRep;
        private readonly IUser userRep;


        public EditModel(IRental rentalRep, ICar carRep, IUser userRep)
        {
            this.rentalRep = rentalRep;
            this.carRep = carRep;
            this.userRep = userRep;
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
            Rental = rental;

            IEnumerable<SelectListItem> selectListCars = carRep.GetAll().Select(u => new SelectListItem
            {
                Text = $"{u.Make} {u.Model}, {u.Year}",
                Value = u.CarId.ToString()
            });


            ViewData["Cars"] = selectListCars;

            IEnumerable<SelectListItem> selectListUsers = userRep.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.UserId.ToString()
            });

            ViewData["Users"] = selectListUsers;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
			IEnumerable<SelectListItem> selectListCars = carRep.GetAll().Select(u => new SelectListItem
			{
				Text = $"{u.Make} {u.Model}, {u.Year}",
				Value = u.CarId.ToString()
			});

			ViewData["Cars"] = selectListCars;

			IEnumerable<SelectListItem> selectListUsers = userRep.GetAll().Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.UserId.ToString()
			});

			ViewData["Users"] = selectListUsers;

			if (Rental.StartDate < DateTime.Now)
			{
				ModelState.AddModelError("ErrorStartDate", "Date cannot be before current time");
				return Page();
			}
			else if (Rental.EndDate < Rental.StartDate)
			{
				ModelState.AddModelError("ErrorEndDate", "Date cannot be before start date");
				return Page();
			}

			rentalRep.EditRental(Rental);
            rentalRep.Save();

            return RedirectToPage("./Index");
        }

    }
}
