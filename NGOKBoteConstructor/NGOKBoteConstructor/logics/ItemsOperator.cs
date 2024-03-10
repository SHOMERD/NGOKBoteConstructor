using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Xamarin.Forms;

namespace NGOKBoteConstructor.logics
{
    public class ItemsOperator
    {
        public TGButton TGMenu { get; set; }

        public ItemsOperator() 
        {
            this.TGMenu = TryGetSave();
        }



        public TGButton TryGetSave()
        {
            try
            {
                string FileNameString = $"SaveStats.json";
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                TGButton tGButton = JsonConvert.DeserializeObject<TGButton>(File.ReadAllText(Path.Combine(folderPath, FileNameString)));
                if (tGButton != null) 
                {
                    return tGButton;

                }else
                {
                    return GetStartMenu();
                }
                


            }
            catch (Exception)
            {
                return GetStartMenu();
            }

        }


        public TGButton GetStartMenu()
        {
            TGButton tGButton = new TGButton() { IsHasRebcursiveButtons = false,
                Teg = "StartMenu",
                Title = "StartMenu",
                TextOfMenu = "Приветствую Вас! Я бот Новосибирского городского открытого колледжа, подскажите, а кем являетесь Вы?\r\n" };

            tGButton.TGСhildMenu = new List<TGButton>();
            tGButton.RecursiveButtons = new List<TGButton>();

            return tGButton;
        }





        public TGButton GetTGbuttonByTeg(string TegToFound, TGButton tGButton = null)
        {
            if (tGButton == null)
            {
                tGButton = TGMenu;
            }

            if (TegToFound == tGButton.Teg) {
                return tGButton;
            }

            if (tGButton.TGСhildMenu != null)
            {
                for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
                {
                    TGButton tGButton1 = GetTGbuttonByTeg(TegToFound, tGButton.TGСhildMenu[i]);
                    if (tGButton1 != null) { return tGButton1; }
                }
            }
            if (tGButton.RecursiveButtons != null)
            {
                for (int i = 0; i < tGButton.RecursiveButtons.Count; i++)
                {
                    TGButton tGButton1 =  GetTGbuttonByTeg(TegToFound, tGButton.RecursiveButtons[i]);
                    if (tGButton1 != null) { return tGButton1; }
                }
            }
            

            return null;
            
        }

        public void DeliteButton(TGButton tgButtonToF, string PerentTeg, bool isRecursive)
        {
            TGButton tgButton = GetTGbuttonByTeg(PerentTeg);
            if (isRecursive) 
            {
                tgButton.RecursiveButtons.Remove(tgButtonToF);
            }else
            {
                tgButton.TGСhildMenu.Remove(tgButtonToF);
            }


        }



        public void SeveStats()
        {
            string FileNameString = $"SaveStats.json";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            File.WriteAllText(Path.Combine(folderPath, FileNameString), JsonConvert.SerializeObject(TGMenu));
            App.Current.MainPage.DisplayAlert("Сохранено", "", "OK");

        }
            








        public TGButton SheetMetob()
        {
            TGButton tGMenu = new TGButton() {IsHasRebcursiveButtons = false,  Teg = "StartMenu", Title = "StartMenu", TextOfMenu = "Приветствую Вас! Я бот Новосибирского городского открытого колледжа, подскажите, а кем являетесь Вы?\r\n" };
            tGMenu.TGСhildMenu = new List<TGButton>();


            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "sdg", Title = "фывапвфыапрвыф" });



            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "sdg", Title = "ыврфварфвыарп" });
            tGMenu.TGСhildMenu.Add(new TGButton()
            {
                Teg = "HasMenu",
                Title = "HasMenu",
                TextOfMenu = "dgdsfgd\nsagasdfgadsfgadf\nsdgsadgasdgasdfgasdg\nasrtgasdrg",
                TGСhildMenu = new List<TGButton>{ new TGButton() { Teg = "sdsgsdwhgsehg" , Title = "sdsgsdwhgsehg"}, new TGButton() { Teg = "shshfgsh" , Title = "shshfgsh"}, new TGButton() { Teg = "xc myuik,ui", Title = "xc myuik,ui",
                                                 TGСhildMenu = new List<TGButton>{new TGButton(){ Teg = "hsdgflkghja" , Title = "hsdgflkghja" } }
                                             }
                }
            });
            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "HasRebcursiveButtons", IsHasRebcursiveButtons = true, Title = "HasRebcursiveButtons",
                RecursiveButtons = new List<TGButton>() { new TGButton() { Teg = "yl;i9o8" , Title = "yl;i9o8" }, new TGButton() { Teg = ",iy.,yui.," , Title = ",iy.,yui.," } }
            });
            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "ssdgdg", Title = "ssdgdg" });
            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "sdfh" , Title = "sdfh" });
            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "sdzg", Title = "sdzg" });
            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "ssdfhdg" , Title = "ssdfhdg" });
            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "sjntdzjdg" , Title = "sjntdzjdg" });
            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "sdzbfdzg" , Title = "sdzbfdzg" });
            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "szdg" , Title = "szdg" });
            tGMenu.TGСhildMenu.Add(new TGButton() {   Teg = "szdtndg" , Title = "szdtndg" });
            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "seragawregdg" , Title = "seragawregdg" });
            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "sdzngfzg" , Title = "sdzngfzg" });

            return tGMenu;
        }










    }
}
