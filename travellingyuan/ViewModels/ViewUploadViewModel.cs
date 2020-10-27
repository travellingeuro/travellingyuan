using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travellingyuan.Models;
using travellingyuan.Services.SearchPlace;
using Xamarin.Forms.Internals;

namespace travellingyuan.ViewModels
{
    [Preserve(AllMembers = true)]
    public class ViewUploadViewModel : BindableBase, INavigationAware
    {
        //Services
        public INavigationService NavigationService { get; private set; }
        public ISearchPlace searchPlace { get; private set; }


        //Commands
        public DelegateCommand MapTapCommand { get; set; }

        //Properties
        private List<Uploads> uploads;
        public List<Uploads> Uploads
        {
            get { return uploads; }
            set { SetProperty(ref uploads, value); }
        }
        private List<ExtendedUploads> extendeduploads;
        public List<ExtendedUploads> ExtendedUploads
        {
            get { return extendeduploads; }
            set { SetProperty(ref extendeduploads, value); }
        }

        private Uploads upload;
        public Uploads Upload
        {
            get { return upload; }
            set { SetProperty(ref upload, value); }
        }

        public ViewUploadViewModel(INavigationService navigationService, ISearchPlace searchPlace)
        {
            this.NavigationService = navigationService;
            this.searchPlace = searchPlace;
            this.MapTapCommand = new DelegateCommand(NaviagteToMap);
        }

        private async void NaviagteToMap()
        {

            var parameters = new NavigationParameters();
            parameters.Add("Uploads", Uploads);
            await NavigationService.NavigateAsync("MapNotePage", parameters);
        }

        private async Task<List<ExtendedUploads>> GetExtendedUploads()
        {
            var exup = new List<ExtendedUploads>();
            foreach (var upload in Uploads)
            {
                var place_id = upload.Location;

                var placedetails = await searchPlace.GetPlaceDetailsForPictures(place_id);
                if (placedetails != null)
                {
                    var photolist = placedetails.PhotoRef;
                    Random random = new Random();
                    var photopick = random.Next(0, photolist.Count - 1);
                    var itemimage = placedetails.PhotoRef[photopick].photo_reference;

                    string uri = AppSettings.GoogleBaseEndPoint + "api/place/photo" + $"?maxwidth=400&photoreference={itemimage}&key={AppSettings.GooglePlacesApiKey}";


                    //var uri = builder.ToString();
                    var extended = new ExtendedUploads
                    {
                        Address = upload.Address,
                        Comments = upload.Comments,
                        UploadDate = upload.UploadDate,
                        ItemImage = uri,
                        Name=upload.Name
                    };
                    exup.Add(extended);
                }
                else
                {
                    var extended = new ExtendedUploads
                    {
                        Address = upload.Address,
                        Comments = upload.Comments,
                        UploadDate = upload.UploadDate,
                        Name=upload.Name
                    };
                    exup.Add(extended);

                }
            }
            return exup;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }


        public void OnNavigatedTo(INavigationParameters parameters)
        {

            Uploads = (List<Uploads>)parameters["Uploads"] ?? null;
            ExtendedUploads = Task.Run(GetExtendedUploads).Result;
            Upload = Uploads.FirstOrDefault();

        }


    }
}
