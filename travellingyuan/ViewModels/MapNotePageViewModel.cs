using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.SfMaps.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using travellingyuan.Controls;
using travellingyuan.Helper;
using travellingyuan.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace travellingyuan.ViewModels
{
	[Preserve(AllMembers = true)]
	public class MapNotePageViewModel : BindableBase, INavigationAware
	{
		//Services
		public INavigationService NavigationService { get; private set; }

		//Commands
		public DelegateCommand HomeCommand { get; set; }
		public DelegateCommand SearchCommand { get; set; }

		//Properties
		private List<Uploads> uploads;
		public List<Uploads> Uploads
		{
			get { return uploads; }
			set { SetProperty(ref uploads, value); }
		}

		private string serialnumber;
		public string SerialNumber
		{
			get { return serialnumber; }
			set { SetProperty(ref serialnumber, value); }
		}


		private ObservableCollection<MapMarker> pins = new ObservableCollection<MapMarker>();
		public ObservableCollection<MapMarker> Pins
		{
			get { return pins; }
			set { SetProperty(ref pins, value); }
		}
		private ObservableCollection<Point> points = new ObservableCollection<Point>();
		public ObservableCollection<Point>  Points
		{
			get { return points; }
			set { SetProperty(ref points, value); }
		}


		public MapNotePageViewModel(INavigationService navigationService)
		{
			this.NavigationService = navigationService;
			this.HomeCommand = new DelegateCommand(GoBack);
			this.SearchCommand = new DelegateCommand(GoSearch);

		}

		private async void GoSearch()
		{
			await NavigationService.NavigateAsync("../../SearchNotePage");
		}

		private async void GoBack()
		{
			await NavigationService.GoBackAsync();
		}

		private void AddPins()
		{
			if (Pins.Any())
			{
				Pins.Clear();
			}
			if (Points.Any())
			{
				Points.Clear();
			}
			if (Uploads != null)
			{
				var imagepicker = new ImagePicker();

				foreach (Uploads upload in Uploads)
				{
                    var marker = new CustomMarker
                    {
                        Latitude = upload.Latitude.ToString(),
                        Longitude = upload.Longitude.ToString(),
                        Label = upload.Comments,
                        Address = upload.Address,
                        Date = upload.UploadDate,
                        Image = imagepicker.Imagepicker(upload.Value)
                    };
                    Pins.Add(marker);
                    Points.Add(new Point((double)upload.Latitude,(double)upload.Longitude));                    
				}
			}
		}
		public void OnNavigatedFrom(INavigationParameters parameters)
		{

			parameters.Add("Uploads", Uploads);
		}

		public void OnNavigatedTo(INavigationParameters parameters)
		{
			Uploads = (List<Uploads>)parameters["Uploads"] ?? null;
			if (Uploads.Any())
			{
				SerialNumber = Uploads.FirstOrDefault().SerialNumber;
				AddPins();
			}
		}
	}
}
