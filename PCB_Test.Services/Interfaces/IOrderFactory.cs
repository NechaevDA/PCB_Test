using PCB_Test.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.Services.Interfaces
{
    public interface IOrderFactory
    {
        Order BuildDefaultOrder(string name = "Order");
    }
}
