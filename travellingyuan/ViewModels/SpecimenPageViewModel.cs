using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Internals;

namespace travellingyuan.ViewModels
{
    [Preserve(AllMembers = true)]
    class SpecimenPageViewModel : BindableBase, INavigationAware
    {
        //Service
        public INavigationService NavigationService { get; private set; }
        //Commands
        public DelegateCommand GoBackAsyncCommand { get; set; }
        //Constructor
        public SpecimenPageViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
            GoBackAsyncCommand = new DelegateCommand(GoBackAsync);
        }

        private void GoBackAsync()
        {
            NavigationService.GoBackAsync();
        }

        //Methods

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}
