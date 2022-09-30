using PCB_Test.UI.ViewModels.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PCB_Test.UI.Controls
{
    class RatioDisplay : Canvas
    {
        private const double RECT_HEIGHT = 20;

        private IEnumerable<GraphicDisplayEntry> Data => (IEnumerable<GraphicDisplayEntry>)DataContext;
        private Border[] Rectangles;

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.Name == nameof(DataContext))
                Refresh();

            base.OnPropertyChanged(e);
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            Update();
        }

        protected virtual void Refresh()
        {
            this.Children.Clear();
            if (Data != null)
            {
                Rectangles = new Border[Data.Count()];
                Draw();
            }            
        }

        private void Draw()
        {
            var dataCounter = 0;

            var availableWidth = ActualWidth;
            var valuesTotal = Data.Sum(x => x.Value);

            foreach (var entry in Data)
            {
                var rect = new Border();
                rect.Height = RECT_HEIGHT;
                rect.Width = entry.Value / valuesTotal * availableWidth;
                rect.BorderThickness = new Thickness(1);
                rect.BorderBrush = entry.Color;
                rect.Background = entry.Color;

                if (dataCounter == 0)
                {
                    rect.CornerRadius = new CornerRadius(5, 0, 0, 5);
                } else if (dataCounter == Data.Count() - 1)
                {
                    rect.CornerRadius = new CornerRadius(0, 5, 5, 0);
                }

                SetLeft(rect, Rectangles.Take(dataCounter).Sum(x => x.Width));
                SetTop(rect, 0);
                this.Children.Add(rect);
                Rectangles[dataCounter] = rect;
                dataCounter++;
            }
        }

        private void Update()
        {
            if (Data == null)
                return;

            var dataCounter = 0;

            var availableWidth = ActualWidth;
            var valuesTotal = Data.Sum(x => x.Value);

            foreach (var entry in Data)
            {
                var rect = Rectangles[dataCounter];
                rect.Width = entry.Value / valuesTotal * availableWidth;
                SetLeft(rect, Rectangles.Take(dataCounter).Sum(x => x.Width));
                SetTop(rect, 0);
                dataCounter++;
            }
        }
    }
}
