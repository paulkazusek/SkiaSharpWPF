using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Windows;

namespace sample_02
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
            // the canvas and properties
            var canvas = e.Surface.Canvas;
            var width = e.Info.Width;
            var height = e.Info.Height;

            // get the screen density for scaling
            var scale = (float)PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice.M11;
            var scaledSize = new SKSize(e.Info.Width / scale, e.Info.Height / scale);

            // handle the device screen density
            canvas.Scale(scale);

            // make sure the canvas is blank
            canvas.Clear(SKColors.White);

            SKPaint paintLine = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                IsAntialias = true,
                Color = SKColors.Red,
                StrokeWidth = 30,
                StrokeCap = SKStrokeCap.Butt,
                StrokeJoin = SKStrokeJoin.Bevel
            };

            SKSize canvasSize = new SKSize(width, height);

            SKPoint pointleft = new SKPoint(canvasSize.Width / 2f - 100, canvasSize.Height / 2);
            SKPoint pointright = new SKPoint(canvasSize.Width / 2f + 100, canvasSize.Height / 2);
            SKPoint pointtop = new SKPoint(canvasSize.Width / 2f, canvasSize.Height / 2 - 100);
            SKPoint pointbottom = new SKPoint(canvasSize.Width / 2f, canvasSize.Height / 2 + 100);

            canvas.DrawLine(pointleft, pointright, paintLine);
            canvas.DrawLine(pointtop, pointbottom, paintLine);
        }
    }
}
