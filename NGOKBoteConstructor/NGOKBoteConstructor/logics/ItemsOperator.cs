using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace NGOKBoteConstructor.logics
{
    public class ItemsOperator
    {
        public TGButton TGMenu { get; set; }
        
        public ItemsOperator() {
            this.TGMenu = SheetMetob();
        }


        public ItemsOperator(string JsonMenu) 
        {
            this.TGMenu = JsonConvert.DeserializeObject<TGButton>(JsonMenu);
        }


        public void CreaitJsonDoc()
        {

            string FileNameString = $"backup.json";
            string FilePathString = $"A:\\Рабочий стол\\used\\";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            File.WriteAllText(Path.Combine(folderPath, FileNameString), JsonConvert.SerializeObject(TGMenu));
        }
            








        public TGButton SheetMetob()
        {
            TGButton tGMenu = new TGButton();
            tGMenu.TGСhildMenu = new List<TGButton>();


            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "sdg", Title = "sdg" });



            tGMenu.TGСhildMenu.Add(new TGButton() { Teg = "sdg", Title = "sdg" });
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
