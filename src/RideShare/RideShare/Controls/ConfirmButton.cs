using System;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

using System.Threading.Tasks;
using System.Collections.Generic;
using SkiaSharp;

namespace RideShare.Controls
{
    public class ConfirmButton : ContentView
    {
        bool waitingLoopRunning;
        float startAngle = -10;
        float endingAngle = 90;

        bool drawCheckMark = false;
        float finishedSweep = 0;
        SKPoint[] checkMarkPoints;

        bool drawStaticText = true;

        SKRect boundingBox;

        SKCanvasView canvasView;

        public ConfirmButton()
        {
            canvasView = new SKCanvasView();
            canvasView.PaintSurface += CanvasView_OnPaintSurface;
            Content = canvasView;

            drawStaticText = true;
            canvasView.InvalidateSurface();

            var tgr = new TapGestureRecognizer();
            tgr.Tapped += Handle_Tapped;
            canvasView.GestureRecognizers.Add(tgr);
        }

        #region Painting

        void CanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear(Color.Pink.ToSKColor());

            float left, top, right, bottom;

            if (info.Width > info.Height)
            {
                top = 10;
                bottom = info.Height - 10;

                var xSpan = bottom - top;

                left = info.Width / 2 - xSpan / 2;
                right = info.Width / 2 + xSpan / 2;
            }
            else
            {
                left = 10;
                right = info.Width - 10;

                var ySpan = right - left;

                top = info.Height / 2 - ySpan / 2;
                bottom = info.Height / 2 + ySpan / 2;
            }

            var waitingBoundingRect = new SKRect(left, top, right, bottom);
            boundingBox = new SKRect(left, top, right, bottom);

            if (drawStaticText)
            {
                var textPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = Color.White.ToSKColor(),
                    TextSize = 56
                };

                var size = textPaint.MeasureText("Confirm");


                var textX = info.Width / 2 - size / 2;

                canvas.DrawText("Confirm", textX, info.Height / 2 + textPaint.FontMetrics.Descent, textPaint);
            }

            if (waitingLoopRunning)
            {
                var arcPath = new SKPath();
                arcPath.ArcTo(waitingBoundingRect, startAngle, endingAngle, true);

                var arcPaint = new SKPaint
                {
                    Color = Color.White.ToSKColor(),
                    StrokeWidth = 7,
                    Style = SKPaintStyle.Stroke,
                    StrokeCap = SKStrokeCap.Round
                };

                canvas.DrawPath(arcPath, arcPaint);
            }

            if (drawCheckMark)
            {
                var finishedCirclePaint = new SKPaint
                {
                    Color = Color.White.ToSKColor(),
                    StrokeCap = SKStrokeCap.Round,
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 7
                };

                var finishedArc = new SKPath();
                finishedArc.ArcTo(waitingBoundingRect, 10, finishedSweep, true);
                canvas.DrawPath(finishedArc, finishedCirclePaint);

                canvas.Translate(waitingBoundingRect.Left, 0);

                var checkmarkPaint = new SKPaint
                {
                    Color = Color.Navy.ToSKColor(),
                    StrokeCap = SKStrokeCap.Round,
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 7
                };

                if (checkMarkPoints != null)
                    canvas.DrawPoints(SKPointMode.Polygon, checkMarkPoints, checkmarkPaint);
            }
        }

        #endregion


        async Task WaitingAnimationLoop()
        {
            waitingLoopRunning = true;

            bool endingShouldGrow = true;

            while (waitingLoopRunning)
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

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (drawStaticText)
            {
                drawStaticText = false;
                waitingLoopRunning = true;
                WaitingAnimationLoop();
                return;
            }

            if (waitingLoopRunning)
            {
                waitingLoopRunning = false;
                drawCheckMark = true;
                DrawTheCheckMark();
                return;
            }
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

            int midX = (int)Math.Floor(.31 * boundingBox.Width);

            for (int downX = 7; downX <= midX; downX += 10)
            {
                var downY = downX * 1.25 + .66 * boundingBox.Height;

                var downPoint = new SKPoint((float)downX, (float)downY);

                runningPoints.Add(downPoint);

                checkMarkPoints = runningPoints.ToArray();
                canvasView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }

            var bottomY = midX * 1.25 + .66 * boundingBox.Height;

            for (int upX = midX; upX <= boundingBox.Width - 7; upX += 15)
            {
                var upY = bottomY - (upX - midX) * 1.222222;

                var upPoint = new SKPoint((float)upX, (float)upY);
                runningPoints.Add(upPoint);

                checkMarkPoints = runningPoints.ToArray();
                canvasView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }
        }
    }
}