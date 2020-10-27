using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using travellingyuan.Exceptions;
using travellingyuan.Helper;
using travellingyuan.Services.Dialogs;
using travellingyuan.Services.SMS;
using Xamarin.Forms.Internals;

namespace travellingyuan.ViewModels
{
    [Preserve(AllMembers = true)]
    public class PhoneNumberPageViewModel : BindableBase, INavigationAware
    {
        //Services
        public INavigationService navigationService { get; private set; }
        public IDialogService dialogService { get; private set; }
        public ISmsService smsService { get; private set; }

        //Commands
        public DelegateCommand SendSMSCommand { get; set; }

        //Properties
        private string phonenumber;
        public string PhoneNumber
        {
            get { return phonenumber; }
            set { SetProperty(ref phonenumber, value); }
        }

        private bool isbusy;
        public bool IsBusy
        {
            get { return isbusy; }
            set { SetProperty(ref isbusy, value); }
        }


        public PhoneNumberPageViewModel(INavigationService navigationService, IDialogService dialogService, ISmsService smsService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.smsService = smsService;
            SendSMSCommand = new DelegateCommand(async () => await SendSMSMethod());
        }

        async Task SendSMSMethod()
        {
            if (String.IsNullOrEmpty(PhoneNumber))
            {
                await dialogService.ShowAlertAsync(Resources.NoPhone, Resources.ErrorTitle, Resources.DialogOk);
            }

            PhoneValidator phonevalidator = new PhoneValidator();

            var valid = phonevalidator.IsValid(PhoneNumber);
            if (valid == false)

            {
                await dialogService.ShowAlertAsync(PhoneNumber, phonevalidator.NotValidMessage, Resources.DialogOk);
            }


            await SendSMSAsync();
        }

        async Task SendSMSAsync()
        {
            try
            {
                IsBusy = true;
                var response = await smsService.SendSMSAsync(PhoneNumber);
                if (!response.Equals(Resources.TwillioError))
                {
                    var param = new NavigationParameters();
                    await navigationService.NavigateAsync("TokenPage",param,true,true);
                }

            }
            catch (HttpRequestException httpEx)
            {

                Debug.WriteLine($"[Booking Where Step] Error retrieving data: {httpEx}");

                if (!string.IsNullOrEmpty(httpEx.Message))
                {
                    await dialogService.ShowAlertAsync(
                        string.Format(Resources.HttpRequestExceptionMessage, httpEx.Message),
                        Resources.HttpRequestExceptionTitle,
                        Resources.DialogOk);
                }

            }
            catch (ConnectivityException cex)
            {

                Debug.WriteLine($"[Booking Where Step] Connectivity Error: {cex}");
                await dialogService.ShowAlertAsync("There is no Internet conection, try again later.", "Error", "Ok");

            }
            catch (Exception ex)
            {
                await dialogService.ShowAlertAsync(ex.Message, Resources.ErrorTitle, Resources.DialogOk);
            }

            finally
            {
                IsBusy = false;
            }
        }




        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

    }
}
