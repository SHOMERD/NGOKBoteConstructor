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
            Application.Current.MainPage.DisplayAlert("Файл сохрнен", $"Файл: {CreateFile(CreateJsonString2(tGButton))}", "ок");

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

            

            JsonString += "\"ButtonName\": [ ";

            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                JsonString += $"\"{tGButton.TGСhildMenu[i].Title}\"";
                if (i != tGButton.TGСhildMenu.Count - 1)
                {
                    JsonString += ",";
                }
            }
            JsonString += "],";



            JsonString += "\"Additional_Buttons\" : {";

            for (int i = 0; i < tGButton.TGСhildMenu.Count; i++)
            {
                JsonString += $"\"{tGButton.TGСhildMenu[i].Teg}\" : ";
                if (tGButton.TGСhildMenu[i].TGСhildMenu.Count == 0)
                {
                    JsonString += "null";
                }
                else if (tGButton.TGСhildMenu[i].TGСhildMenu.Count == 1)
                {
                    JsonString += "[ ";
                    JsonString += $"\"{tGButton.TGСhildMenu[i].TGСhildMenu[0].Title}\", ";
                    JsonString += $"\"{tGButton.TGСhildMenu[i].TGСhildMenu[0].Url}\" ";
                    JsonString += "]";
                }
                else
                {
                    JsonString += "[ ";
                    for (int l = 0; l < tGButton.TGСhildMenu[i].TGСhildMenu.Count; l++)
                    {
                        JsonString += "[ ";
                        JsonString += $"\"{tGButton.TGСhildMenu[i].TGСhildMenu[l].Title}\", ";
                        JsonString += $"\"{tGButton.TGСhildMenu[i].TGСhildMenu[l].Url}\" ";
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
                JsonString += $"\"{tGButton.TGСhildMenu[i].Teg}\": ";
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
            JsonString += "\n";
            JsonString += CreateJsonString(tGButton);
            JsonString += "\n";


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






