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

        public int TipeOfItem { get; set; }

        public bool UnytitletBoolParametr {  get; set; }
        public Uri Url { get; set; }


        public TGMenu TGСhildMenu { get; set; } // ore public List<TGButtons> TGСhildButtons    ore  public List<Uri> TGСhildUriOfMenu

    }
}
