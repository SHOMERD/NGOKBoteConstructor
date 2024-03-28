using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace NGOKBoteConstructor.Models
{
    public class TGButton
    {
        public string Teg { get; set; }
        public int IntTeg { get; set; }

        public string ParentTeg { get; set; }

        public string Title { get; set; }
        public String TextOfMenu { get; set; }

        public bool СhildCanBeOnliUrl { get; set; }
        public bool HasUrl { get; set; }
        public Uri Url { get; set; }

        public List<TGButton> TGСhildMenu { get; set; } = new List<TGButton>();

    }
}