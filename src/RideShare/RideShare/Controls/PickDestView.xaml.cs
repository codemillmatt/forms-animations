using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace RideShare.Controls
{
    public partial class PickDestView : ContentView
    {
        public PickDestView()
        {
            InitializeComponent();
        }

        string location;
        public string Location
        {
            get { return location; }

            set
            {
                location = value;
                locationLabel.Text = location;
            }
        }

    }
}
