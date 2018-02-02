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
    }
}
