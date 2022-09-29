using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.UI.Models
{
    class OrderDetailsEntry
    {
        public OrderDetailsCategory Category { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public double? TimeImpact { get; set; }
        public double? Cost { get; set; }
    }
}
