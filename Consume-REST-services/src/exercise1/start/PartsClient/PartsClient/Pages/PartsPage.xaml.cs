using Microsoft.Maui.Controls;
using PartsClient.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PartsClient.Pages
{
    public partial class PartsPage : ContentPage
    {
        readonly IList<Part> parts = new ObservableCollection<Part>(); // new PartsCollectionViewModel().Parts;
        readonly PartsManager manager = new PartsManager();

        public PartsPage()
        {
            InitializeComponent();
            BindingContext = parts;
            Refresh();
        }

        private async void Refresh()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var partsCollection = await manager.GetAll();
                foreach (Part part in partsCollection)
                {
                    if (parts.All(p => p.PartID != part.PartID))
                    {
                        parts.Add(part);
                    }
                }
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
        private async void OnEditPart(object sender, EventArgs e)
        {
            var item = (Button)sender;
            var part = item.CommandParameter as Part;
            if (part is null || IsBusy)
                return;

            try
            {
                // Display part details and allow user to edit the part
                IsBusy = true;
                await manager.Update(part);
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

        private async void OnDeletePart(object sender, EventArgs e)
        {
            var item = (Button)sender;
            var part = item.CommandParameter as Part;

            if (part is null || IsBusy)
                return;

            if (await this.DisplayAlert("Delete Part?",
                $"Are you sure you want to delete the part '{part.PartName}'?",
                "Yes",
                "Cancel") == true)
            {
                try
                {
                    IsBusy = true;
                    await manager.Delete(part.PartID);
                    parts.Remove(part);
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
        }
    }
}
