using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using travellingyuan.Models;
using travellingyuan.Services.Request;

namespace travellingyuan.Services.SearchNote
{
    public class SearchNote : ISearchNote

    {
        readonly IRequestService requestService;

        public SearchNote(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        public Task<List<Uploads>> GetAllAsync()
        {
            var builder = new UriBuilder(AppSettings.SearchEndPoint);
            var uri = builder.ToString();
            return requestService.GetAsync<List<Uploads>>(uri);
        }

        public Task<List<Uploads>> GetSearchAsync(string serialnumber)
        {
            var builder = new UriBuilder(AppSettings.SearchEndPoint);

            builder.Query = $"?serial={serialnumber}";

            var uri = builder.ToString();

            return requestService.GetAsync<List<Uploads>>(uri);
        }


    }
}
