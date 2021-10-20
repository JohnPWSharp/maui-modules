using Microsoft.Maui.Controls;
using PartsClient.Data;
using System;
using System.Collections.Generic;

namespace PartsClient.Pages
{
    public partial class AddPartPage : ContentPage
    {
        public AddPartPage()
        {
            InitializeComponent();
        }

        private async void OnAddPart(object sender, EventArgs e)
        {
            
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Part part = new Part
                {
                    PartName = PartNameField.Text,
                    PartType = PartTypeField.Text,
                    Suppliers = new List<String> { PartSupplierField.Text }
                };

                var insertedPart = await PartsPage.partsViewModel.AddPart(part);
                await this.DisplayAlert("Saved",
                        "Changes saved",
                        "OK");

                BindingContext = insertedPart;
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Error",
                        ex.Message,
                        "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnClearPart(object sender, EventArgs e)
        {

        }
    }
}
