using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Windows;

namespace sample_01
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

            // draw some text
            SKTypeface font = SKTypeface.FromFamilyName("Arial", SKFontStyle.Normal);
            SKColor steelBlue = SKColors.SteelBlue;

            SKPaint paintText = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                IsAntialias = true,
                Color = steelBlue,
                TextSize = 32,
                TextAlign = SKTextAlign.Center,
                Typeface = font,
            };

            SKSize canvasSize = new SKSize(width, height);
            SKPoint center = new SKPoint(canvasSize.Width / 2f, canvasSize.Height / 2);

            canvas.DrawText("Hello World", center, paintText);
        }
	}
}
