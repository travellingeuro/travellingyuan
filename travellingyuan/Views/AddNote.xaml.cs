using MarcTron.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace travellingyuan.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNote : ContentPage
    {

        public AddNote()
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
            }
        }
    }
}
