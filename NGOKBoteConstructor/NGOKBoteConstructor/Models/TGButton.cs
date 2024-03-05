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


        public bool IsHasRebcursiveButtons { get; set; }
        public List<TGButton> RecursiveButtons { get; set; } = new List<TGButton>();

        public string Col { get; set; }

        public List<TGButton> TGСhildMenu { get; set; } = new List<TGButton>();

    }
}
