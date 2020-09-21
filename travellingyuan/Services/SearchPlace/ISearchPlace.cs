using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace travellingyuan.Services.SearchPlace
{
    public interface ISearchPlace
    {
        Task<Models.GooglePlaceAutoCompleteResult> GetPlaces(string text);

        Task<Models.GooglePlace> GetPlaceDetails(string placeId);

        Task<Models.GooglePlacePictures> GetPlaceDetailsForPictures(string placeId);
    }
}
