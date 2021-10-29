using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace Astronomy.Pages
{
    public partial class AstronomicalBodyPage : ContentPage
	{
        AstronomicalBody displayBody = null;

        public AstronomicalBodyPage(AstronomicalBody body)
        {
            InitializeComponent();

            Title = body.Name;

            lblIcon.Text = body.EmojiIcon;
            lblName.Text = body.Name;
            lblMass.Text = body.Mass;
            lblCircumference.Text = body.Circumference;
            lblAge.Text = body.Age;

            displayBody = body;
        }

        private async void goBackClicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private async void goHomeClicked(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

        private async void editClicked(object sender, EventArgs args)
        {
            NavigationPage editPage = new NavigationPage(new Editor(displayBody));
            //await Navigation.PushModalAsync(editPage);
            await Navigation.PushAsync(editPage);
        }
    }
}
