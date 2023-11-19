using Manero.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Manero.Controllers
{
    public class PromoCodeController : Controller
	{
        private readonly IPromoCodeRepo _repo;

        public PromoCodeController(IPromoCodeRepo repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> PromoCodesCurrent()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return RedirectToAction("Index", "Login");
			}
			var promocode = await _repo.GetUserPromocodesAsync(userId);
			if (!promocode.Any())
			{
				return RedirectToAction("PromoCodeEmpty", "PromoCode");
			}
			return View(promocode);
		}


		public IActionResult PromoCodesUsed()
		{
			return View();
		}

		public IActionResult PromoCodeEmpty()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddPromoCodeToUser(string promoCodeTitle)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			bool result = await _repo.AssignPromoCodeToUserAsync(userId, promoCodeTitle);

			if (!result)
			{
				ViewData["ErrorMessage"] = "Invalid or duplicate promo code.";
				return View("PromoCodeEmpty", "PromoCode");
			}
			else
			{
				return RedirectToAction("PromoCodesCurrent", "PromoCode");
			}

		}
	}
}