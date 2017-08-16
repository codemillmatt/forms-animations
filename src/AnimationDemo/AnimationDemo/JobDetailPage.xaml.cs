using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace AnimationDemo
{
    public partial class JobDetailPage : ContentPage
    {
        public JobDetailPage()
        {
            InitializeComponent();

            jobApplyView.IsVisible = false;

            applyButton.Clicked += async (sender, e) =>
            {
                if (!jobApplyView.IsVisible)
                {
                    jobApplyView.TranslationX = applyButton.X + applyButton.Width / 2;
                    jobApplyView.Opacity = 0;

                    jobApplyView.IsVisible = true;

                    await Task.WhenAll(
                        jobApplyView.TranslateTo(0, 0),
                        jobApplyView.FadeTo(1, 500)
                    );
                }
                else
                {
                    jobApplyView.IsVisible = false;
                }
            };
        }
    }
}
