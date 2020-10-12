using Xamarin.Essentials;

namespace travellingyuan
{
    public static class AppSettings
    {
        //google ads keys
        const string defaultAndroidAdsKey = "ca-app-pub-9800707284712065~1990749964";
        const string defaultIosAdsKey = "ca-app-pub-9800707284712065~5378249062";

        //google ads id's
        const string defaultAndroidAds = "ca-app-pub-9800707284712065/3418493654";
        const string defaultIosAds = "ca-app-pub-9800707284712065/6044656994";
        const string defaultSampleAndroidAds = "ca-app-pub-3940256099942544/6300978111";
        const string defaultSampleIosAds = "ca-app-pub-3940256099942544/2934735716";

        //AppsFlyer DeveloperKey
        const string defaultAppsFlyerDevKey = "mev2fD4zJwnzjJhAGYd3SH";

        //Cognitive services
        const string defaultCognitiveServiceKey = "27a4453a28ab4df8af50d22fed37bcc0";

        //Places 
        const string defaultGooglePlacesApiKey = "AIzaSyAA5f_usWVL2jbldPd4KDKFFZIrMuKYD6U";

        //Syncfucsion
        const string defaultSyncfusionKey = "MzEwOTEwQDMxMzgyZTMyMmUzMEt3ZGc2SjM1Z0dGcEVYdzc1KzY4K3l1RURTQjR0RXN4SkpyNzMvR2M1MWs9";


        //AppCenter
        const string defaultAppCenterAndroidKey = "93ae46ad-ed4c-40ca-82df-e12c3fdab482";
        const string defaultAppCenteriOSKey = "fc96f24b-04b6-490d-a920-7ed0956a5bee";



        //EndPoints
        static readonly string defautlSearchEndPoint;
        static readonly string defaultUserEndPoint;
        static readonly string defaultUploadsEndPoint;
        static readonly string defaultMintsEndPoint;
        static readonly string defaultCoginitiveServiceEndPoint;
        static readonly string defaultSMSEndPoint;
        static readonly string defaultGoogleBaseEndPoint;
        static readonly string defaultNotificationEndPoint;
        static readonly string BaseAddress;

        static AppSettings()
        {
            BaseAddress = "https://travellingyuanwebapi.azurewebsites.net";
            defautlSearchEndPoint = $"{BaseAddress}/api/notes/";
            defaultUserEndPoint = $"{BaseAddress}/api/users/";
            defaultUploadsEndPoint = $"{BaseAddress}/api/Uploads/";
            defaultMintsEndPoint = $"{BaseAddress}/api/mints/"; 
            defaultSMSEndPoint = $"{BaseAddress}/api/sms"; 
            defaultNotificationEndPoint = $"{BaseAddress}/api/notifications/";
            defaultCoginitiveServiceEndPoint = "https://southcentralus.api.cognitive.microsoft.com/";           
            defaultGoogleBaseEndPoint = "https://maps.googleapis.com/maps/";
        }

        //Properties
        public static string AndroidAdsKey
        {
            get => Preferences.Get(nameof(AndroidAdsKey), defaultAndroidAdsKey);
            set => Preferences.Set(nameof(AndroidAdsKey), value);
        }

        public static string IosAdsKey
        {
            get => Preferences.Get(nameof(IosAdsKey), defaultIosAdsKey);
            set => Preferences.Set(nameof(IosAdsKey), value);
        }

        public static string AndroidAds
        {
            get => Preferences.Get(nameof(AndroidAds), defaultAndroidAds);
            set => Preferences.Set(nameof(AndroidAds), value);
        }

        public static string IosAds
        {
            get => Preferences.Get(nameof(IosAds), defaultIosAds);
            set => Preferences.Set(nameof(IosAds), value);
        }

        public static string SampleAndroidAds
        {
            get => Preferences.Get(nameof(SampleAndroidAds), defaultSampleAndroidAds);
            set => Preferences.Set(nameof(SampleAndroidAds), value);
        }

        public static string SampleIosAds
        {
            get => Preferences.Get(nameof(SampleIosAds), defaultSampleIosAds);
            set => Preferences.Set(nameof(SampleIosAds), value);
        }

        public static string AppsFlyerDevKey
        {
            get => Preferences.Get(nameof(AppsFlyerDevKey), defaultAppsFlyerDevKey);
            set => Preferences.Set(nameof(AppsFlyerDevKey), value);
        }



        public static string CognitiveServiceKey
        {
            get => Preferences.Get(nameof(CognitiveServiceKey), defaultCognitiveServiceKey);
            set => Preferences.Set(nameof(CognitiveServiceKey), value);
        }

        public static string GooglePlacesApiKey
        {
            get => Preferences.Get(nameof(GooglePlacesApiKey), defaultGooglePlacesApiKey);
            set => Preferences.Set(nameof(GooglePlacesApiKey), value);
        }

        public static string SyncfusionKey
        {
            get => Preferences.Get(nameof(SyncfusionKey), defaultSyncfusionKey);
            set => Preferences.Set(nameof(SyncfusionKey), value);
        }

        public static string AppCenterAndroidKey
        {
            get => Preferences.Get(nameof(AppCenterAndroidKey), defaultAppCenterAndroidKey);
            set => Preferences.Set(nameof(AppCenterAndroidKey), value);
        }
        public static string AppCenteriOSKey
        {
            get => Preferences.Get(nameof(AppCenteriOSKey), defaultAppCenteriOSKey);
            set => Preferences.Set(nameof(AppCenteriOSKey), value);
        }

        public static string SearchEndPoint
        {
            get => Preferences.Get(nameof(SearchEndPoint), defautlSearchEndPoint);
            set => Preferences.Set(nameof(SearchEndPoint), value);
        }

        public static string UserEndPoint
        {
            get => Preferences.Get(nameof(UserEndPoint), defaultUserEndPoint);
            set => Preferences.Set(nameof(UserEndPoint), value);
        }

        public static string UploadsEndPoint
        {
            get => Preferences.Get(nameof(UploadsEndPoint), defaultUploadsEndPoint);
            set => Preferences.Set(nameof(UploadsEndPoint), value);
        }

        public static string MintsEndPoint
        {
            get => Preferences.Get(nameof(MintsEndPoint), defaultMintsEndPoint);
            set => Preferences.Set(nameof(MintsEndPoint), value);
        }



        public static string CognitiveServiceEndPoint
        {
            get => Preferences.Get(nameof(CognitiveServiceEndPoint), defaultCoginitiveServiceEndPoint);
            set => Preferences.Set(nameof(CognitiveServiceEndPoint), value);
        }

        public static string SMSEndPoint
        {
            get => Preferences.Get(nameof(SMSEndPoint), defaultSMSEndPoint);
            set => Preferences.Set(nameof(SMSEndPoint), value);
        }

        public static string GoogleBaseEndPoint
        {
            get => Preferences.Get(nameof(GoogleBaseEndPoint), defaultGoogleBaseEndPoint);
            set => Preferences.Set(nameof(GoogleBaseEndPoint), value);
        }

        public static string NotificationEndPoint
        {
            get => Preferences.Get(nameof(NotificationEndPoint), defaultNotificationEndPoint);
            set => Preferences.Set(nameof(NotificationEndPoint), value);
        }



    }
}
