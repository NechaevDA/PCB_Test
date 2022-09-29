using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.Models
{
    public class Material
    {
        public int Id { get; set; }
        /// <summary>
        /// Material Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Cost per sq. mm.
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// Time coefficient
        /// </summary>
        public double TimeCost { get; set; }
    }
}
