using NGOKBoteConstructor.logics;
using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace NGOKBoteConstructor.Pages
{

    public partial class EditPage : ContentPage
    {

        public TGButton TgButton {  get; set; }
        ItemsOperator itemsOperator;
        string PerentTeg { get; set; }
        bool isRecursive {  get; set; }

        public EditPage(ItemsOperator itemsOperator, TGButton TgButton, string PerentTeg = null, bool isRecursive = false)
        {
            InitializeComponent();

            this.itemsOperator = itemsOperator;
            this.PerentTeg = PerentTeg;
            this.isRecursive = isRecursive;

            this.TgButton = TgButton;
            TextOfMenuEntery.Text = TgButton.TextOfMenu;
            TitleEntery.Text = TgButton.Title;
            ItemTegEntry.Text = TgButton.Teg;
            IsHasRebcursive.IsToggled = TgButton.IsHasRebcursiveButtons;
            TegIsSeteblede.IsEnabled = string.IsNullOrEmpty(TgButton.Teg);


        }


        public bool ChekPossibilityToSave()
        {
            if (string.IsNullOrEmpty(TgButton.Teg))
            {
                if ((itemsOperator.GetTGbuttonByTeg(ItemTegEntry.Text, null) != null))
                {
                    return false;
                }

            }
            return true;
        }



        private void SaveText(object sender, EventArgs e)
        {
            if (ChekPossibilityToSave())
            {
                TgButton.TextOfMenu = TextOfMenuEntery.Text;
                TgButton.Title = TitleEntery.Text;
                TgButton.IsHasRebcursiveButtons = IsHasRebcursive.IsToggled;
                TgButton.Teg = ItemTegEntry.Text;
                Navigation.PopModalAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Нельзя сохранить обьект", "Неправельно заданный тег", "ок");
            }
            
        }

        private void CancelChanges(object sender, EventArgs e)
        { 
            if (!ChekPossibilityToSave())
            {
                itemsOperator.DeliteButton(TgButton, PerentTeg, isRecursive);
            }
            Navigation.PopModalAsync();
        }
    }
}