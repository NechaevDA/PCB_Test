using CommunityToolkit.Mvvm.ComponentModel;
using PCB_Test.UI.Helpers;
using PCB_Test.UI.ViewModels.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media;

namespace PCB_Test.UI.ViewModels
{
    public class GraphicRepresentationViewModel : ObservableObject, IDisposable
    {
        public IEnumerable<GraphicDisplayEntry> _diagramEntries;
        public IEnumerable<GraphicDisplayEntry> DiagramEntries
        {
            get { return _diagramEntries; }
            set { SetProperty(ref _diagramEntries, value); }
        }
        public OrderViewModel Model { get; }

        public GraphicRepresentationViewModel(OrderViewModel model)
        {
            Model = model;
            Model.PropertyChanged += OnModelChanged;
            UpdateDiagramEntries();
        }

        private void OnModelChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateDiagramEntries();
        }

        private void UpdateDiagramEntries()
        {

            DiagramEntries = new List<GraphicDisplayEntry>
            {
                new GraphicDisplayEntry("Preferences impact", Model.Model.DimensionsTimeImpact(), Colors.Orange),
                new GraphicDisplayEntry("Components impact", Model.Model.ComponentsTimeImpact(), Colors.CadetBlue),
            };
        }

        public void Dispose()
        {
            Model.PropertyChanged -= OnModelChanged;
        }
    }
}
