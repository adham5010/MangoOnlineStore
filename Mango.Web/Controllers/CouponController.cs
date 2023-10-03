using Mango.Web.Models;
using Mango.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            this._couponService = couponService;
        }
        public async Task<IActionResult> Index()
        {
            List<CouponDto> list = new List<CouponDto>();
            ResponseDto<IEnumerable<CouponDto>> coupons = (await this._couponService.getAllCouponesAsync());
            if (coupons.IsSuccess || coupons.Resposne is not null) {
                list = coupons.Resposne.ToList();
            }
            
            return View(list);
        }
    }
}
