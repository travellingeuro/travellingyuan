using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism;
using Prism.Ioc;
using travellingyuan.Services.AddNote;
using travellingyuan.Services.Dialogs;
using travellingyuan.Services.Notification;
using travellingyuan.Services.Request;
using travellingyuan.Services.Scan;
using travellingyuan.Services.SearchNote;
using travellingyuan.Services.SearchPlace;
using travellingyuan.Services.SMS;
using travellingyuan.Services.User;
using travellingyuan.ViewModels;
using travellingyuan.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace travellingyuan
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            AppCenter.Start($"android={AppSettings.AppCenterAndroidKey};ios={AppSettings.AppCenteriOSKey}",
                typeof(Analytics), typeof(Crashes));

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PresentationPage, PresentationPageViewModel>();
            containerRegistry.RegisterForNavigation<SearchNotePage, SearchNotePageViewModel>();
            containerRegistry.RegisterForNavigation<PhoneNumberPage, PhoneNumberPageViewModel>();
            containerRegistry.RegisterForNavigation<TokenPage, TokenPageViewModel>();
            containerRegistry.RegisterForNavigation<SpecimenPage, SpecimenPageViewModel>();
            containerRegistry.RegisterForNavigation<AddNote, AddNoteViewModel>();
            containerRegistry.RegisterForNavigation<ViewUpload, ViewUploadViewModel>();
            containerRegistry.RegisterForNavigation<Stats, StatsViewModel>();
            containerRegistry.RegisterForNavigation<MapNotePage, MapNotePageViewModel>();

            //Services
            containerRegistry.Register<IDialogService, DialogService>();
            containerRegistry.Register<IRequestService, RequestService>();
            containerRegistry.Register<IScanService, ScanService>();
            containerRegistry.Register<ISearchNote, SearchNote>();
            containerRegistry.Register<ISmsService, SmsService>();
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IAddNoteService, AddNoteService>();
            containerRegistry.Register<ISearchPlace, SearchPlace>();
            containerRegistry.Register<INotificationService, NotificationService>();
            
        }
    }
}
