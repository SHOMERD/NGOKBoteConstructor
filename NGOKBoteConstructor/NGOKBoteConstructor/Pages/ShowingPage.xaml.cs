using NGOKBoteConstructor.logics;
using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
            listViweData.ItemsSource = this.itemsOperator.TGMenu.tGButtons;
        }

        public ShowingPage(TGMenu tGMenu)
        {
            InitializeComponent();
            if (tGMenu != null) 
            {
                this.listViweData.ItemsSource = tGMenu.tGButtons;
                BackButton.IsEnabled = true;
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
            itemsOperator.CreaitJsonDoc();

        }




        private void ShowTGСhildButtons(object sender, EventArgs e)
        {
            TGButton tGButton = (TGButton)(sender as Button).BindingContext;
            PerentObgect.Text = tGButton.ItemName;
            if (tGButton.TGСhildMenu != null)
            {
                Navigation.PushModalAsync(new ShowingPage(tGButton.TGСhildMenu));
            }

        }

        private async void EditItem(object sender, EventArgs e)
        {

            TGButton tGButton = (TGButton)(sender as Button).BindingContext;
            Navigation.PushModalAsync(new NavigationPage(new EditPage(ref tGButton)));

        }

        private void AddButton(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
            Navigation.GetType();
        }

        private void ReteternPerentPage(object sender, EventArgs e)
        {
            
            Navigation.PopModalAsync();
        }
    }
}