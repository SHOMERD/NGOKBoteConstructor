using NGOKBoteConstructor.logics;
using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace NGOKBoteConstructor.Pages
{
    public partial class ShowingPage : ContentPage
    {
        public ItemsOperator itemsOperator {  get; set; }



        public ShowingPage()
        {
            InitializeComponent();

            this.itemsOperator = new ItemsOperator();
            listViweData.ItemsSource = this.itemsOperator.TGMenu.TGСhildMenu;
        }

        public ShowingPage(TGButton TGButton, bool IsRecursive)
        {
            InitializeComponent();
            if (IsRecursive && TGButton.RecursiveButtons != null)
            {
                PerentTeg.Text = "Тег нажатой кнопки: " + TGButton.Teg;
                PerentObgect.Text = "Текст меню: \n\n" + TGButton.TextOfMenu;
                TextOfMenu.IsVisible = true;
                this.listViweData.ItemsSource = TGButton.RecursiveButtons;
                BackButton.IsVisible = true;
            }
            else if (TGButton.TGСhildMenu != null && !IsRecursive) 
            {
                PerentTeg.Text = "Тег нажатой кнопки: " + TGButton.Teg;
                PerentObgect.Text = "Текст меню: " + TGButton.TextOfMenu;
                TextOfMenu.IsVisible = true;
                this.listViweData.ItemsSource = TGButton.TGСhildMenu;
                BackButton.IsVisible =true;
            }
            else
            {
                Navigation.PopModalAsync();
            }
            
        }

        private void Deleteitem(object sender, EventArgs e)
        {


        }

        private void SaveJson(object sender, EventArgs e)
        {
            //itemsOperator.CreaitJsonDoc();

        }




        private void ShowTGСhildMenu(object sender, EventArgs e)
        {
            TGButton tGButton = (TGButton)(sender as Xamarin.Forms.Button).BindingContext;
            
            if (tGButton.TGСhildMenu != null)
            {
                Navigation.PushModalAsync(new ShowingPage(tGButton, false));
            }

        }
        
        private void ShowRecursiveButtons(object sender, EventArgs e)
        {
            TGButton tGButton = (TGButton)(sender as Xamarin.Forms.Button).BindingContext;

            if (tGButton.RecursiveButtons != null)
            {
                Navigation.PushModalAsync(new ShowingPage(tGButton, true));
            }

        }




        private async void EditItem(object sender, EventArgs e)
        {

            TGButton tGButton = (TGButton)(sender as Xamarin.Forms.Button).BindingContext;
            Navigation.PushModalAsync(new NavigationPage(new EditPage(tGButton)));

        }

        private void AddButton(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new EditPage(new TGButton())));
        }

        private void ReteternPerentPage(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}