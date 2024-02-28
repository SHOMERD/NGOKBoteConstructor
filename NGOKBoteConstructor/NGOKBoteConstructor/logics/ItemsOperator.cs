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
        public TGMenu TGMenu { get; set; }
        
        public ItemsOperator() {
            this.TGMenu = SheetMetob();
        }


        public ItemsOperator(string JsonMenu) 
        {
            this.TGMenu = JsonConvert.DeserializeObject<TGMenu>(JsonMenu);
        }


        public void CreaitJsonDoc()
        {

            string FileNameString = $"backup.json";
            string FilePathString = $"A:\\Рабочий стол\\used\\";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            File.WriteAllText(Path.Combine(folderPath, FileNameString), JsonConvert.SerializeObject(TGMenu));
        }









        public TGMenu SheetMetob()
        {
            TGMenu tGMenu = new TGMenu();
            tGMenu.tGButtons = new List<TGButton>();


            tGMenu.tGButtons.Add(new TGButton() { ItemName = "sdg" });



            tGMenu.tGButtons.Add(new TGButton() { ItemName = "sdg" });
            tGMenu.tGButtons.Add(new TGButton()
            {
                ItemName = "sdzfdhbgdfbzdfbg",
                TGСhildMenu = new TGMenu() { ItemName = ".jhj.u.,",
                                             tGButtons = new List<TGButton>() { new TGButton() { ItemName = "sdsgsdwhgsehg" }, new TGButton() { ItemName = "shshfgsh" }, new TGButton() { ItemName = "xc myuik,ui" }
                                             }
                }
            });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "sasrhdg" });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "ssdgdg" });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "sdfh" });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "sdzg" });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "ssdfhdg" });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "sjntdzjdg" });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "sdzbfdzg" });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "szdg" });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "szdtndg" });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "seragawregdg" });
            tGMenu.tGButtons.Add(new TGButton() { ItemName = "sdzngfzg" });

            return tGMenu;
        }










    }
}
