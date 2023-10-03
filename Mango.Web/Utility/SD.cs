namespace Mango.Web.Utility
{
    public static class SD
    {
        public static string CouponAbiBaseurl { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public static void setCouponApiUrl(ConfigurationManager configurations) {
            SD.CouponAbiBaseurl = configurations["ServiceUrls:CouponApiBaseUrl"];
        }
    }
}
