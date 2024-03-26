using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NGOKBoteConstructor.logics
{
    public interface IFileManager
    {
        Task<StreamReader> GetJsonFile();
        void SaveJsonFile(string Jsonstring);

    }
}
