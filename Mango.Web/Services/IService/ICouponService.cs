using Mango.Web.Models;
using System.Collections.Generic;

namespace Mango.Web.Services.IService
{
    public interface ICouponService
    {
        public Task<ResponseDto<CouponDto>> getCouponeByCodeAsync(string code);
        public Task<ResponseDto<IEnumerable<CouponDto>>> getAllCouponesAsync();
        public Task<ResponseDto<CouponDto>> getCouponeByIdAsync(int Id);
        public Task<ResponseDto<CouponDto>> CreateCouponeAsync(CouponDto coupon);
        public Task<ResponseDto<CouponDto>> UpdateCouponeAsync(CouponDto coupon);
        public Task<ResponseDto<CouponDto>> DeleteCouponeAsync(int Id);
    }
}
