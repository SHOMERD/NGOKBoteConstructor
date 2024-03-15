using Newtonsoft.Json;
using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace NGOKBoteConstructor.logics
{
    public class RecuestConsrtuktor
    {

        public static async void CreateJsonFile(TGButton tGButton)
        {
            string jsonPosition = CreateFile(CreateJsonString2(tGButton));
            if (await Application.Current.MainPage.DisplayAlert("Файл сохрнен", $"\tПуть к файлу:\n{jsonPosition}  \n\tФайл:\nNGOKBoteStructure.json", "Скапировать расположение файла", "ок"))
            {
                await Clipboard.SetTextAsync(jsonPosition);
            }
            


        }


        static string CreateFile(string JsonString)
        {
            string FileNameString = $"NGOKBoteStructure.json";
   
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            File.WriteAllText(Path.Combine(folderPath, FileNameString), JsonString);
            return folderPath;
    
        }



        static string CreateJsonString(TGButton tGButton)
        {
            if (tGButton.HasUrl)
            {
                return null;
            }

            string JsonString = "";

            JsonString += $"{JsonConvert.SerializeObject(tGButton.Teg)} ";
            JsonString += ": { ";
            JsonString += $"\"Recursive\": {(tGButton.IsRecursiveButton.ToString()).ToLower()}, \"callbacks\": [";

            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                JsonString += $"{JsonConvert.SerializeObject(tGButton.TGСhildMenu[i].Teg)}";
                if (i != tGButton.TGСhildMenu.Count - 1)
                {
                    JsonString += ",";
                }
            }

            JsonString += "],";

            

            JsonString += "\"ButtonName\": [ ";

            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                JsonString += $"{JsonConvert.SerializeObject(tGButton.TGСhildMenu[i].Title)}";
                if (i != tGButton.TGСhildMenu.Count - 1)
                {
                    JsonString += ",";
                }
            }
            JsonString += "],";



            JsonString += "\"Additional_Buttons\" : {";

            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                JsonString += $"{JsonConvert.SerializeObject(tGButton.TGСhildMenu[i].Teg)} : ";
                if (tGButton.TGСhildMenu[i].TGСhildMenu.Count == 0)
                {
                    JsonString += "null";
                }
                else
                {
                    JsonString += "[ ";
                    for (int l = 0; l < tGButton.TGСhildMenu[i].TGСhildMenu.Count; l++)
                    {
                        JsonString += "[ ";
                        JsonString += $"{JsonConvert.SerializeObject(tGButton.TGСhildMenu[i].TGСhildMenu[l].Title)}, ";
                        JsonString += $"{JsonConvert.SerializeObject(tGButton.TGСhildMenu[i].TGСhildMenu[l].Url)} ";
                        JsonString += "]";
                        if (l != tGButton.TGСhildMenu[i].TGСhildMenu.Count - 1)
                        {
                            JsonString += ",";
                        }

                    }
                    JsonString += "]";
                }
                if (i != tGButton.TGСhildMenu.Count - 1)
                {
                    JsonString += ", ";
                }
            }
            JsonString += "}, ";
            JsonString += "\"Text\": { ";
            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                JsonString += $"{JsonConvert.SerializeObject(tGButton.TGСhildMenu[i].Teg)}: ";
                JsonString += JsonConvert.SerializeObject(tGButton.TGСhildMenu[i].TextOfMenu);
                if (i != tGButton.TGСhildMenu.Count - 1)
                {
                    JsonString += ", ";
                }
            }
            JsonString += "}  },";


            return JsonString;


        }

        static string CreateJsonString23(TGButton tGButton)
        {
            string JsonString = "";
            string d = CreateJsonString(tGButton);
            if (d != null)
            {
                JsonString += "\n";
                JsonString += d;
                JsonString += "\n";
            }
            

            for (int D = 0; D < tGButton.TGСhildMenu.Count; D++)
            {
                if (tGButton.TGСhildMenu[D].Url == null)
                {
                    JsonString += CreateJsonString23(tGButton.TGСhildMenu[D]);
                }
            }


            return JsonString;



        }

        static string CreateJsonString2(TGButton tGButton)
        {
            string JsonString = "";
            JsonString += "{ ";
            JsonString += CreateJsonString23(tGButton);
            JsonString = JsonString.Substring(0, JsonString.Length-2);
            JsonString += "\n";
            JsonString += "} ";



            return JsonString;



        }

    }
}






