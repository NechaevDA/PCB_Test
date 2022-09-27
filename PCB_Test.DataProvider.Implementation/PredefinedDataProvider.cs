using PCB_Test.DataProvider.Interfaces;
using PCB_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCB_Test.DataProvider.Implementation
{
    public class PredefinedDataProvider : IDataProvider
    {
        private List<Material> Materials { get; }
        private List<MaskColor> MaskColors { get; }
        private List<Component> Components { get; }

        public PredefinedDataProvider()
        {
            Materials = new List<Material>();
            MaskColors = new List<MaskColor>();
            Components = new List<Component>();

            InitValues();
        }

        private void InitValues()
        {
            Materials.Add(new Material
            {
                Name = "Cardboard",
                TimeCost = 0.5,
                Cost = 0.1
            });
            Materials.Add(new Material
            {
                Name = "Metal",
                TimeCost = 2,
                Cost = 10
            });
            Materials.Add(new Material
            {
                Name = "Phenolic paper",
                TimeCost = 1,
                Cost = 1
            });
            Materials.Add(new Material
            {
                Name = "Kapton",
                TimeCost = 5,
                Cost = 12
            });

            MaskColors.Add(new MaskColor
            {
                Name = "Green",
                R = 0x00,
                G = 0xff,
                B = 0x00
            });
            MaskColors.Add(new MaskColor
            {
                Name = "Blue",
                R = 0x00,
                G = 0x00,
                B = 0xff
            });
            MaskColors.Add(new MaskColor
            {
                Name = "Red",
                R = 0xff,
                G = 0x00,
                B = 0x00
            });

            Components.Add(new Component
            {
                Name = "LED",
                Cost = 0.1,
                TimeToInstall = 0.2
            });
            Components.Add(new Component
            {
                Name = "1 KOhm resistor",
                Cost = 0.5,
                TimeToInstall = 0.3
            });
            Components.Add(new Component
            {
                Name = "Microchip ATTINY2313",
                Cost = 3,
                TimeToInstall = 1.5
            });
            Components.Add(new Component
            {
                Name = "Chip 74HC595",
                Cost = 1,
                TimeToInstall = 1
            });
        }

        public List<Material> GetAllMaterials()
        {
            return Materials.OrderBy(x => x.Cost).ToList();
        }

        public List<MaskColor> GetAllMaskColors()
        {
            return MaskColors;
        }

        public List<Component> GetAllComponents()
        {
            return Components.OrderBy(x => x.Cost).ToList();
        }
    }
}
