using Mango.Web.Models;
using Mango.Web.Services.IService;
using System.Collections.Generic;

namespace Mango.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            this._baseService = baseService;
        }

        public async Task<ResponseDto<CouponDto>> CreateCouponeAsync(CouponDto coupon)
        {
            return await _baseService.SendAsync<CouponDto>(new RequestDto
            {
                ApiType = Utility.SD.ApiType.POST,
                URL = $"{Utility.SD.CouponAbiBaseurl}/api/Coupons",
                Data = coupon
            });
        }

        public async Task<ResponseDto<CouponDto>> DeleteCouponeAsync(int Id)
        {
            return await this._baseService.SendAsync<CouponDto>(new RequestDto
            {
                ApiType = Utility.SD.ApiType.DELETE,
                URL = Utility.SD.CouponAbiBaseurl + $"/api/Coupons/{Id}",
            });
        }

        public async Task<ResponseDto<IEnumerable<CouponDto>>> getAllCouponesAsync()
        {
            return await this._baseService.SendAsync<IEnumerable<CouponDto>>(new RequestDto
            {
                ApiType = Utility.SD.ApiType.GET,
                URL = Utility.SD.CouponAbiBaseurl + $"/api/Coupons/",
            });
        }

        public async Task<ResponseDto<CouponDto>> getCouponeByCodeAsync(string code)
        {
            return await this._baseService.SendAsync<CouponDto>(new RequestDto
            {
                ApiType = Utility.SD.ApiType.GET,
                URL = Utility.SD.CouponAbiBaseurl + $"/api/Coupons/getByCode/${code}",
            });
        }

        public async Task<ResponseDto<CouponDto>> getCouponeByIdAsync(int Id)
        {
            return await this._baseService.SendAsync<CouponDto>(new RequestDto
            {
                ApiType = Utility.SD.ApiType.GET,
                URL = Utility.SD.CouponAbiBaseurl + $"/api/Coupons/${Id}",
            });
        }

        public async Task<ResponseDto<CouponDto>> UpdateCouponeAsync(CouponDto coupon)
        {
            return await _baseService.SendAsync<CouponDto>(new RequestDto
            {
                ApiType = Utility.SD.ApiType.PUT,
                URL = $"{Utility.SD.CouponAbiBaseurl}/api/Coupons",
                Data = coupon
            });
        }
    }
}
