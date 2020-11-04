using MarcTron.Plugin;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
//using AppTrackingTransparency;


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
                var platform = Xamarin.Essentials.DeviceInfo.Platform;
                var interad = platform == DevicePlatform.Android ? AppSettings.InterstitialAndroid : AppSettings.InterstitialiOS;
                //if (platform == DevicePlatform.iOS)
                //{
                //    ATTrackingManager.RequestTrackingAuthorization((status) =>
                //    {
                //        if (status == ATTrackingManagerAuthorizationStatus.Authorized) { CrossMTAdmob.Current.LoadInterstitial(interad); }

                //    });
                //}
                //else
                {
                    CrossMTAdmob.Current.LoadInterstitial(interad);
                }
                ShowInterstitial();
            }
                var videoid = Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.Android ? AppSettings.RewardVideoAndroid : AppSettings.RewardVideoiOS;
            CrossMTAdmob.Current.LoadRewardedVideo(videoid);
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

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (CrossMTAdmob.Current.IsRewardedVideoLoaded())
            {
                CrossMTAdmob.Current.ShowRewardedVideo();
            }

        }
    }
}
