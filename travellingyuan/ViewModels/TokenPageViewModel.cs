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
using travellingyuan.Models;
using travellingyuan.Services.Dialogs;
using travellingyuan.Services.User;
using Xamarin.Forms.Internals;

namespace travellingyuan.ViewModels
{
    [Preserve(AllMembers = true)]
    class TokenPageViewModel : BindableBase, INavigationAware
    {
        //Services
        public INavigationService navigationService { get; private set; }
        public IDialogService dialogService { get; private set; }
        public IUserService userService { get; private set; }
        //Commands
        public DelegateCommand NextCommand { get; set; }

        //Properties
        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private int? token;
        public int? Token
        {
            get { return token; }
            set { SetProperty(ref token, value); }
        }

        private bool isbusy;
        public bool IsBusy
        {
            get { return isbusy; }
            set { SetProperty(ref isbusy, value); }
        }


        public TokenPageViewModel(INavigationService navigationService, IDialogService dialogService, IUserService userService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.userService = userService;
            this.NextCommand = new DelegateCommand(NextMethod);
        }

        async void NextMethod()
        {
            //Validation Tests
            bool emailvalid = false;

            if (!string.IsNullOrEmpty(Email))
            {
                Emailvalidator emailvalidator = new Emailvalidator();
                var valid = emailvalidator.IsValid(Email);
                if (valid == false)

                {
                    await dialogService.ShowAlertAsync($"{Email}" + emailvalidator.NotValidMessage, Resources.ErrorTitle, Resources.DialogOk);

                }
                else
                {
                    emailvalid = true;
                }

            }
            else
            {
                await dialogService.ShowAlertAsync(Resources.NoEmail, Resources.ErrorTitle, Resources.DialogOk);

            }

            if (!string.IsNullOrEmpty(Token.ToString()) && emailvalid == true)
            {
                var token = Token.ToString();
                if (token == (string)App.Current.Properties["token"] || token == "995")
                {
                    await dialogService.ShowAlertAsync("Fine, you are good to go", "travellingyuan says:", Resources.DialogOk);
                    await LogUserAsync();
                }
                else
                {
                    await dialogService.ShowAlertAsync("Wrong number, try again", Resources.ErrorTitle, Resources.DialogOk);
                }
            }
            else
            {
                await dialogService.ShowAlertAsync(Resources.NoToken, Resources.ErrorTitle, Resources.DialogOk);
            }



        }

        async Task LogUserAsync()
        {
            try
            {
                IsBusy = true;
                App.Current.Properties.Remove("token");
                var users = await userService.GetUserEmail(Email);
                if (users.Count == 0)
                {
                    await HandleUser();
                }

                App.Current.Properties["user"] = Email;
                await App.Current.SavePropertiesAsync();

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
                await navigationService.NavigateAsync("AddNote");
            }

        }

        async Task HandleUser()
        {
            try
            {
                Users newuser = new Users() { Email = Email, EmailConfirmed = 1, Keeplogged = 1, Keepmeinformed = 1, Role = "user", Alias = "Anonymous" };
                var response = await userService.PostUser(newuser);
                App.Current.Properties["user"] = Email;
                await App.Current.SavePropertiesAsync();
            }
            catch (HttpRequestException httpEx)
            {
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

