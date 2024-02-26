using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NGOKBoteConstructor.Pages
{
    public class SheetClas
    {
        public string ItemName {  get; set; }
    }





    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowingPage : ContentPage
    {
        public ShowingPage()
        {
            InitializeComponent();
            List<SheetClas> sheetClas = new List<SheetClas>();
            sheetClas.Add(new SheetClas() { ItemName = "sdg" });
            listViweData.ItemsSource = sheetClas;
        }

        private void Deleteitem(object sender, EventArgs e)
        {


        }

        private void ShowTGСhildButtons(object sender, EventArgs e)
        {


        }

        private void EditItem(object sender, EventArgs e)
        {


        }



    }
}