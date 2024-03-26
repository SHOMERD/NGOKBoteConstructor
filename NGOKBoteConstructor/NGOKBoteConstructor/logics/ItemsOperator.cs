using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

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
            TGButton tGButton = new TGButton() {
                Teg = "aaa",
                IntTeg = 0,
                Title = "StartMenu",
                HasUrl = false,
                TextOfMenu = "Приветствую Вас! Я бот Новосибирского городского открытого колледжа, подскажите, а кем являетесь Вы?\r\n" };

            tGButton.TGСhildMenu = new List<TGButton>();

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
            

            return null;
            
        }

        public void DeliteButton(TGButton tgButtonToF, string PerentTeg)
        {
            TGButton tgButton = GetTGbuttonByTeg(PerentTeg);            
            tgButton.TGСhildMenu.Remove(tgButtonToF);
 
        }



        public bool SeveStats()
        {
            string FileNameString = $"SaveStats.json";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            File.WriteAllText(Path.Combine(folderPath, FileNameString), JsonConvert.SerializeObject(TGMenu));
            return true;
        }
            
        public int GetMaxTeg(TGButton tGButton = null, int Max = 0)
        {
            if (tGButton == null)
            {
                tGButton = TGMenu;
                Max = TGMenu.IntTeg;
            }
            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                Max = GetMaxTeg(tGButton.TGСhildMenu[i], Max);
            }
            if (tGButton.IntTeg >= Max)
            {
                Max = tGButton.IntTeg;
            }
            return Max;
        }

        public List<int> GetEmptyTegs(TGButton tGButton = null, List<int> ints = null)
        {
            if(tGButton == null)
            {
                tGButton = TGMenu;
                ints = new List<int>();
                for (int i = 0; i < GetMaxTeg()+1; i++)
                {
                    ints.Add(i);
                }
            }
            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                GetEmptyTegs(tGButton.TGСhildMenu[i], ints);
            }
            ints.Remove(tGButton.IntTeg);

            return ints;
        }

        public int GetEmptyTeg()
        {
            List<int> ints = GetEmptyTegs();
            if (ints.Count == 0)
            {
                return GetMaxTeg()+1;
            }
            else
            {
                return ints[0];
            }
            
        }




    }
}
