using Newtonsoft.Json;
using NGOKBoteConstructor.logics;
using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;

[assembly: Dependency(typeof(NGOKBoteConstructor.UWP.FileManager))]
namespace NGOKBoteConstructor.UWP
{
    
    public class FileManager : IFileManager
    {
        public async Task<StreamReader> GetJsonFile()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Downloads;
            picker.FileTypeFilter.Add(".json");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            return new StreamReader(await file.OpenStreamForReadAsync());
            
        }

        public async void jsonAnaliser(Windows.Storage.StorageFile storageFile)
        {
            string JsonString = await Windows.Storage.FileIO.ReadTextAsync(storageFile); 
            object tGButton = JsonConvert.DeserializeObject<object>(JsonString);
        }


        public async Task<string> SaveJsonFile(string x)
        {
            var picker = new Windows.Storage.Pickers.FolderPicker();
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            picker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder storageFolder = await picker.PickSingleFolderAsync();


            if (storageFolder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", storageFolder);
                Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("NGOKBoteStructure.json", Windows.Storage.CreationCollisionOption.ReplaceExisting);

                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, x);
                return storageFolder.Path;


            }else
            {
                return "fail";
            }



        }

        public void OpenExplorer(string path)
        {
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "C:\\Windows\\explorer.exe";
            proc.Start();
        }

    }
}
