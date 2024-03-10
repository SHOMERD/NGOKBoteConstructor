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

            List<int> ints = new List<int>();
            TGButton tGButton = itemsOperator.GetTGbuttonByTeg(PerentTeg);

            if (isRecursive) { 

                for (int i = 0; i < tGButton.RecursiveButtons.Count; i++)
                {
                    ints.Add(i+1);
                }
            }else
            {
                for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
                {
                    ints.Add(i + 1);
                }
            }

            PlacePicker.ItemsSource = ints;
            IsHasRebcursive.IsToggled = TgButton.IsHasRebcursiveButtons;
            TegIsSeteblede.IsEnabled = string.IsNullOrEmpty(TgButton.Teg);


        }


        public bool ChekPossibilityToSave()
        {
            if (string.IsNullOrEmpty(TgButton.Teg))
            {
                if (!string.IsNullOrEmpty(ItemTegEntry.Text))
                {
                    if ((itemsOperator.GetTGbuttonByTeg(ItemTegEntry.Text) != null))
                    {
                        return false;
                    }
                }else { return false; }
                

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
                TgButton.Url = ChekUrl(UriEntry.Text);


                if (PlacePicker.SelectedIndex != -1)
                {

                    TGButton BuferButtot = new TGButton();
                    BuferButtot = TgButton;
                    itemsOperator.DeliteButton(TgButton, PerentTeg, isRecursive);

                    if (isRecursive) { itemsOperator.GetTGbuttonByTeg(PerentTeg).RecursiveButtons.Insert(PlacePicker.SelectedIndex, BuferButtot); }
                    else { itemsOperator.GetTGbuttonByTeg(PerentTeg).TGСhildMenu.Insert(PlacePicker.SelectedIndex, BuferButtot); }
                    
                }
                Navigation.PopModalAsync();
                
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Нельзя сохранить объект!", "Неправильно задан тег", "ок");
            }
            
        }

        public Uri ChekUrl(string Url)
        {
            try
            {
                return new Uri(Url);
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Нельзя сохранить объект!", "Неправельно задана ссылка\nИзмените ссылку или удалите её. ", "ок");
                return null;
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