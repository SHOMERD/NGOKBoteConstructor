using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace NGOKBoteConstructor.Models
{
    public class TGMenu
    {
        public string ItemName { get; set; }
        public string Text { get; set; }
        public Uri OwnUrel { get; set; }
        public GIFBitmap Bitmap { get; set; }
        public List<TGButton> tGButtons { get; set;}
    }
}
