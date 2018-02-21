using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace IntroToPrisms
{
    public class IntroToPrismsPageViewModel : BindableBase
    {
        INavigationService _navigationService;

        public DelegateCommand NavToPageOneCommand { get; set; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value);  }
        }

        public IntroToPrismsPageViewModel(INavigationService navigationService)
        {
           
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(IntroToPrismsPageViewModel)}: ctor");
        }

       
    }
}