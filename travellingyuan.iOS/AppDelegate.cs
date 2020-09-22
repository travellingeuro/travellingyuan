using Syncfusion.SfMaps.XForms.iOS;
using Syncfusion.XForms.iOS.Graphics;
using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.iOS.Border;
using Syncfusion.XForms.iOS.Buttons;
using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;
using Google.MobileAds;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using AppsFlyerXamarinBinding;

namespace travellingyuan.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzEwOTEwQDMxMzgyZTMyMmUzMEt3ZGc2SjM1Z0dGcEVYdzc1KzY4K3l1RURTQjR0RXN4SkpyNzMvR2M1MWs9");
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.Forms.FormsMaterial.Init();

            AppCenter.Start("fc96f24b-04b6-490d-a920-7ed0956a5bee", typeof(Analytics), typeof(Crashes));
            AppsFlyerLib.Shared.AppleAppID = "1511015537";
            AppsFlyerLib.Shared.AppsFlyerDevKey = AppSettings.AppsFlyerDevKey;
            SfMapsRenderer.Init();
            MobileAds.SharedInstance.Start(CompletionHandler);
            SfGradientViewRenderer.Init();
            SfBorderRenderer.Init();
            SfButtonRenderer.Init();
            SfComboBoxRenderer.Init();
            LoadApplication(new App(new iOSInitializer()));
            return base.FinishedLaunching(app, options);
        }

        public override void OnActivated(UIApplication application)
        {
            AppsFlyerLib.Shared.Start();
        }


        private void CompletionHandler(InitializationStatus status) { }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
