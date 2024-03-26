using Newtonsoft.Json;
using NGOKBoteConstructor.logics;
using NGOKBoteConstructor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine();
        }

        public void SaveJsonFile(string x)
        {
            throw new NotImplementedException();
        }

    }
}
