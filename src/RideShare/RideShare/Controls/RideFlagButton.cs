using System;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace RideShare.Controls
{
    public class RideFlagButton : ContentView
    {
        public EventHandler Tapped;

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

            canvas.Clear();

            // Setup the circle
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = Color.Fuchsia.ToSKColor()
            };

            canvas.DrawCircle(info.Width / 2, info.Height / 2, 50, paint);

            if (runningAnimation)
            {
                paint.Color = Color.White.ToSKColor().WithAlpha(128);

                canvas.DrawCircle(info.Width / 2, info.Height / 2, currentRadius, paint);
            }
        }
    }
}
