using System;
using System.Threading.Tasks;

using Xamarin.Forms;

using RideShare.Controls;


namespace RideShare.Pages
{
    public partial class OverallMapPage : ContentPage
    {
        PickDestView pickupInfo;
        PickDestView destInfo;
        Button confirmRide;

        public OverallMapPage()
        {
            InitializeComponent();

            pickupInfo = new PickDestView { Opacity = 0.0, Location = "Pickup" };
            destInfo = new PickDestView { Opacity = 0.0, Location = "Destination" };
            confirmRide = new Button { Opacity = 0.0, Text = "Set Pickup", TextColor = Color.White, BackgroundColor = Color.Fuchsia };
            theSpinner.BackgroundColor = Color.FromRgba(96, 96, 96, 90);
            theSpinner.IsVisible = false;

            confirmRide.Clicked += ConfirmRide_Clicked;

            InitialPosition();
        }

        async void ConfirmRide_Clicked(object sender, EventArgs e)
        {
            await HideControls();
        }

        #region No Animation

        void InitialPosition()
        {
            callRide.Clicked += CallRide_Clicked;

            var widthOffset = Constraint.RelativeToParent((parent) => 0.75 * parent.Width);

            var xOffset = Constraint.RelativeToView(callRide, (rl, cr) =>
            {
                return cr.X + cr.Width + 10;
            });

            var pickupInfoYOffset = Constraint.RelativeToView(callRide, (rl, cr) => cr.Y);
            relLayout.Children.Add(pickupInfo, xOffset, pickupInfoYOffset, widthOffset);

            var destInfoYOffset = Constraint.RelativeToView(pickupInfo, (rl, pi) => pi.Y - pi.Height - 10);
            relLayout.Children.Add(destInfo, xOffset, destInfoYOffset, widthOffset);

            var confirmRideYOffset = Constraint.RelativeToView(pickupInfo, (rl, pi) => pi.Y - pi.Height - pi.Height - confirmRide.Height + 10);
            relLayout.Children.Add(confirmRide, xOffset, confirmRideYOffset, widthOffset);
        }

        void CallRide_Clicked(object sender, EventArgs e)
        {
            pickupInfo.Opacity = 1.0;
            destInfo.Opacity = 1.0;
            confirmRide.Opacity = 1.0;
            callRide.Opacity = 0.0;
        }

        async Task HideControls()
        {
            pickupInfo.Opacity = 0.0;
            destInfo.Opacity = 0.0;
            confirmRide.Opacity = 0.0;

            theSpinner.IsVisible = true;
            theSpinner.IsRunning = true;

            await Task.Delay(TimeSpan.FromSeconds(2));

            theSpinner.IsVisible = false;
            theSpinner.IsRunning = false;

            callRide.Opacity = 1.0;
        }

        #endregion

        #region Forms API

        //void InitialPosition()
        //{
        //    callRide.Clicked += CallRide_Clicked;

        //    // Setup for offscreen
        //    var yOffset = Constraint.RelativeToParent(rl => rl.Height - 100);

        //    var widthOffset = Constraint.RelativeToParent((arg) => 0.75 * arg.Width);

        //    var xOffset = Constraint.RelativeToParent((parent) =>
        //    {
        //        var start = .1 * parent.Width;
        //        var offSet = .75 * parent.Width;

        //        return start - offSet;
        //    });

        //    relLayout.Children.Add(pickupInfo, xOffset, yOffset, widthOffset);
        //    relLayout.Children.Add(destInfo, xOffset, yOffset, widthOffset);
        //    relLayout.Children.Add(confirmRide, xOffset, yOffset, widthOffset);
        //}

        //async void CallRide_Clicked(object sender, EventArgs e)
        //{
        //    var finalX = callRide.X + pickupInfo.Width + 15;
        //    var destinationYTranslation = -1 * (destInfo.Height + 10);
        //    var confirmRideYTranslation = -1 * (-1 * destinationYTranslation + confirmRide.Height + 10);

        //    await Task.WhenAll(
        //         pickupInfo.FadeTo(1.0),
        //         pickupInfo.TranslateTo(finalX, 0, 500, Easing.SinInOut),
        //         destInfo.TranslateTo(finalX, 0, 500, Easing.SinInOut),
        //         confirmRide.TranslateTo(finalX, 0, 500, Easing.SinInOut)
        //     );

        //    await Task.WhenAny(
        //        destInfo.FadeTo(1.0),
        //        destInfo.TranslateTo(finalX, destinationYTranslation, 1000, Easing.BounceOut)
        //    );

        //    await confirmRide.TranslateTo(finalX, destinationYTranslation, 0);

        //    await Task.WhenAll(
        //        confirmRide.FadeTo(1.0),
        //        confirmRide.TranslateTo(finalX, confirmRideYTranslation, 250, Easing.CubicInOut)
        //    );

        //    await Task.Delay(250);
        //    await callRide.ScaleTo(0.0, easing: Easing.SinOut);

        //}

        //async Task HideControls()
        //{
        //    var finalX = callRide.X + pickupInfo.Width + 5;
        //    var yTranslation = -1 * (destInfo.Height + 10);

        //    await confirmRide.TranslateTo(finalX, yTranslation, 250, Easing.SinInOut);

        //    await Task.WhenAll(
        //        confirmRide.TranslateTo(finalX, 0, 250, Easing.SinInOut),
        //            destInfo.TranslateTo(finalX, 0, 250, Easing.SinInOut)
        //        );

        //    await Task.WhenAll(
        //        confirmRide.TranslateTo(0, 0, 250, Easing.SinInOut),
        //        destInfo.TranslateTo(0, 0, 250, Easing.SinInOut),
        //        pickupInfo.TranslateTo(0, 0, 250, Easing.SinInOut),
        //        confirmRide.FadeTo(0), destInfo.FadeTo(0), pickupInfo.FadeTo(0)
        //    );

        //    theSpinner.IsVisible = true;
        //    theSpinner.IsRunning = true;

        //    await Task.Delay(TimeSpan.FromSeconds(2));

        //    theSpinner.IsVisible = false;
        //    theSpinner.IsRunning = false;

        //    await callRide.ScaleTo(1.0, easing: Easing.SinInOut);
        //}

        #endregion


        #region SkiaSharp

        //void InitialPosition()
        //{
        //    flagRide.Tapped += FlagRide_Tapped;

        //    var yOffset = Constraint.RelativeToParent(rl => rl.Height - 100);

        //    var widthOffset = Constraint.RelativeToParent((arg) => 0.75 * arg.Width);

        //    var xOffset = Constraint.RelativeToParent((parent) =>
        //    {
        //        var start = .1 * parent.Width;
        //        var offSet = .75 * parent.Width;

        //        return start - offSet;
        //    });

        //    relLayout.Children.Add(pickupInfo, xOffset, yOffset, widthOffset);
        //    relLayout.Children.Add(destInfo, xOffset, yOffset, widthOffset);
        //    relLayout.Children.Add(confirmRide, xOffset, yOffset, widthOffset);              
        //}

        //async void FlagRide_Tapped(object sender, EventArgs e)
        //{
        //    var finalX = flagRide.X + pickupInfo.Width + 15;

        //    await Task.WhenAll(
        //         pickupInfo.FadeTo(1.0),
        //         pickupInfo.TranslateTo(finalX, 0, 500, Easing.SinInOut),
        //         destInfo.TranslateTo(finalX, 0, 500, Easing.SinInOut),
        //         confirmRide.TranslateTo(finalX, 0, 500, Easing.SinInOut)
        //     );

        //    var destinationYTranslation = -1 * (destInfo.Height + 10);

        //    await Task.WhenAny(
        //        destInfo.FadeTo(1.0),
        //        destInfo.TranslateTo(finalX, destinationYTranslation, 1000, Easing.BounceOut)
        //    );

        //    await confirmRide.TranslateTo(finalX, destinationYTranslation, 0);

        //    var confirmRideYTranslation = -1 * (-1 * destinationYTranslation + confirmRide.Height + 10);

        //    await Task.WhenAll(
        //        confirmRide.FadeTo(1.0),
        //        confirmRide.TranslateTo(finalX, confirmRideYTranslation, 250, Easing.CubicInOut)
        //    );

        //    await Task.Delay(250);
        //    await flagRide.ScaleTo(0.0, easing: Easing.SinOut);

        //}

        //async Task HideControls()
        //{
        //    var finalX = flagRide.X + pickupInfo.Width + 5;
        //    var yTranslation = -1 * (destInfo.Height + 10);

        //    await confirmRide.TranslateTo(finalX, yTranslation, 250, Easing.SinInOut);

        //    await Task.WhenAll(
        //        confirmRide.TranslateTo(finalX, 0, 250, Easing.SinInOut),
        //        destInfo.TranslateTo(finalX, 0, 250, Easing.SinInOut)
        //    );

        //    await Task.WhenAll(
        //        confirmRide.TranslateTo(0, 0, 250, Easing.SinInOut),
        //        destInfo.TranslateTo(0, 0, 250, Easing.SinInOut),
        //        pickupInfo.TranslateTo(0, 0, 250, Easing.SinInOut),
        //        confirmRide.FadeTo(0), destInfo.FadeTo(0), pickupInfo.FadeTo(0)
        //    );

        //    theSpinner.IsVisible = true;
        //    theSpinner.IsRunning = true;

        //    //lottieWait.IsVisible = true;

        //    await Task.Delay(TimeSpan.FromSeconds(2));

        //    //await Task.WhenAll(
        //    //    lottieWait.ScaleTo(0, 250, Easing.SinOut),
        //    //    lottieWait.FadeTo(0.0)
        //    //);

        //    //lottieWait.IsVisible = false;
        //    //lottieWait.Scale = 1.0;
        //    //lottieWait.Opacity = 1.0;

        //    theSpinner.IsVisible = false;
        //    theSpinner.IsRunning = false;

        //    await flagRide.ScaleTo(1.0, easing: Easing.SinInOut);
        //}

        #endregion
    }
}
