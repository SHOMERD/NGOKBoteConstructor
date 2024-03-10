using Newtonsoft.Json;
using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace NGOKBoteConstructor.logics
{
    public class RecuestConsrtuktor
    {

        public static void CreateJsonFile(TGButton tGButton)
        {
            Application.Current.MainPage.DisplayAlert("Файл сохрнен", $"Файл: {CreateFile(CreateJsonString(tGButton))}", "ок");

        }


        static string CreateFile(string JsonString)
        {

            string FileNameString = $"waiwai.json";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            File.WriteAllText(Path.Combine(folderPath, FileNameString), JsonString);
            return folderPath + "\\" + FileNameString;
        }



        static string CreateJsonString(TGButton tGButton)
        {

            string JsonString = "";

            JsonString += "{ ";
            JsonString += $"\"{tGButton.Teg}\" ";
            JsonString += ": { ";
            JsonString += $"\"Recursive\": {(tGButton.IsHasRebcursiveButtons.ToString()).ToLower()}, \"callbacks\": [";

            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                JsonString += $"\"{tGButton.TGСhildMenu[i].Teg}\"";
                if (i != tGButton.TGСhildMenu.Count - 1)
                {
                    JsonString += ",";
                }
            }

            JsonString += "],";
            JsonString += "\"text\": [ ";

            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                JsonString += $"\"{tGButton.TGСhildMenu[i].Title}\"";
                if (i != tGButton.TGСhildMenu.Count-1)
                {
                    JsonString += ",";
                }
            }

            JsonString += "],";
            JsonString += "\"additional_button\" : [";

            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                JsonString += $"[ {(tGButton.TGСhildMenu[i].IsHasRebcursiveButtons.ToString()).ToLower()}, ";
                if (!tGButton.TGСhildMenu[i].IsHasRebcursiveButtons || tGButton.TGСhildMenu[i].RecursiveButtons.Count == 0)
                {
                    JsonString += "null ";
                }
                else
                {
                    if (tGButton.TGСhildMenu[i].RecursiveButtons.Count == 1)
                    {
                        JsonString += $"\"{tGButton.TGСhildMenu[i].RecursiveButtons[0].Title}\",";
                        JsonString += $"\"{tGButton.TGСhildMenu[i].RecursiveButtons[0].Url}\" ";
                    }else
                    {
                        for (int w = 0; w < tGButton.TGСhildMenu[i].RecursiveButtons.Count; w++)
                        {
                            JsonString += "[ ";
                            JsonString += $"\"{tGButton.TGСhildMenu[i].RecursiveButtons[w].Title}\",";
                            JsonString += $"\"{tGButton.TGСhildMenu[i].RecursiveButtons[w].Url}\" ";
                            JsonString += $"]";
                            if (w != tGButton.TGСhildMenu[i].RecursiveButtons.Count-1)
                            {
                                JsonString += ",";
                            }
                        }
                    }
                }

                if (i != tGButton.TGСhildMenu.Count - 1)
                {
                    JsonString += "],";
                }

            }
            JsonString += "] ] } }";


            return JsonString;


        }
    }


}

