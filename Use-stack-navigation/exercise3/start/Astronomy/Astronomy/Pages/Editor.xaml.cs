using Microsoft.Maui.Controls;
using System;

namespace Astronomy.Pages
{
    public partial class Editor : ContentPage
    {
        AstronomicalBody editBody = null;

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

        private async void saveClicked(object sender, EventArgs args)
        {
            // Save changes
            editBody.Mass = entMass.Text;
            editBody.Circumference = entCircumference.Text;
            editBody.Age = entAge.Text;

            // TODO: Return to the previous page
        }

        private async void cancelClicked(object sender, EventArgs args)
        {
            // TODO: Verify that the user wants to cancel, and if so, return to the previous page without saving the changes
        }
    }
}
