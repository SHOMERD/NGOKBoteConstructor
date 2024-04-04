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
        bool CanHaveСhildMenu {  get; set; }
        bool isNew { get; set; }

        public EditPage(ItemsOperator itemsOperator, TGButton TgButton, string PerentTeg)
        {
            InitializeComponent();

            this.itemsOperator = itemsOperator;
            this.PerentTeg = PerentTeg;
            if (PerentTeg == null)
            {
                this.CanHaveСhildMenu = true;
            }
            else
            {
                this.CanHaveСhildMenu = !itemsOperator.GetTGbuttonByTeg(PerentTeg).СhildCanBeOnliUrl;
            }
            
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
            if (TgButton.Teg == "aaa")
            {
                WithUrl.IsVisible = false;
                TitleEntery.IsReadOnly = true;
                UriEntry.IsVisible = false;
                PlacePicker.IsVisible = false;
            }
            else
            {
                TGButton tGButton = itemsOperator.GetTGbuttonByTeg(PerentTeg);
                List<int> ints = new List<int>();

                for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
                {
                    
                    ints.Add(i + 1);
                }
                PlacePicker.ItemsSource = ints;
            }

            WithUrl.IsToggled = TgButton.СhildCanBeOnliUrl;
            TextOfMenuEntery.Text = TgButton.TextOfMenu;
            TitleEntery.Text = TgButton.Title;
            ItemTegEntry.Text = TgButton.Teg;
            try {  UriEntry.Text = TgButton.Url.ToString(); } catch (Exception) { }

            UrlUi.IsVisible = !CanHaveСhildMenu;

            NotUrlUi.IsVisible = CanHaveСhildMenu;
            NotUrlUi1.IsVisible = CanHaveСhildMenu;


            
            TegIsSeteblede.IsEnabled = string.IsNullOrEmpty(TgButton.Teg);

        }


        public bool ChekPossibilityToSave()
        {
            if (string.IsNullOrEmpty(TitleEntery.Text))
            {
                App.Current.MainPage.DisplayAlert("Нельзя сохранить объект!", "Не задан текст на кнопке", "ок");
                return false;
            }


            if (!CanHaveСhildMenu)
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

            return true;
        }



        private void SaveText(object sender, EventArgs e)
        {
            if (ChekPossibilityToSave())
            {
                

                TgButton.TextOfMenu = TextOfMenuEntery.Text.Replace('\r','\n');
                 
                TgButton.ParentTeg = PerentTeg;
                TgButton.HasUrl = !CanHaveСhildMenu;

                if (CanHaveСhildMenu)
                {
                    TgButton.СhildCanBeOnliUrl = WithUrl.IsToggled;
                }
                else
                {
                    TgButton.СhildCanBeOnliUrl = true;
                }


                TgButton.Title = TitleEntery.Text;

                
                TgButton.Url = ChekUrl(UriEntry.Text);
                if (isNew)
                {
                    int t =  itemsOperator.GetEmptyTeg();
                    TgButton.IntTeg = t;
                    TgButton.Teg = itemsOperator.SetTeg(t);
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