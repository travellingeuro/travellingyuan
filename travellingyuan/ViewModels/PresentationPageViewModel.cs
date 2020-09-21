using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace travellingyuan.ViewModels
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class PresentationPageViewModel : BindableBase
    {
        //Navigation Service
        public INavigationService navigationService { get; private set; }

        //Commands
        public DelegateCommand NavigateToSearchNotePageCommand { get; set; }
        public DelegateCommand NavigateToAddNoteCommand { get; set; }
        public DelegateCommand NavigateToStatsViewPageCommand { get; set; }
       


        public PresentationPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            NavigateToSearchNotePageCommand = new DelegateCommand(NavigateToSearchNotePageMethod);
            NavigateToAddNoteCommand = new DelegateCommand(NavigateToAddNoteMethod);
            NavigateToStatsViewPageCommand = new DelegateCommand(NavigateTotatsViewPageMethod);
           
        }


        private async void NavigateTotatsViewPageMethod()
        {
            await navigationService.NavigateAsync("Stats"); 
        }

        private async void NavigateToAddNoteMethod()
        {
            await navigationService.NavigateAsync("AddNote");
        }

        private async void NavigateToSearchNotePageMethod()
        {
            await navigationService.NavigateAsync("SearchNotePage");
        }
    }
}
