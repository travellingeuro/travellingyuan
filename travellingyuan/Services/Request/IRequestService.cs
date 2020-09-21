using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace travellingyuan.Services.Request
{
    public interface IRequestService
    {
        Task<TResult> GetAsync<TResult>(string uri, string query = "");
        Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "");
        Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "");
    }
}
