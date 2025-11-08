using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssQ2.Models
{
    public class Book
    {
        public int bid { get; set; }
        public string bname { get; set; }
        public int aid { get; set; }
        public int price { get; set; }
        public int pub_year { get; set; }
    }
}