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
                itemsOperator.SeveStats();
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

            JToken ButtonsAsJToken = JsonConvert.DeserializeObject<JToken>(JsonString);
            var ButtonsAsJTokenList = ButtonsAsJToken.Children();

            List<TGButton> buttons = new List<TGButton>();
            List<TGButtonsJS> buttonsJS = new List<TGButtonsJS>();

            foreach (var item in ButtonsAsJTokenList)
            {
                string tag = item.Path;

                string itemString = item.ToString();
                itemString = itemString.Substring(itemString.IndexOf(": {") + 2);

                buttonsJS.Add(JsonConvert.DeserializeObject<TGButtonsJS>(itemString));
                buttonsJS.Last().Teg = tag;
                buttons.Add(SetButtonTags(buttonsJS.Last(), tag));
                buttons.Last().СhildCanBeOnliUrl = false;
                if (buttonsJS.Last().urlButtons != null)
                {
                    buttons.Last().СhildCanBeOnliUrl = true;
                }

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
                int i = 0;
                while (i < buttons.Count)
                {
                    TGButton tGBuferButton = itemsOperator.GetTGbuttonByTeg(buttons[i].ParentTeg, tGButton);
                    if (tGBuferButton != null)
                    {
                        tGBuferButton.TGСhildMenu.Add(buttons[i]);
                        buttons.Remove(buttons[i]);
                    }
                    i++;
                }
            }


            foreach (TGButtonsJS button in buttonsJS)
            {

                if (button.Buttons != null)
                {
                    string buttonStriong = button.Buttons.ToString();
                    List<string> ChildButons = buttonStriong.Substring(1, buttonStriong.Length - 3).Trim().Split('"').ToList();
                    ChildButons.RemoveAll(gg => gg == "" || gg == ": " || gg == ",\r\n  ");

                    for (int i = 0; i < ChildButons.Count; i += 2)
                    {
                        itemsOperator.GetTGbuttonByTeg(ChildButons[i], tGButton).Title = ChildButons[i + 1];
                    }
                }
                if (button.urlButtons != null)
                {

                    string buttonStriong = button.urlButtons.ToString();
                    List<string> ChildUrlButons = buttonStriong.Substring(1, buttonStriong.Length - 3).Trim().Split('"').ToList();
                    ChildUrlButons.RemoveAll(gg => gg == "" || gg == ": " || gg == ",\r\n  ");
                    for (int i = 0; i < ChildUrlButons.Count; i += 2)
                    {
                        int intTeg = itemsOperator.GetEmptyTeg(tGButton);
                        itemsOperator.GetTGbuttonByTeg(button.Teg, tGButton).TGСhildMenu.Add(new TGButton()
                        {
                            Teg = itemsOperator.SetTeg(intTeg),
                            IntTeg = intTeg,
                            Title = ChildUrlButons[i + 1],
                            HasUrl = true,
                            Url = new Uri(ChildUrlButons[i])
                        });

                    }

                }
            }
            sortRerck(tGButton);

            return tGButton;

        }

        static void sortRerck(TGButton tGButton)
        {
            tGButton.TGСhildMenu.Sort();
            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                sortRerck(tGButton.TGСhildMenu[i]);
            }

        }


        static TGButton SetButtonTags(TGButtonsJS tGButtonsJS, string Teg)
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
