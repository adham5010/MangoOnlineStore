using AutoMapper;
using Mango.Services.CouponApi.Models;
using Mango.Services.CouponApi.Models.Dtos;

namespace Mango.Services.CouponApi.Configurations.Mapping
{
    public class MappingConfigurations
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(
                config =>
                {
                    config.CreateMap<Coupon, CouponDto>();
                    config.CreateMap<CouponDto, Coupon>();
                });
        }
    }
}
