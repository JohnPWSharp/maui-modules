using Microsoft.Maui.Controls;
using System;

namespace Astronomy.Pages
{
    public partial class AstronomicalBodyPage : ContentPage
	{
        AstronomicalBody displayBody;

        public AstronomicalBodyPage(AstronomicalBody body)
        {
            InitializeComponent();

            Title = body.Name;
            lblIcon.Text = body.EmojiIcon;
            lblName.Text = body.Name;
            displayBody = body;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lblMass.Text = displayBody.Mass;
            lblCircumference.Text = displayBody.Circumference;
            lblAge.Text = displayBody.Age;
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
            var editPage = new Editor(displayBody);
            await Navigation.PushModalAsync(editPage);
        }
    }
}
