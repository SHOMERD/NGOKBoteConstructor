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
        public ItemsOperator itemsOperator;
        string ActiveButtonTeg;
        bool IsRecursive;

        public ShowingPage(ItemsOperator itemsOperator, TGButton TGButton, bool IsRecursive)
        {
            InitializeComponent();
            this.itemsOperator = itemsOperator;
            this.ActiveButtonTeg = TGButton.Teg;
            this.IsRecursive = IsRecursive;
            SetViweData();
        }

        public void SetViweData()
        {

            TGButton tGButton = itemsOperator.GetTGbuttonByTeg(ActiveButtonTeg);
            PerentTeg.Text = "Тег нажатой кнопки: " + tGButton.Teg;
            PerentButtonTeg.Text = "Надпись на нажатой кнопке: " + tGButton.Title;
            PerentObgect.Text = "Текст меню:\n" + tGButton.TextOfMenu;
            listViweData.ItemsSource = null;
            
            listViweData.ItemsSource = tGButton.TGСhildMenu;                                                                                
            

            if (itemsOperator.TGMenu.Teg == ActiveButtonTeg) 
            {
                BackButton.IsVisible = false;
            }
            else
            {
                BackButton.IsVisible = true;
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetViweData();
        }

        private void DeleteItemButton(object sender, EventArgs e)
        {
            itemsOperator.DeliteButton((TGButton)(sender as Xamarin.Forms.Button).BindingContext, ActiveButtonTeg);
            itemsOperator.SeveStats();
            OnAppearing();
        }



        private void SaveJson(object sender, EventArgs e)
        {
            RecuestConsrtuktor.CreateJsonFile(itemsOperator.TGMenu);
           
        }


        private void ShowTGСhildMenu(object sender, EventArgs e)
        {
            TGButton tGButton = (TGButton)(sender as Xamarin.Forms.Button).BindingContext;
            Navigation.PushModalAsync(new ShowingPage(itemsOperator, tGButton, false));
            

        }
        
        private void ShowRecursiveButtons(object sender, EventArgs e)
        {
            TGButton tGButton = (TGButton)(sender as Xamarin.Forms.Button).BindingContext;
            Navigation.PushModalAsync(new ShowingPage(itemsOperator, tGButton, true));
   

        }




        private async void EditItem(object sender, EventArgs e)
        {

            TGButton tGButton = (TGButton)(sender as Xamarin.Forms.Button).BindingContext;
            if (tGButton != null)
            {
                Navigation.PushModalAsync(new NavigationPage(new EditPage(itemsOperator, itemsOperator.GetTGbuttonByTeg(tGButton.Teg), ActiveButtonTeg)));
            }
            else
            {
                Navigation.PushModalAsync(new NavigationPage(new EditPage(itemsOperator, itemsOperator.GetTGbuttonByTeg(ActiveButtonTeg), itemsOperator.GetTGbuttonByTeg(ActiveButtonTeg).ParentTeg)));
            }
        }

        private async void AddButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new EditPage(itemsOperator, null, ActiveButtonTeg)));
            
        }

        private void ReteternPerentPage(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void TrySetStats(object sender, EventArgs e)
        {
            RecuestDeconsrtuktor recuestDeconsrtuktor = new RecuestDeconsrtuktor();
            await recuestDeconsrtuktor.TriReadFile(itemsOperator);
            OnAppearing();
        }
    }
}