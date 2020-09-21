using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;

namespace travellingyuan.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", Label = "travellingyuan", MainLauncher = true, NoHistory = true)]
    public class SplashActivity :AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }
        async void SimulateStartup()
        {
            await Task.Delay(5000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}