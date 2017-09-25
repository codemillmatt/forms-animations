using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using RideShare.Controls;
using System.Threading.Tasks;

namespace RideShare.Pages
{
    public partial class OverallMapPage : ContentPage
    {
        public bool AlreadyOpen { get; set; }

        public OverallMapPage()
        {
            InitializeComponent();

            var mapSpan = new MapSpan(new Position(43.0731, -89.4012), .25, .25);

            overallMap.MoveToRegion(mapSpan);

            var pickup = new PickDestView { Opacity = 0.0, Location = "Pickup" };
            var dest = new PickDestView { Opacity = 0.0, Location = "Destination" };
            var ok = new Button { Opacity = 0.0, Text = "Set Pickup", TextColor = Color.White, BackgroundColor = Color.Fuchsia };


            var pickY = Constraint.RelativeToView(hailRideButton, (RelativeLayout arg1, View arg2) =>
            {
                return arg2.Y;
            });

            var pickWidth = Constraint.RelativeToParent((arg) => 0.75 * arg.Width);

            var pickX = Constraint.RelativeToParent((parent) =>
            {
                var start = .1 * parent.Width;
                var offSet = .75 * parent.Width;

                return start - offSet;
            });

            relLayout.Children.Add(pickup, xConstraint: pickX, yConstraint: pickY, widthConstraint: pickWidth);
            relLayout.Children.Add(dest, xConstraint: pickX, yConstraint: pickY, widthConstraint: pickWidth);
            relLayout.Children.Add(ok, xConstraint: pickX, yConstraint: pickY, widthConstraint: pickWidth);

            //hailRideButton.Clicked += async (sender, e) =>
            //{
            //    await hailRideButton.ScaleTo(scale: 1.05);

            //    var finalX = hailRideButton.X + pickup.Width + 5;

            //    await Task.WhenAll(
            //         pickup.FadeTo(1.0),
            //         pickup.TranslateTo(finalX, 0, 500, Easing.SinInOut),
            //        dest.TranslateTo(finalX, 0, 500, Easing.SinInOut)
            //     );

            //    var yTranslation = -1 * (dest.Height + 10);

            //    await Task.WhenAll(
            //        dest.FadeTo(1.0),
            //        dest.TranslateTo(finalX, yTranslation, 1000, Easing.BounceOut)
            //    );

            //};

            flagRide.Tapped += async (sender, e) =>
            {
                if (!this.AlreadyOpen)
                {
                    var finalX = hailRideButton.X + pickup.Width + 5;

                    await Task.WhenAll(
                         pickup.FadeTo(1.0),
                         pickup.TranslateTo(finalX, 0, 500, Easing.SinInOut),
                        dest.TranslateTo(finalX, 0, 500, Easing.SinInOut),
                        ok.TranslateTo(finalX, 0, 500, Easing.SinInOut)
                     );

                    var yTranslation = -1 * (dest.Height + 10);

                    await Task.WhenAll(
                        dest.FadeTo(1.0),
                        dest.TranslateTo(finalX, yTranslation, 1000, Easing.BounceOut),
                        ok.TranslateTo(finalX, yTranslation, 1000, Easing.BounceOut)
                    );

                    var okTranslation = -1 * (-1 * yTranslation + ok.Height + 10);
                    await Task.WhenAll(
                        ok.FadeTo(1.0),
                        ok.TranslateTo(finalX, okTranslation, 500, Easing.CubicInOut)
                    );
                }

                this.AlreadyOpen = !this.AlreadyOpen;
            };
        }


    }
}
