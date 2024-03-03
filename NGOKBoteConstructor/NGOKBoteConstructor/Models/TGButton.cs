using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace NGOKBoteConstructor.Models
{
    public class TGButton  /// ore TGItem
    {
        public string ItemName { get; set; }
        public string Title { get; set; }

        //public bool  {  get; set; } дом кнопка с сылкой 

        public String TextOfMenu { get; set; }


        public bool IsHasRebcursiveButtons { get; set; }
        List<TGButton> RecursiveButtons { get; set; }

        public string Col { get; set; } // ore public List<TGButtons> TGСhildButtons    ore  public List<Uri> TGСhildUriOfMenu

    }
}
