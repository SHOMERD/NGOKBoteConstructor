using NGOKBoteConstructor.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NGOKBoteConstructor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ShowingPage();
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
