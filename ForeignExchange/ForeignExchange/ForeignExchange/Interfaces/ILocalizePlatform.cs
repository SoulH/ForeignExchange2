using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ForeignExchange.Interfaces
{
    public interface ILocalizePlatform
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}
