using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.Models
{
    public class ComponentSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Component> Components { get; set; }
    }
}
