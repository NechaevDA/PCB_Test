using PCB_Test.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.DataProvider.Interfaces
{
    public interface IDataProvider
    {
        List<Component> GetAllComponents();
        List<MaskColor> GetAllMaskColors();
        List<Material> GetAllMaterials();
    }
}
