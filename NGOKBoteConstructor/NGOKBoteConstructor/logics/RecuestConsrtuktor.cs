using Newtonsoft.Json;
using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Shapes;

namespace NGOKBoteConstructor.logics
{
    public class RecuestConsrtuktor
    {

        public static async void CreateJsonFile(TGButton tGButton)
        {

            string jsonPosition = await CreateFile(CreateJsonString(tGButton));
            if (jsonPosition != null)
            {
                if (await Application.Current.MainPage.DisplayAlert("Файл сохранен", $"\tПуть к файлу:\n{jsonPosition}  \n\tФайл:\nNGOKBoteStructure.json", "Открыть папку с файлом", "ок"))
                {
                    DependencyService.Get<IFileManager>().OpenExplorerAsync(jsonPosition);
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Файл не сохранен", $"Выбранная папка не подходит", "ок");
            }




        }


        static async Task<string> CreateFile(string JsonString)
        {
            string folderPath = await DependencyService.Get<IFileManager>().SaveJsonFile(JsonString);

            return folderPath;
    
        }



        static string GetTGButtonJsonString(TGButton tGButton)
        {
            if (tGButton.HasUrl)
            {
                return "";
            }

            string JsonString = "";


            JsonString += $"{JsonConvert.SerializeObject(tGButton.Teg)} ";
            JsonString += ": {";
            JsonString += $"\"Parent\" : ";
            JsonString += $"{JsonConvert.SerializeObject(tGButton.ParentTeg)} , ";
            JsonString += $"\"Text\" : {JsonConvert.SerializeObject(tGButton.TextOfMenu)}, ";
            JsonString += "\"Buttons\" : ";
            JsonString += GetСhildButtonsSting(tGButton, false);
            JsonString += ", ";
            JsonString += "\"urlButtons\" : ";
            JsonString += GetСhildButtonsSting(tGButton, true);
            JsonString += " ";
            JsonString += " },";

            return JsonString;


        }

        static string GetJsonStringRercursive(TGButton tGButton)
        {
            string JsonString = "";
            string d = GetTGButtonJsonString(tGButton);
            if (d != null)
            {
                JsonString += "\n";
                JsonString += d;
                JsonString += "\n";
            }


            if (!tGButton.СhildCanBeOnliUrl)
            {
                for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
                {
                    if (!tGButton.TGСhildMenu[i].HasUrl)
                    {
                        JsonString += GetJsonStringRercursive(tGButton.TGСhildMenu[i]);
                    }
                }
            }
            

            return JsonString;
        }



        static string CreateJsonString(TGButton tGButton)
        {
            string JsonString = "";
            JsonString += "{ ";
           
            JsonString += GetJsonStringRercursive(tGButton);


            JsonString = JsonString.Substring(0, JsonString.Length-2);
            JsonString += "\n";
            JsonString += "} ";



            return JsonString;



        }

        static string GetСhildButtonsSting(TGButton tGButton, bool GetUrl)
        {
            string JsonString = "";
            List<TGButton> tGButtons = new List<TGButton>();

            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                if (tGButton.СhildCanBeOnliUrl == tGButton.TGСhildMenu[i].HasUrl && tGButton.СhildCanBeOnliUrl == GetUrl)
                {
                    tGButtons.Add(tGButton.TGСhildMenu[i]);
                }
            }
            



            if (tGButtons.Count == 0)
            {
                JsonString += "null";
            }
            else
            {
                JsonString += "{ ";
                for (int i = 0; i < tGButtons.Count; i++)
                {
                   
                    if (!GetUrl)
                    {
                        JsonString += $"\"{tGButtons[i].Teg}\" ";
                    }else
                    {
                        JsonString += $"\"{tGButtons[i].Url}\" ";
                    }
                    JsonString += $": \"{tGButtons[i].Title}\"";                    
                    if (i != tGButtons.Count - 1)
                    {
                        JsonString += ", ";
                    }
                }
                JsonString += "} ";
            }
            return JsonString;
        }

    }
}






