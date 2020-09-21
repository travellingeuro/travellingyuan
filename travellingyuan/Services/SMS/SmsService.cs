using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using travellingyuan.Services.Dialogs;
using travellingyuan.Services.Request;

namespace travellingyuan.Services.SMS
{
    public class SmsService : ISmsService
    {
        readonly IRequestService requestService;
        readonly IDialogService dialogService;


        public SmsService(IRequestService requestService, IDialogService dialogService)
        {
            this.requestService = requestService;
            this.dialogService = dialogService;
        }

        public async Task<string> SendSMSAsync(string phonenumber)
        {
            var token = Generatetoken();
            App.Current.Properties["token"] = token;
            await App.Current.SavePropertiesAsync();

            Models.SMS sms = new Models.SMS
            {
                Body = $"Your access code for travellingyuan is {token}",
                To = phonenumber
            };
            var builder = new UriBuilder(AppSettings.SMSEndPoint);
            var uri = builder.ToString();
            var responsedata = await requestService.PostAsync<Models.SMS, string>(uri, sms);
            await Hadleresponsedata(responsedata);
            return responsedata;

        }

        async Task Hadleresponsedata(string responsedata)
        {
            if (responsedata == "queued")
            {
                await dialogService.ShowAlertAsync($"Message on its way", "Message", "Dismiss");
                return;
            }
            else if (responsedata.Equals(Resources.TwillioError))
            {
                await dialogService.ShowAlertAsync($"Only EU numbers are allowed", "Message", "Dismiss");
                return;
            }
            else
            {
                await dialogService.ShowAlertAsync($"The sms server says: {responsedata}", "Message", "Dismiss");
                return;
            }
        }

        private string Generatetoken()
        {
            Random rnd = new Random();
            int token = rnd.Next(1000, 9999);
            return token.ToString();
        }
    }
}
