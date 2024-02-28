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
            listViweData.ItemsSource = itemsOperator.TGMenu.tGButtons;
        }



        private void Deleteitem(object sender, EventArgs e)
        {


        }



        private void ShowTGСhildButtons(object sender, EventArgs e)
        {
            TGButton tGButton = (TGButton)(sender as Button).BindingContext;
            PerentObgect.Text = tGButton.ItemName;
            listViweData.ItemsSource = tGButton.TGСhildMenu.tGButtons;

        }

        private async void EditItem(object sender, EventArgs e)
        {

            TGButton tGButton = (TGButton)(sender as Button).BindingContext;
            Navigation.PushModalAsync(new NavigationPage(new EditPage(ref tGButton)));

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}