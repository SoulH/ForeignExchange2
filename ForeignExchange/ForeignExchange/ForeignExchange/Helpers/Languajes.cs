using ForeignExchange.Interfaces;
using ForeignExchange.Resources;
using Xamarin.Forms;

namespace ForeignExchange.Helpers
{
    public static class Languajes
    {
        static Languajes()
        {
            var ci = DependencyService.Get<ILocalizePlatform>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalizePlatform>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }

        public static string AmountValidation
        {
            get { return Resource.AmountValidation; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string Title
        {
            get { return Resource.Title; }
        }

        public static string LblAmount
        {
            get { return Resource.LblAmount; }
        }

        public static string MsgLoadingRates { get { return Resource.MsgLodingRates; } }

        public static string MsgReady { get { return Resource.MsgReady; } }

        public static string MsgStatusNoLocalData { get { return Resource.MsgStatusNoLocalData; } }

        public static string MsgStatusLocalLoad { get { return Resource.MsgStatusLocalLoad; } }

        public static string MsgStatusLoaded { get { return Resource.MsgStatusLoaded; } }
    }
}
