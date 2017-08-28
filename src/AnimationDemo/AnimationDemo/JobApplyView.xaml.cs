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
        //bool waitingLoopRunning;
        //float startAngle = -10;
        //float endingAngle = 90;

        //bool drawCheckMark = false;
        //float finishedSweep = 0;
        //SKPoint[] checkMarkPoints;

        //bool drawStaticText = true;

        public JobApplyView()
        {
            InitializeComponent();
        }

        //public void Appearing()
        //{
        //    drawStaticText = true;
        //    canvasView.InvalidateSurface();
        //}

        //public void Disappearing()
        //{
        //    waitingLoopRunning = false;
        //    drawCheckMark = false;
        //    drawStaticText = false;
        //}

        //async Task WaitingAnimationLoop()
        //{
        //    waitingLoopRunning = true;

        //    bool endingShouldGrow = true;

        //    while (waitingLoopRunning)
        //    {
        //        canvasView.InvalidateSurface();

        //        startAngle += 5;

        //        if (endingAngle < 330 && endingShouldGrow)
        //            endingAngle += 10;

        //        if (endingAngle > 45 && !endingShouldGrow)
        //            endingAngle -= 10;

        //        if (endingAngle >= 330 || endingAngle <= 45)
        //            endingShouldGrow ^= true;

        //        // Refresh the page 30 times per second
        //        await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
        //    }
        //}

        //void CanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        //{
        //    var info = e.Info;
        //    var surface = e.Surface;
        //    var canvas = surface.Canvas;

        //    canvas.Clear(Color.Yellow.ToSKColor());

        //    var waitingBoundingRect = new SKRect(info.Width / 2 - 100,
        //                                     info.Height / 2 - 100,
        //                                     info.Width / 2 + 100,
        //                                     info.Height / 2 + 100);

        //    if (drawStaticText)
        //    {
        //        var orangePaint = new SKPaint
        //        {
        //            Style = SKPaintStyle.Fill,
        //            Color = Color.Orange.ToSKColor(),
        //            TextSize = 128
        //        };

        //        canvas.DrawText("Confirm", info.Width / 2 - 30, info.Height / 2, orangePaint);
        //    }

        //    if (waitingLoopRunning)
        //    {
        //        var arcPath = new SKPath();
        //        arcPath.ArcTo(waitingBoundingRect, startAngle, endingAngle, true);

        //        var arcPaint = new SKPaint
        //        {
        //            Color = Color.Orange.ToSKColor(),
        //            StrokeWidth = 20,
        //            Style = SKPaintStyle.Stroke,
        //            StrokeCap = SKStrokeCap.Round
        //        };

        //        canvas.DrawPath(arcPath, arcPaint);
        //    }

        //    if (drawCheckMark)
        //    {
        //        var pinkPaint = new SKPaint
        //        {
        //            Color = Color.Salmon.ToSKColor(),
        //            StrokeCap = SKStrokeCap.Round,
        //            Style = SKPaintStyle.Stroke,
        //            StrokeWidth = 10
        //        };

        //        var finishedArc = new SKPath();
        //        finishedArc.ArcTo(waitingBoundingRect, 10, finishedSweep, true);
        //        canvas.DrawPath(finishedArc, pinkPaint);

        //        canvas.Translate(waitingBoundingRect.Left + 20, waitingBoundingRect.Top);

        //        var whitePaint = new SKPaint
        //        {
        //            Color = Color.White.ToSKColor(),
        //            StrokeCap = SKStrokeCap.Round,
        //            Style = SKPaintStyle.Stroke,
        //            StrokeWidth = 20
        //        };

        //        if (checkMarkPoints != null)
        //            canvas.DrawPoints(SKPointMode.Polygon, checkMarkPoints, whitePaint);
        //    }
        //}

        //void Handle_Tapped(object sender, System.EventArgs e)
        //{
        //    if (drawStaticText)
        //    {
        //        drawStaticText = false;
        //        waitingLoopRunning = true;
        //        WaitingAnimationLoop();
        //        return;
        //    }

        //    if (waitingLoopRunning)
        //    {
        //        waitingLoopRunning = false;
        //        drawCheckMark = true;
        //        DrawTheCheckMark();
        //        return;
        //    }
        //}

        //async Task DrawTheCheckMark()
        //{
        //    finishedSweep = 0;
        //    while (finishedSweep < 350)
        //    {
        //        finishedSweep += 15;

        //        if (finishedSweep > 359)
        //            finishedSweep = 359;

        //        canvasView.InvalidateSurface();

        //        await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
        //    }

        //    List<SKPoint> runningPoints = new List<SKPoint>();

        //    for (int downX = 0; downX <= 40; downX += 10)
        //    {
        //        var downY = downX * 1.25 + 100;

        //        var downPoint = new SKPoint((float)downX, (float)downY);

        //        runningPoints.Add(downPoint);

        //        checkMarkPoints = runningPoints.ToArray();
        //        canvasView.InvalidateSurface();
        //        await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
        //    }

        //    for (int upX = 40; upX <= 130; upX += 15)
        //    {
        //        var upY = 150 - (upX - 40) * 1.22222;

        //        var upPoint = new SKPoint((float)upX, (float)upY);
        //        runningPoints.Add(upPoint);

        //        checkMarkPoints = runningPoints.ToArray();
        //        canvasView.InvalidateSurface();
        //        await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
        //    }
        //}
    }
}
