using MarcTron.Plugin;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace travellingyuan.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUpload : ContentPage
    {
        public ViewUpload()
        {
            InitializeComponent();
            var videoid = Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.Android ? AppSettings.RewardVideoAndroid : AppSettings.RewardVideoiOS;
            CrossMTAdmob.Current.LoadRewardedVideo(videoid);
        }

        private void Listviewnotes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listviewnotes.SelectedItem = null;
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (CrossMTAdmob.Current.IsRewardedVideoLoaded())
            {
                CrossMTAdmob.Current.ShowRewardedVideo();
                var videoid = Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.Android ? AppSettings.RewardVideoAndroid : AppSettings.RewardVideoiOS;
                CrossMTAdmob.Current.LoadRewardedVideo(videoid);
            }

        }
    }
}
