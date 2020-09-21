using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using travellingyuan.Models;
using travellingyuan.Services.Dialogs;
using travellingyuan.Services.Request;

namespace travellingyuan.Services.AddNote
{
    public class AddNoteService : IAddNoteService
    {
        readonly IRequestService requestService;
        readonly IDialogService dialogService;

        public AddNoteService(IRequestService requestService, IDialogService dialogService)
        {
            this.requestService = requestService;
            this.dialogService = dialogService;
        }

        public Task<List<Notes>> GetSearchAsync(string serialnumber)
        {
            var builder = new UriBuilder(AppSettings.SearchEndPoint)
            {
                Query = $"?check={serialnumber}"
            };

            var uri = builder.ToString();

            return requestService.GetAsync<List<Notes>>(uri);
        }

        public Task<List<Uploads>> GetListUploads(string email)
        {
            var builder = new UriBuilder(AppSettings.UploadsEndPoint)
            {
                Query = $"?email={email}"
            };

            var uri = builder.ToString();

            return requestService.GetAsync<List<Uploads>>(uri);

        }

        public async Task<string> PostUpload(Uploads uploads)
        {
            var builder = new UriBuilder(AppSettings.UploadsEndPoint);

            var uri = builder.ToString();

            var response = await requestService.PostAsync<Uploads, string>(uri, uploads);

            //await HandleResponse(response, uploads);

            return response;
        }

        public async Task<string> PostNote(Notes note)

        {
            var builder = new UriBuilder(AppSettings.SearchEndPoint);

            var uri = builder.ToString();

            var response = await requestService.PostAsync<Notes, string>(uri, note);

            return response;

        }

        public Task<List<Models.Mints>> GetMintCode(string code)
        {
            var builder = new UriBuilder(AppSettings.MintsEndPoint)
            {
                Query = $"?code={code}"
            };

            var uri = builder.ToString();

            return requestService.GetAsync<List<Models.Mints>>(uri);
        }

        async Task HandleResponse(string responsedata, Uploads uploads)
        {
            if (string.IsNullOrEmpty(responsedata))
            {
                await dialogService.ShowAlertAsync($"New note added in {uploads.Address}\n" +
                $" Comments:  {uploads.Comments}", "Congratulations", "OK");
                return;
            }
        }


    }
}
