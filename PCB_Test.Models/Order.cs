using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.Models
{
    public class Order
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public int LayerCount { get; set; }
        public int Quantity { get; set; }
        public Material Material { get; set; }
        public MaskColor MaskColor { get; set; }
        public List<Component> Components { get; set; }
    }
}
