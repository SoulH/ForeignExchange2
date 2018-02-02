using ForeignExchange.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForeignExchange.Services
{
    public class DialogService
    {
        public static async Task ShowMessage(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, Languajes.Accept);
        }

        public static async Task<bool> ShowConfirm(string title, string message)
        {
            return await App.Current.MainPage.DisplayAlert(title, message, "Sí", "No");
        }
    }

}
