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
        private List<ComponentSet> ComponentSets { get; }

        public PredefinedDataProvider()
        {
            Materials = new List<Material>();
            MaskColors = new List<MaskColor>();
            Components = new List<Component>();
            ComponentSets = new List<ComponentSet>();

            InitValues();
        }

        private void InitValues()
        {
            Materials.Add(new Material
            {
                Id = 1,
                Name = "Cardboard",
                TimeCost = 0.5,
                Cost = 0.1
            });
            Materials.Add(new Material
            {
                Id = 2,
                Name = "Metal",
                TimeCost = 2,
                Cost = 10
            });
            Materials.Add(new Material
            {
                Id = 3,
                Name = "Phenolic paper",
                TimeCost = 1,
                Cost = 1
            });
            Materials.Add(new Material
            {
                Id = 4,
                Name = "Kapton",
                TimeCost = 5,
                Cost = 12
            });

            MaskColors.Add(new MaskColor
            {
                Id = 1,
                Name = "Green",
                R = 0x00,
                G = 0xff,
                B = 0x00
            });
            MaskColors.Add(new MaskColor
            {
                Id = 2,
                Name = "Blue",
                R = 0x00,
                G = 0x00,
                B = 0xff
            });
            MaskColors.Add(new MaskColor
            {
                Id = 3,
                Name = "Red",
                R = 0xff,
                G = 0x00,
                B = 0x00
            });
            MaskColors.Add(new MaskColor
            {
                Id = 4,
                Name = "Other",
                R = 0xfc,
                G = 0xa0,
                B = 0x0a
            });

            Components.Add(new Component
            {
                Id = 1,
                Name = "LED",
                Cost = 0.1,
                TimeToInstall = 0.2
            });
            Components.Add(new Component
            {
                Id = 2,
                Name = "1 KOhm resistor",
                Cost = 0.5,
                TimeToInstall = 0.3
            });
            Components.Add(new Component
            {
                Id = 3,
                Name = "Microchip ATTINY2313",
                Cost = 3,
                TimeToInstall = 1.5
            });
            Components.Add(new Component
            {
                Id = 4,
                Name = "Chip 74HC595",
                Cost = 1,
                TimeToInstall = 1
            });

            var componentsDictionary = Components.ToDictionary(x => x.Id);

            ComponentSets.Add(new ComponentSet
            {
                Id = 1,
                Name = "Set 1",
                Components = new List<Component>
                {
                    componentsDictionary[1],
                    componentsDictionary[2]
                }
            });

            ComponentSets.Add(new ComponentSet
            {
                Id = 2,
                Name = "Set 2",
                Components = Enumerable.Repeat(componentsDictionary[1], 8)
                      .Concat(Enumerable.Repeat(componentsDictionary[2], 8))
                      .Concat(new[] { componentsDictionary[3], componentsDictionary[4] })
                      .ToList()
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

        public List<ComponentSet> GetComponentSets()
        {
            return ComponentSets;
        }
    }
}
