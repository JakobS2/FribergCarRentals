using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentals.Data;
using Microsoft.IdentityModel.Tokens;

namespace FribergCarRentals.Pages.Rental
{
	public class CreateModel : PageModel
	{
		private readonly IRental rentalRep;
		private readonly ICar carRep;
		private readonly IUser userRep;

		public CreateModel(IRental rentalRep, ICar carRep, IUser userRep)
		{
			this.rentalRep = rentalRep;
			this.carRep = carRep;
			this.userRep = userRep;
		}

		[BindProperty]
		public Model.Rental rental { get; set; } = default!;

		public IActionResult OnGet(int id)
		{
			if (HttpContext.Session.GetInt32("tempCar") == null)
			{
				HttpContext.Session.SetInt32("tempCar", id);
			}

			var currentUser = HttpContext.Session.GetString("User");
			if (currentUser.IsNullOrEmpty())
			{
				return RedirectToPage("../User/Login");
			}

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

			var CarId = HttpContext.Session.GetInt32("tempCar");
			var UserId = Convert.ToInt32(HttpContext.Session.GetString("User"));
			Model.User user = userRep.GetById(UserId);
			if (CarId == null)
			{
				Model.Rental userTemp = new Model.Rental() { UserId = UserId, CarId = id };
				rental = userTemp;
			}
			else
			{
				Model.Rental userTemp = new Model.Rental() { UserId = UserId, CarId = (int)CarId };
				rental = userTemp;
			}
			HttpContext.Session.Remove("tempCar");


			return Page();
		}


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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



			if (rental.StartDate < DateTime.Now)
			{
				ModelState.AddModelError("ErrorStartDate", "Date cannot be before current time");
				return Page();
			}
			else if (rental.EndDate < rental.StartDate)
			{
				ModelState.AddModelError("ErrorEndDate", "Date cannot be before start date");
				return Page();
			}

			rentalRep.AddRental(rental);
			rentalRep.Save();

			HttpContext.Session.SetInt32("tempId", rental.RentalId);

			return RedirectToPage("./RentalConfirmation");
		}
	}
}
