using System;
using System.Collections.Generic;
using System.Text;

namespace NGOKBoteConstructor.Models
{
    public class TGMenu
    {
        public string ItemName { get; set; }
        public Uri OwnUrel { get; set; }
        public List<TGButton> tGButtons { get; set;}
    }
}
