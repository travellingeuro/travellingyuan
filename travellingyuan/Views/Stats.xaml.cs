using MarcTron.Plugin;
using Syncfusion.SfMaps.XForms;
using System.Collections.Generic;
using System.Linq;
using travellingyuan.Helper;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace travellingyuan.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Stats : ContentPage
    {
        public Stats()
        {
            InitializeComponent();
            if (AppSettings.ShowInterstitial) 
            {
                var interad = Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.Android ? AppSettings.InterstitialAndroid : AppSettings.InterstitialiOS;
                CrossMTAdmob.Current.LoadInterstitial(interad);
                ShowInterstitial();
            }
            
        }

        private void ShowInterstitial()
        {
            var show = CrossMTAdmob.Current.IsInterstitialLoaded();
            if (show)
            {
                CrossMTAdmob.Current.ShowInterstitial();
                AppSettings.ShowInterstitial = false;
                CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;
            }
        }

        private void Current_OnInterstitialClosed(object sender, System.EventArgs e)
        {
            ValuePicker_SelectionChanged(new object(), new Syncfusion.XForms.ComboBox.SelectionChangedEventArgs());
        }

        private void ValuePicker_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {

            var latitudes = new List<double>();
            var longitudes = new List<double>();


            if (map.Markers != null)
            {
                foreach (MapMarker marker in map.Markers)
                {
                    latitudes.Add(double.Parse(marker.Latitude, System.Globalization.NumberFormatInfo.CurrentInfo));
                    longitudes.Add(double.Parse(marker.Longitude, System.Globalization.NumberFormatInfo.CurrentInfo));
                }
            }

            double lowestLat = latitudes.Min();
            double highestLat = latitudes.Max();
            double lowestLong = longitudes.Min();
            double highestLong = longitudes.Max();
            double finalLat = (lowestLat + highestLat) / 2;
            double finalLong = (lowestLong + highestLong) / 2;
            double distance = DistanceCalculator.GeoCodeCalc.CalcDistance(lowestLat, lowestLong, highestLat, highestLong, DistanceCalculator.GeoCodeCalcMeasurement.Kilometers);

            map.GeoCoordinates = new Point(finalLat, finalLong);
            map.Radius = distance;
            map.DistanceType = DistanceType.KiloMeter;

        }
    }
}
