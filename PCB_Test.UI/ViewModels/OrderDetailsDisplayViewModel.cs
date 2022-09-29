using PCB_Test.Models;
using PCB_Test.UI.Helpers;
using PCB_Test.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace PCB_Test.UI.ViewModels
{
    class OrderDetailsDisplayViewModel
    {
        public ObservableCollection<OrderDetailsEntry> DetailsEntries { get; }
        public ICollectionView EntriesView { get; }

        public OrderDetailsDisplayViewModel(Order model)
        {
            DetailsEntries = new ObservableCollection<OrderDetailsEntry>();
            ProcessModel(model);

            EntriesView = new ListCollectionView(DetailsEntries);
            EntriesView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(OrderDetailsEntry.Category)));
        }

        private void ProcessModel(Order model)
        {
            DetailsEntries.Add(new OrderDetailsEntry
            {
                Category = OrderDetailsCategory.General,
                Title = "Dimensions",
                Value = $"{model.Width} x {model.Height} mm",
                TimeImpact = model.DimensionsTimeImpact(),
                Cost = model.ComponentsCostImpact()
            });
            DetailsEntries.Add(new OrderDetailsEntry
            {
                Category = OrderDetailsCategory.General,
                Title = "Quantity",
                Value = model.Quantity.ToString(),
                TimeImpact = model.DimensionsTimeImpact() * model.Quantity,
                Cost = model.ComponentsCostImpact() * model.Quantity
            });

            DetailsEntries.Add(new OrderDetailsEntry
            {
                Category = OrderDetailsCategory.Preferences,
                Title = "Material",
                Value = model.Material.Name,
                Cost = model.Material.Cost,
                TimeImpact = model.Material.TimeCost
            });
            DetailsEntries.Add(new OrderDetailsEntry
            {
                Category = OrderDetailsCategory.Preferences,
                Title = "Mask color",
                Value = model.MaskColor.Name
            });

            foreach (var componentGroup in model.ComponentSet.Components.GroupBy(x => x.Id))
            {
                DetailsEntries.Add(new OrderDetailsEntry
                {
                    Category = OrderDetailsCategory.Components,
                    Title = componentGroup.First().Name,
                    Value = componentGroup.Count().ToString(),
                    Cost = componentGroup.Sum(x => x.Cost),
                    TimeImpact = componentGroup.Sum(x => x.TimeToInstall)
                });
            }
        }
    }
}
