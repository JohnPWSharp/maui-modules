using Microsoft.Maui.Controls;
using System;

namespace Astronomy.Pages;

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
		editBody = new AstronomicalBody(editBody.Name, entMass.Text, entCircumference.Text, entAge.Text, editBody.EmojiIcon);
		//await Navigation.PopModalAsync();
		await Navigation.PopAsync();
	}

	private async void CancelClicked(object sender, EventArgs args)
	{
		var discard = await DisplayAlert("Discard changes?", "Are you sure you want to discard changes?", "Yes", "Cancel");
		if (discard)
		{
			// Discard changes
			//await Navigation.PopModalAsync();
			await Navigation.PopAsync();
		}
	}
}
