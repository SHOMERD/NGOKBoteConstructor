using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms.Internals;

namespace NGOKBoteConstructor.Models
{
    public class TGButton : IComparable
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

        public int CompareTo(object obj)
        {
            if ((obj == null) || (!(obj is TGButton)))
                return 0;
            else
                return string.Compare(Teg, ((TGButton)obj).Teg);
        }

    }
}