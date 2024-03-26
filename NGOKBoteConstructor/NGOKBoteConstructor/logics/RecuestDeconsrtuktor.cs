using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace NGOKBoteConstructor.logics
{
    public class RecuestDeconsrtuktor
    {
        ItemsOperator itemsOperator;


        public async Task<bool> TriReadFile(ItemsOperator itemsOperator)
        {
            this.itemsOperator = itemsOperator;
            try
            {
                itemsOperator.TGMenu= DeconsrtuktJsongString(await ReadJsonFile());
                return true;
            }
            catch (Exception)
            {
                Application.Current.MainPage.DisplayAlert("Файл не распознан", $"Файл не подходит для распознания", "ок");
                return false;
            }
            
        }

        public async Task<string> ReadJsonFile() 
        {
            StreamReader fileStream = (StreamReader)await DependencyService.Get<IFileManager>().GetJsonFile();

            return fileStream.ReadToEnd();

        }


        public TGButton DeconsrtuktJsongString(string JsonString) 
        {

            JToken d = JsonConvert.DeserializeObject<JToken>(JsonString);
            var s = d.Children();

            List<TGButton> buttons = new List<TGButton>();
            List<TGButtonsJS> assdqffq = new List<TGButtonsJS>();

            foreach (var item in s)
            {
                string tag = item.Path;


                string a = item.ToString();
                int w = a.IndexOf(": {");
                a = a.Substring(w + 2);
                Console.WriteLine(a);

                assdqffq.Add(JsonConvert.DeserializeObject<TGButtonsJS>(a));
                assdqffq.Last().Teg = tag;
                buttons.Add(SetTegs(assdqffq.Last(), tag));
            }

            TGButton tGButton = new TGButton();
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].Teg == "aaa")
                {
                    tGButton = buttons[i];
                    buttons.Remove(buttons[i]);
                }
            }


            while (buttons.Count != 0)
            {
                int e = 0;
                while (e < buttons.Count)
                {
                    TGButton tGBuferButton = itemsOperator.GetTGbuttonByTeg(buttons[e].ParentTeg, tGButton);
                    if (tGBuferButton != null)
                    {
                        tGBuferButton.TGСhildMenu.Add(buttons[e]);
                        buttons.Remove(buttons[e]);
                    }
                    e++;
                }
            }

            foreach (TGButtonsJS button in assdqffq)
            {
                if (button.Buttons != null)
                {
                    string bu = button.Buttons.ToString();
                    List<string> g = bu.Substring(1, bu.Length - 3).Trim().Split('"').ToList();
                    g.RemoveAll(gg => gg == "" || gg == ": " || gg == ",\r\n  ");

                    for (int i = 0; i < g.Count; i += 2)
                    {
                        itemsOperator.GetTGbuttonByTeg(g[i], tGButton).Title = g[i + 1];
                    }
                }
                if (button.urlButtons != null)
                {
                    string bu = button.urlButtons.ToString();
                    List<string> g = bu.Substring(1, bu.Length - 3).Trim().Split('"').ToList();
                    g.RemoveAll(gg => gg == "" || gg == ": " || gg == ",\r\n  ");
                    for (int i = 0; i < g.Count; i += 2)
                    {
                        itemsOperator.GetTGbuttonByTeg(button.Teg, tGButton).TGСhildMenu.Add(new TGButton()
                        {
                            Teg = "УБРАТЬ!!!!!!!",
                            Title = g[i + 1],
                            HasUrl = true,
                            Url = new Uri(g[i])
                        });

                    }


                    Console.WriteLine(g);

                }
            }

            return tGButton;

        }

        static TGButton SetTegs(TGButtonsJS tGButtonsJS, string Teg)
        {
            string letters = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            TGButton button = new TGButton();
            button.Teg = Teg;
            foreach (var item in Teg.ToCharArray())
            {
                button.IntTeg += letters.IndexOf(item);
            }


            button.ParentTeg = tGButtonsJS.Parent;
            button.TextOfMenu = tGButtonsJS.Text;

            return button;
        }








    }
}
