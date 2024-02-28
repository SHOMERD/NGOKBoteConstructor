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

        public EditPage(ref TGButton TgButton )
        {
            InitializeComponent();
            this.TgButton = TgButton;
            ItemTextEntry.Text = TgButton.ItemName;
            
        }

        private void SaveText(object sender, EventArgs e)
        {
            TGButton tGButton = new TGButton();
            tGButton.ItemName = ItemTextEntry.Text;
            TgButton = tGButton;
            Navigation.PopModalAsync();
        }
    }
}