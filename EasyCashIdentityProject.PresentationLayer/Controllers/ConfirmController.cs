using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
	public class ConfirmController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ConfirmController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
		//	ConfirmMailViewModel confirmMailViewModel = new ConfirmMailViewModel();
			var value = TempData["Mail"];
			ViewBag.v = value;
			//confirmMailViewModel.Mail = value.ToString();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
		{
			var value = TempData["Mail"];
			var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
			if(user.ConfirmCode == confirmMailViewModel.ConfirmCode)
			{
				user.EmailConfirmed = true;
				await _userManager.UpdateAsync(user);
				return RedirectToAction("Index", "Login");
			}
			return View();
		}
	}
}
