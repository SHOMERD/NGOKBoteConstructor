using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace NGOKBoteConstructor.Models
{
    public class TGButton  /// ore TGItem
    {
        public string Teg { get; set; }
        public string Title { get; set; }

        //public bool  {  get; set; } дом кнопка с сылкой 

        public String TextOfMenu { get; set; }

        public bool HasUrl { get; set; }
        public Uri Url { get; set; }

        public bool IsRecursiveButton { get; set; }


        public List<TGButton> TGСhildMenu { get; set; } = new List<TGButton>();

    }
}
