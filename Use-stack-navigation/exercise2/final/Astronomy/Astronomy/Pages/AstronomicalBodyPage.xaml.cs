using Microsoft.Maui.Controls;
using System;

namespace Astronomy.Pages
{
    public partial class AstronomicalBodyPage : ContentPage
	{
        public AstronomicalBodyPage(AstronomicalBody body)
        {
            InitializeComponent();

            Title = body.Name;

            lblIcon.Text = body.EmojiIcon;
            lblName.Text = body.Name;
            lblMass.Text = body.Mass;
            lblCircumference.Text = body.Circumference;
            lblAge.Text = body.Age;
        }

        private async void goBackClicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private async void goHomeClicked(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
