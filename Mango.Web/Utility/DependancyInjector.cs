namespace Mango.Web.Utility
{
    using Mango.Web.Services;
    using Mango.Web.Services.IService;
    public static class DependancyInjector
    {
        public static void LoadDependancies(IServiceCollection collction)
        {
            collction.AddHttpClient<ICouponService, CouponService>();
            collction.AddScoped<ICouponService, CouponService>();
            collction.AddScoped<IBaseService, BaseService>();
        }
    }
}
