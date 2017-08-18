using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SkiaSharp.Views.Forms;
using SkiaSharp;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AnimationDemo
{
    public partial class JobApplyView : ContentView
    {
        bool pageIsActive;
        float startAngle = -10;
        float endingAngle = 90;

        bool drawCheckMark = false;
        float finishedSweep = 0;
        SKPoint[] checkMarkPoints;
        bool finishedCircleDone = false;

        public JobApplyView()
        {
            InitializeComponent();
        }


        public void Appearing()
        {
            pageIsActive = true;
            WaitingAnimationLoop();
        }

        public void Disappearing()
        {
            pageIsActive = false;
        }

        async Task WaitingAnimationLoop()
        {
            bool endingShouldGrow = true;

            while (pageIsActive)
            {
                canvasView.InvalidateSurface();

                startAngle += 5;

                if (endingAngle < 330 && endingShouldGrow)
                    endingAngle += 10;

                if (endingAngle > 45 && !endingShouldGrow)
                    endingAngle -= 10;

                if (endingAngle >= 330 || endingAngle <= 45)
                    endingShouldGrow ^= true;

                // Refresh the page 30 times per second
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }
        }

        void CanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear();

            var boundingRect = new SKRect(info.Width / 2 - 100,
                                             info.Height / 2 - 100,
                                             info.Width / 2 + 100,
                                             info.Height / 2 + 100);

            if (!drawCheckMark)
            {
                var arcPath = new SKPath();
                arcPath.ArcTo(boundingRect, startAngle, endingAngle, true);

                var arcPaint = new SKPaint
                {
                    Color = Color.Orange.ToSKColor(),
                    StrokeWidth = 20,
                    Style = SKPaintStyle.Stroke,
                    StrokeCap = SKStrokeCap.Round
                };

                canvas.DrawPath(arcPath, arcPaint);
            }
            else
            {
                var pinkPaint = new SKPaint
                {
                    Color = Color.Salmon.ToSKColor(),
                    StrokeCap = SKStrokeCap.Round,
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 10
                };

                var finishedArc = new SKPath();
                finishedArc.ArcTo(boundingRect, 10, finishedSweep, true);
                canvas.DrawPath(finishedArc, pinkPaint);

                canvas.Translate(boundingRect.Left + 20, boundingRect.Top);

                var whitePaint = new SKPaint
                {
                    Color = Color.White.ToSKColor(),
                    StrokeCap = SKStrokeCap.Round,
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 20
                };

                //canvas.DrawLine(0, 100, 40, 150, whitePaint);
                //canvas.DrawLine(40, 150, 130, 40, whitePaint);

                if (checkMarkPoints != null)
                    canvas.DrawPoints(SKPointMode.Lines, checkMarkPoints, whitePaint);
            }
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            drawCheckMark = true;
            pageIsActive = false;

            DrawTheCheckMark();
        }

        async Task DrawTheCheckMark()
        {
            finishedSweep = 0;
            while (finishedSweep < 350)
            {
                finishedSweep += 15;

                if (finishedSweep > 359)
                    finishedSweep = 359;

                canvasView.InvalidateSurface();

                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }

            List<SKPoint> runningPoints = new List<SKPoint>();

            for (int downX = 0; downX <= 40; downX += 4)
            {
                var downY = downX * 1.25 + 100;

                var downPoint = new SKPoint((float)downX, (float)downY);

                runningPoints.Add(downPoint);

                checkMarkPoints = runningPoints.ToArray();
                canvasView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }

            for (int upX = 40; upX <= 130; upX += 9)
            {
                var upY = 150 - (upX - 40) * 1.22222;

                var upPoint = new SKPoint((float)upX, (float)upY);
                runningPoints.Add(upPoint);

                checkMarkPoints = runningPoints.ToArray();
                canvasView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }
        }
    }
}
