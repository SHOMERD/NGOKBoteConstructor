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

    public partial class EditPage : ContentPage
    {

        public TGButton TgButton {  get; set; }

        public EditPage(TGButton TgButton )
        {
            InitializeComponent();
            this.TgButton = TgButton;
            TextOfMenuEntery.Text = TgButton.TextOfMenu;
            TextEntery.Text = TgButton.Title;
            ItemTegEntry.Text = TgButton.Teg;
            IsHasRebcursive.IsToggled = TgButton.IsHasRebcursiveButtons;
            TegIsSeteblede.IsEnabled = string.IsNullOrEmpty(TgButton.Teg);


        }

        private void SaveText(object sender, EventArgs e)
        {
            TGButton tGButton = new TGButton();
            tGButton.Teg = ItemTegEntry.Text;
            TgButton = tGButton;
            Navigation.PopModalAsync();
        }

        private void CancelChanges(object sender, EventArgs e)
        { 
            Navigation.PopModalAsync();
        }
    }
}