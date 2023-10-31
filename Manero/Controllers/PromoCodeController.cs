using Manero.Repository.PromoCodeRepo;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Manero.Controllers
{
    public class PromoCodeController : Controller
    {
        private readonly GetUserPromoCodeRepo _repo;

        public PromoCodeController(GetUserPromoCodeRepo repo)
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
    }
}