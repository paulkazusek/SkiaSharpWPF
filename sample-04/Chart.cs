using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sample_04
{
    class Chart
    {
        private float _minValue = 0;
        private float _maxValue = 0;
        private float _virtualHeight = 1;
        private float _virtualWidth = 1;

        private float _scaleX = 1;
        private float _scaleY = 1;
        private float _offsetX = 0;
        private float _offsetY = 0;

        private SKPaint _gridPaint = new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            IsAntialias = true,
            Color = SKColors.Gray,
            StrokeWidth = 1,
        };
        private SKPaint _seriesPaint = new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            IsAntialias = true,
            Color = SKColors.Red,
            StrokeWidth = 1,
        };

        public List<double> Series { get; set; } = new List<double>();
        public int HorizontalDivisons { get; set; }

        public void draw(SKCanvas canvas, SKRect rect)
        {
            _virtualWidth = Series.Count;
            _minValue = (float)Series.Min();
            _maxValue = (float)Series.Max();
            _virtualHeight = _maxValue - _minValue;

            _scaleX = rect.Width / _virtualWidth;
            _scaleY = rect.Height / _virtualHeight;
            _offsetX = rect.Left;
            _offsetY = rect.Top;

            drawGrid(canvas);
            drawSeries(canvas);
        }

        private void drawSeries(SKCanvas canvas)
        {
            SKPoint? lastPoint = null;
            for (int i = 0; i < Series.Count; i++)
            {
                var value = (float)Series[i] - _minValue;

                if (lastPoint.HasValue)
                {
                    var currentPoint = transform(new SKPoint(i, value));
                    canvas.DrawLine(lastPoint.Value, currentPoint, _seriesPaint);
                    lastPoint = currentPoint;
                }
                else
                {
                    lastPoint = transform(new SKPoint(i, value));
                }
            }
        }

        private void drawGrid(SKCanvas canvas)
        {
            var border = transform(new SKRect(0, 0, _virtualWidth, _virtualHeight));

            canvas.DrawRect(border, _gridPaint);

            for (int c = 0; c < _virtualWidth; c++)
            {
                var top = transform(new SKPoint(c, 0));
                var bottom = transform(new SKPoint(c, _virtualHeight));
                canvas.DrawLine(top, bottom, _gridPaint);
            }
            for (int r = 0; r < HorizontalDivisons; r++)
            {
                var dr = r * (_virtualHeight / HorizontalDivisons);
                var left = transform(new SKPoint(0, dr));
                var right = transform(new SKPoint(_virtualWidth, dr));
                canvas.DrawLine(left, right, _gridPaint);
            }
        }

        private SKRect transform(SKRect source)
        {
            return new SKRect(
                source.Left * _scaleX + _offsetX,
                source.Top * _scaleY + _offsetY,
                source.Right * _scaleX + _offsetX,
                source.Bottom * _scaleY + _offsetY);
        }
        private SKPoint transform(SKPoint source)
        {
            return new SKPoint(source.X * _scaleX + _offsetX, source.Y * _scaleY + _offsetY);
        }
    }
}
