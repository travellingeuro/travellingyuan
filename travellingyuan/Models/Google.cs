using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace travellingyuan.Models
{
    [Preserve(AllMembers = true)]
    public class GooglePlaceAutoCompletePrediction
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("structured_formatting")]
        public StructuredFormatting StructuredFormatting { get; set; }

    }
    [Preserve(AllMembers = true)]
    public class StructuredFormatting
    {
        [JsonProperty("main_text")]
        public string MainText { get; set; }

        [JsonProperty("secondary_text")]
        public string SecondaryText { get; set; }
    }
    [Preserve(AllMembers = true)]
    public class GooglePlaceAutoCompleteResult
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("predictions")]
        public List<GooglePlaceAutoCompletePrediction> AutoCompletePlaces { get; set; }
    }
    [Preserve(AllMembers = true)]
    public class Photo
    {
        public int height { get; set; }
        public List<string> html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }
    [Preserve(AllMembers = true)]
    public class GooglePlace
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Raw { get; set; }

        public GooglePlace(JObject jsonObject)
        {
            Name = (string)jsonObject["result"]["name"];
            Location = (string)jsonObject["result"]["place_id"];
            Address = (string)jsonObject["result"]["formatted_address"];
            Latitude = (double)jsonObject["result"]["geometry"]["location"]["lat"];
            Longitude = (double)jsonObject["result"]["geometry"]["location"]["lng"];
            Raw = jsonObject.ToString();
        }
    }
    [Preserve(AllMembers = true)]
    public class GooglePlacePictures
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Photo> PhotoRef { get; set; }
        public string Raw { get; set; }

        public GooglePlacePictures(JObject jsonObject)
        {
            Name = (string)jsonObject["result"]["place_id"];
            Address = (string)jsonObject["result"]["formatted_address"];
            Latitude = (double)jsonObject["result"]["geometry"]["location"]["lat"];
            Longitude = (double)jsonObject["result"]["geometry"]["location"]["lng"];
            PhotoRef = jsonObject["result"]["photos"].ToObject<List<Photo>>();
            Raw = jsonObject.ToString();
        }
    }
}
