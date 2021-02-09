using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Collections.Generic;
using System.Windows;

namespace sample_04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var width = e.Info.Width;
            var height = e.Info.Height;

            var c = new Chart() { HorizontalDivisons = 5 };
            //c.Series = new List<double>() { 1.2, 5.4, 3.13, 0.5, 7.1, 4.1 };
            c.Series = new List<double>() { 1, 3, 2, 4 };

            var rect = new SKRect(10, 10, width - 20, height - 20);
            canvas.Clear(SKColors.White);

            c.draw(canvas, rect);
        }
    }
}
