using Microsoft.Maui.Controls;
using System;

namespace Astronomy.Pages
{
    public partial class Editor : ContentPage
    {
        AstronomicalBody editBody = null;

        public Editor(AstronomicalBody bodyToEdit)
        {
            InitializeComponent();

            lblIcon.Text = bodyToEdit.EmojiIcon;
            lblName.Text = bodyToEdit.Name;
            entMass.Text = bodyToEdit.Mass;
            entCircumference.Text = bodyToEdit.Circumference;
            entAge.Text = bodyToEdit.Age;

            editBody = bodyToEdit;
        }

        private async void saveClicked(object sender, EventArgs args)
        {
            // Save changes
            editBody.Mass = entMass.Text;
            editBody.Circumference = entCircumference.Text;
            editBody.Age = entAge.Text;

            // Return to the previous page
            await Navigation.PopModalAsync();
        }

        private async void cancelClicked(object sender, EventArgs args)
        {
            // Verify that the user wants to cancel, and if so, return to the previous page without saving the changes
            if (await DisplayAlert("Discard changes?", "Are you sure?", "Yes", "No"))
            {
                // Discard changes
                await Navigation.PopModalAsync();
            }
        }
    }
}
