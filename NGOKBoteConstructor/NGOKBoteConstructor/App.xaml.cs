using NGOKBoteConstructor.Pages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NGOKBoteConstructor
{
    public partial class App : Application
    {
        public App()
        {
            
            InitializeComponent();
            Application.Current.UserAppTheme = OSAppTheme.Light;
            MainPage = new MainPage();
            MainPage.Navigation.PushModalAsync(new NavigationPage(new ShowingPage()));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
