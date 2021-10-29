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
            //await Navigation.PopModalAsync();
            await Navigation.PopAsync();
        }

        private async void cancelClicked(object sender, EventArgs args)
        {
            if (await DisplayActionSheet("Discard changes?", "Yes", null, "No") == "Yes")
            {
                // Discard changes
                //await Navigation.PopModalAsync();
                await Navigation.PopAsync();
            }
        }
    }
}
