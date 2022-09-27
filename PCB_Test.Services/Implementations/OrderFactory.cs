using PCB_Test.DataProvider.Interfaces;
using PCB_Test.Models;
using PCB_Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCB_Test.Services.Implementations
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IDataProvider _dataProvider;

        public OrderFactory(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public Order BuildDefaultOrder(string name = "Order")
        {
            return new Order
            {
                Name = name,
                Height = 10,
                Width = 10,
                LayerCount = 1,
                Quantity = 1,
                Components = new List<Component>(),
                MaskColor = _dataProvider.GetAllMaskColors().FirstOrDefault(),
                Material = _dataProvider.GetAllMaterials().FirstOrDefault()                
            };
        }
    }
}
