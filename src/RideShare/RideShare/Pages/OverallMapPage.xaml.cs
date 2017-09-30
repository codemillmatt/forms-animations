using System;
using System.Threading.Tasks;

using Xamarin.Forms;

using RideShare.Controls;


namespace RideShare.Pages
{
    public partial class OverallMapPage : ContentPage
    {
        public bool AlreadyOpen { get; set; }

        PickDestView pickupInfo;
        PickDestView destInfo;
        Button confirmRide;

        public OverallMapPage()
        {
            InitializeComponent();

            pickupInfo = new PickDestView { Opacity = 0.0, Location = "Pickup" };
            destInfo = new PickDestView { Opacity = 0.0, Location = "Destination" };
            confirmRide = new Button { Opacity = 0.0, Text = "Set Pickup", TextColor = Color.White, BackgroundColor = Color.Fuchsia };

            confirmRide.Clicked += ConfirmRide_Clicked;

            InitialPosition();

            //InitialAnimatedPosition();
        }

        async void ConfirmRide_Clicked(object sender, EventArgs e)
        {
            HideControls();

            //await HideAnimatedControls();
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

        void HideControls()
        {
            pickupInfo.Opacity = 0.0;
            destInfo.Opacity = 0.0;
            confirmRide.Opacity = 0.0;

            callRide.Opacity = 1.0;
        }

        #endregion


        #region SkiaSharp

        //void InitialAnimatedPosition()
        //{
        //    flagRide.Tapped += FlagRide_Tapped;

        //    var yOffset = Constraint.RelativeToView(callRide, (RelativeLayout arg1, View arg2) =>
        //    {
        //        return arg2.Y;
        //    });

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

        async Task HideAnimatedControls()
        {
            //    var finalX = callRide.X + pickupInfo.Width + 5;
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

            //    await flagRide.ScaleTo(1.0, easing: Easing.SinInOut);

            //    //lottieWait.IsVisible = true;
        }

        //async void FlagRide_Tapped(object sender, EventArgs e)
        //{
        //    if (!this.AlreadyOpen)
        //    {
        //        var finalX = flagRide.X + pickupInfo.Width + 15;

        //        await Task.WhenAll(
        //             pickupInfo.FadeTo(1.0),
        //             pickupInfo.TranslateTo(finalX, 0, 500, Easing.SinInOut),
        //             destInfo.TranslateTo(finalX, 0, 500, Easing.SinInOut),
        //             confirmRide.TranslateTo(finalX, 0, 500, Easing.SinInOut)
        //         );

        //        var destinationYTranslation = -1 * (destInfo.Height + 10);

        //        await Task.WhenAny(
        //            destInfo.FadeTo(1.0),
        //            destInfo.TranslateTo(finalX, destinationYTranslation, 1000, Easing.BounceOut)
        //        );

        //        await confirmRide.TranslateTo(finalX, destinationYTranslation, 0);

        //        var confirmRideYTranslation = -1 * (-1 * destinationYTranslation + confirmRide.Height + 10);

        //        await Task.WhenAll(
        //            confirmRide.FadeTo(1.0),
        //            confirmRide.TranslateTo(finalX, confirmRideYTranslation, 250, Easing.CubicInOut)
        //        );

        //        await Task.Delay(250);
        //        await flagRide.ScaleTo(0.0, easing: Easing.SinOut);
        //    }

        //    this.AlreadyOpen = !this.AlreadyOpen;
        //}

        #endregion

    }
}
