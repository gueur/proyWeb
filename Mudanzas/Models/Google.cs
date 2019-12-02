using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models
{
    public class Google
    {
     
        public dynamic destination_addresses { get; set; }
        public dynamic origin_addresses { get; set; }
        public List<Row> rows { get; set; }
        public string status { get; set; }
    }

    public class Row
    {
        public List<Element> elements { get; set; }
    }

    public class Element
    {
        public Item distance { get; set; }
        public Item duration { get; set; }
        public string status { get; set; }

    }
    public class Item
    {
        public string text { get; set; }
        public int value { get; set; }
    }
}
