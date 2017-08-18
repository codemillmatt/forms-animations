using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace AnimationDemo
{
    public partial class JobDetailPage : ContentPage
    {
        bool isVisible = false;
        public JobDetailPage()
        {
            InitializeComponent();

            //jobApplyView.IsVisible = false;
			jobApplyView.TranslationX = applyButton.X + applyButton.Width / 2;
			jobApplyView.TranslationY = -jobApplyView.Height;
			jobApplyView.Opacity = 0;
			jobApplyView.Scale = 0;


			applyButton.Clicked += async (sender, e) =>
            {
                if (!isVisible)
                {
					isVisible = true;

					jobApplyView.TranslationX = applyButton.X + applyButton.Width / 2;
					jobApplyView.TranslationY = -jobApplyView.Height;
					jobApplyView.Opacity = 0;
					jobApplyView.Scale = 0;

                    await Task.WhenAll(
                        jobApplyView.FadeTo(1, 500),
                        jobApplyView.ScaleTo(1, 750),
						jobApplyView.TranslateTo(0, 0)

					);

                    return;
                }

                isVisible = false;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            jobApplyView.Appearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            jobApplyView.Disappearing();
        }
    }
}
