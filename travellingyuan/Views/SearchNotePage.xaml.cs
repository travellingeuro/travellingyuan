using MarcTron.Plugin;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace travellingyuan.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchNotePage : ContentPage
    {
        public SearchNotePage()
        {
            InitializeComponent();
            var videoid = Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.Android ? AppSettings.RewardVideoAndroid : AppSettings.RewardVideoiOS;
            CrossMTAdmob.Current.LoadRewardedVideo(videoid);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (CrossMTAdmob.Current.IsRewardedVideoLoaded())
            {
                CrossMTAdmob.Current.ShowRewardedVideo();
            }
        }
    }
}