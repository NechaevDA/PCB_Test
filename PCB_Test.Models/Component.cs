using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public double TimeToInstall { get; set; }
    }
}
