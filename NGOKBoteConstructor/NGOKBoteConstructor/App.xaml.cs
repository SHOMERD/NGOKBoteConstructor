using NGOKBoteConstructor.logics;
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
            MainPage = new Page();
            ItemsOperator itemsOperator = new ItemsOperator();


            MainPage.Navigation.PushModalAsync(new NavigationPage(new ShowingPage(itemsOperator, itemsOperator.TGMenu, false)));
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
