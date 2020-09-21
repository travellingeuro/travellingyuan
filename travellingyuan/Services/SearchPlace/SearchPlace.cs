using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using travellingyuan.Exceptions;
using travellingyuan.Models;
using Xamarin.Essentials;

namespace travellingyuan.Services.SearchPlace
{
    public class SearchPlace : ISearchPlace
    {


        private HttpClient CreateClient()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                throw new ConnectivityException();
            }

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppSettings.GoogleBaseEndPoint)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public async Task<GooglePlace> GetPlaceDetails(string placeId)
        {
            {
                GooglePlace result = null;
                using (var httpClient = CreateClient())
                {
                    var response = await httpClient.GetAsync($"api/place/details/json?placeid={Uri.EscapeUriString(placeId)}&key={AppSettings.GooglePlacesApiKey}").ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        if (!string.IsNullOrWhiteSpace(json) && json != "ERROR")
                        {
                            result = new GooglePlace(JObject.Parse(json));
                        }
                    }
                }

                return result;
            }
        }

        public async Task<GooglePlaceAutoCompleteResult> GetPlaces(string text)
        {
            GooglePlaceAutoCompleteResult results = null;

            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync($"api/place/autocomplete/json?input={Uri.EscapeUriString(text)}&key={AppSettings.GooglePlacesApiKey}").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json) && json != "ERROR")
                    {
                        results = await Task.Run(() =>
                           JsonConvert.DeserializeObject<GooglePlaceAutoCompleteResult>(json)
                        ).ConfigureAwait(false);

                    }
                }
            }
            return results;
        }

        public async Task<GooglePlacePictures> GetPlaceDetailsForPictures(string placeId)
        {
            {
                GooglePlacePictures result = null;
                using (var httpClient = CreateClient())
                {
                    var response = await httpClient.GetAsync($"api/place/details/json?placeid={Uri.EscapeUriString(placeId)}&key={AppSettings.GooglePlacesApiKey}").ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        if (!string.IsNullOrWhiteSpace(json) && json != "ERROR" && !json.Contains("INVALID_REQUEST") && json.Contains("photos"))
                        {
                            result = new GooglePlacePictures(JObject.Parse(json));
                        }
                    }
                }

                return result;
            }
        }
    }
}
