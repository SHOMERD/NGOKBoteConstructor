using System;
using System.Collections.Generic;
using System.Text;

namespace NGOKBoteConstructor.Models
{
    internal class RequestModel
    {
        public Stud Stud { get; set; }
    }

    public class Stud
    {
        public bool Recursive { get; set; }
        public List<string> callbacks { get; set; }
        public List<string> text { get; set; }
        public List<List<object>> additional_button { get; set; }
    }


}
