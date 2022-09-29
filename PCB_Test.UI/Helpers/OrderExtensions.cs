using PCB_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCB_Test.UI.Helpers
{
    internal static class OrderExtensions
    {
        public static double DimensionsTimeImpact(this Order order) => order.Material.TimeCost * (2 * (order.Height + order.Width));
        public static double DimensionsCostImpact(this Order order) => order.Height * order.Width * order.Material.Cost;
        public static double ComponentsCostImpact(this Order order) => order.ComponentSet.Components.Sum(x => x.Cost);
        public static double ComponentsTimeImpact(this Order order) => order.ComponentSet.Components.Sum(x => x.TimeToInstall);
    }
}
