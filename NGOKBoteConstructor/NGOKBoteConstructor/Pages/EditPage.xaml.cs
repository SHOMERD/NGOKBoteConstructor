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
        bool isNew { get; set; }

        public EditPage(ItemsOperator itemsOperator, TGButton TgButton, string PerentTeg = null, bool isRecursive = false)
        {
            InitializeComponent();

            this.itemsOperator = itemsOperator;
            this.PerentTeg = PerentTeg;
            this.isRecursive = isRecursive;
            if (TgButton == null) 
            {
                isNew = true;
                this.TgButton = new TGButton() { Title = "Новая кнопка" };  
            }
            else 
            {
                isNew = false;
                this.TgButton = TgButton; 
            }
            
            SetContext();
        }

        public void SetContext() 
        {
            if (TgButton.Teg == "StartMenu")
            {
                WithUrl.IsVisible = false;
                TitleEntery.IsReadOnly = true;
                UriEntry.IsVisible = false;
                PlacePicker.IsVisible = false;
            }

            WithUrl.IsToggled = TgButton.HasUrl;
            TextOfMenuEntery.Text = TgButton.TextOfMenu;
            TitleEntery.Text = TgButton.Title;
            ItemTegEntry.Text = TgButton.Teg;
            try {  UriEntry.Text = TgButton.Url.ToString(); } catch (Exception) { }


            List<int> ints = new List<int>();
            TGButton tGButton = itemsOperator.GetTGbuttonByTeg(PerentTeg);

            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                ints.Add(i + 1);
            }

            PlacePicker.ItemsSource = ints;
            TegIsSeteblede.IsEnabled = string.IsNullOrEmpty(TgButton.Teg);

        }


        public bool ChekPossibilityToSave()
        {
            if (string.IsNullOrEmpty(TitleEntery.Text))
            {
                App.Current.MainPage.DisplayAlert("Нельзя сохранить объект!", "Не задан текст на кнопке", "ок");
                return false;
            }


            if (WithUrl.IsToggled)
            {
                if(ChekUrl(UriEntry.Text) == null)
                {
                    App.Current.MainPage.DisplayAlert("Нельзя сохранить объект!", "Неправильно задана ссылка\nИзмените ссылку или удалите её. ", "ок");
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(TextOfMenuEntery.Text))
                {
                    App.Current.MainPage.DisplayAlert("Нельзя сохранить объект!", "Не задан текст меню, открываемого по кнопке", "ок");
                    return false;
                }
            }

            if (string.IsNullOrEmpty(TgButton.Teg))
            {
                if (!string.IsNullOrEmpty(ItemTegEntry.Text))
                {
                    if ((itemsOperator.GetTGbuttonByTeg(ItemTegEntry.Text) != null))
                    {
                        App.Current.MainPage.DisplayAlert("Нельзя сохранить объект!", "Неправильно задан тег", "ок");
                        return false;
                    }
                }else 
                {
                    App.Current.MainPage.DisplayAlert("Нельзя сохранить объект!", "Неправильно задан тег", "ок");
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
                TgButton.Teg = ItemTegEntry.Text;
                TgButton.ParentTeg = PerentTeg;
                TgButton.HasUrl = WithUrl.IsToggled;

                TgButton.Title = TitleEntery.Text;

                
                TgButton.Url = ChekUrl(UriEntry.Text);
                if (isNew)
                {
                    itemsOperator.GetTGbuttonByTeg(PerentTeg).TGСhildMenu.Add(TgButton);
                }


                if (PlacePicker.SelectedIndex != -1)
                {

                    TGButton BuferButtot = new TGButton();
                    BuferButtot = TgButton;
                    itemsOperator.DeliteButton(TgButton, PerentTeg);

                    itemsOperator.GetTGbuttonByTeg(PerentTeg).TGСhildMenu.Insert(PlacePicker.SelectedIndex, BuferButtot);
                }


                itemsOperator.SeveStats();
                Navigation.PopModalAsync();
                
            }
            
        }

        public Uri ChekUrl(string Url)
        {
            if (!string.IsNullOrEmpty(Url))
            {
                try
                {
                    return new Uri(Url);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }


        private void CancelChanges(object sender, EventArgs e)
        { 
            Navigation.PopModalAsync();
        }
    }
}