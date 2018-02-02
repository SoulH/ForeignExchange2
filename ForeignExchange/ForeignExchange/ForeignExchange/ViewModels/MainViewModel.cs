using ForeignExchange.Helpers;
using ForeignExchange.Models;
using ForeignExchange.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ForeignExchange.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Props
        ObservableCollection<Rate> rates;
        public ObservableCollection<Rate> Rates
        {
            get { return rates; }
            set { SetProperty(ref rates, value); }
        }

        string status;
        public string Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

        decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); Enable(); }
        }

        
        Rate sourceRate;
        public Rate SourceRate
        {
            get { return sourceRate; }
            set { SetProperty(ref sourceRate, value); Enable(); }
        }

        Rate targetRate;
        public Rate TargetRate
        {
            get { return targetRate; }
            set { SetProperty(ref targetRate, value); Enable(); }
        }

        bool isRunning;
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetProperty(ref isRunning, value); }
        }

        bool isEnabled;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }

        string result;
        public string Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }

        public bool NotIsRunning
        {
            get { return !isRunning; }
        }

        public bool NotIsEnabled
        {
            get { return !isEnabled; }
        }
        #endregion

        #region Commands
        public ICommand ConvertCommand { get; private set; }
        #endregion

        public MainViewModel()
        {
            ConvertCommand = new Command(() => Convert());
            
            LoadRates();
        }

        #region Methods
        private void Convert()
        {
            var con = amount * (decimal) targetRate.TaxRate / (decimal)sourceRate.TaxRate;
            Result = $"{amount} ({sourceRate.Code}) = {string.Format("{0:N4}",con)} ({targetRate.Code})";
        }

        private void Enable()
        {
            if ((amount > 0) && (targetRate != null) && (sourceRate != null) && (!IsRunning))
                IsEnabled = true;
            else
                IsEnabled = false;
        }

        private void LoadRates()
        {
            if (Rates != null) return;
            IsRunning = true;
            Result = Languajes.MsgLoadingRates;

            /*if (InternetService.CheckConnection().IsSuccess)
                LoadDataFromApi(); 
            else*/
                LoadLocalData();
        }

        private async void LoadLocalData()
        {
            Rates = new ObservableCollection<Rate>(await DataService.GetRates());
            IsRunning = false;
            Status = "Rates loaded from local data.";
            Result = Languajes.MsgReady;
        }

        private async void LoadDataFromApi()
        {
            var list = await ApiExchangeRatesService.GetRates();
            Rates = new ObservableCollection<Rate>(list);
            DataService.SetRates(list);
            IsRunning = false;
            Status = "Rates loaded from web service.";
            Result = Languajes.MsgReady;
        }
        #endregion
    }
}
