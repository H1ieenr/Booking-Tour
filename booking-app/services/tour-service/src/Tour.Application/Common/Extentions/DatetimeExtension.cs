
namespace Application.Common
{
    public static class DatetimeExtension
    {
        public static DateTime ConvertDatetimeVN()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo vietnamZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamZone);
            return vietnamTime;
        }
    }
}