using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace RideShare.Controls
{
    public class RideFlagButton : ContentView
    {
        public EventHandler Tapped;

        SKBitmap carBitmap;

        SKCanvasView canvasView;
        bool runningAnimation = false;
        bool runningForward = false;
        int currentRadius = 0;

        public RideFlagButton()
        {
            canvasView = new SKCanvasView();
            canvasView.PaintSurface += CanvasView_PaintSurface;

            var tapRecognizer = new TapGestureRecognizer();
            tapRecognizer.Tapped += (sender, e) =>
            {
                runningAnimation = true;
                runningForward = true;
                RunAnimationLoop();

                Tapped?.Invoke(this, new EventArgs());
            };
            canvasView.GestureRecognizers.Add(tapRecognizer);

            Content = canvasView;

            canvasView.InvalidateSurface();
        }

        async Task RunAnimationLoop()
        {
            canvasView.InvalidateSurface();

            while (runningAnimation)
            {
                if (runningForward)
                {
                    for (int i = 0; i < 50; i += 3)
                    {
                        currentRadius = i;

                        await Task.Delay(TimeSpan.FromSeconds(1.0 / 30.0));
                        canvasView.InvalidateSurface();
                    }

                    runningForward = false;
                }
                else
                {
                    for (int i = 50; i >= 0; i -= 3)
                    {
                        currentRadius = i;

                        await Task.Delay(TimeSpan.FromSeconds(1.0 / 30.0));
                        canvasView.InvalidateSurface();
                    }

                    runningForward = true;
                    runningAnimation = false;
                }
            }
        }

        void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            var surface = e.Surface;
            var canvas = surface.Canvas;

            string imageId = "RideShare.Media.CarFix.png";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            if (carBitmap == null)
            {
                using (Stream stream = assembly.GetManifestResourceStream(imageId))
                using (SKManagedStream skStream = new SKManagedStream(stream))
                {
                    carBitmap = SKBitmap.Decode(skStream);
                }
            }

            canvas.Clear();

            // Setup the circle
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = Color.Fuchsia.ToSKColor()
            };

            canvas.DrawCircle(info.Width / 2, info.Height / 2, 50, paint);

            // Draw the bitmap
            canvas.DrawBitmap(carBitmap, new SKRect(15, 10, info.Width - 15, info.Height - 15), null);

            if (runningAnimation)
            {
                paint.Color = Color.White.ToSKColor().WithAlpha(128);

                canvas.DrawCircle(info.Width / 2, info.Height / 2, currentRadius, paint);
            }
        }
    }
}
