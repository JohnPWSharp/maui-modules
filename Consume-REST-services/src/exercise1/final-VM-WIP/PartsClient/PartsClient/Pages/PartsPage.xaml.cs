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
        readonly ObservableCollection<Part> parts = new ObservableCollection<Part>();
        readonly PartsManager manager = new PartsManager();
        
        public PartsPage()
        {
            InitializeComponent();
            Refresh();
            PartsView.ItemsSource = parts;
        }

        private async Task Refresh()
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
                        part.CanEdit = true;
                        part.CanSave = false;
                        part.CanDelete = true;
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
        private void OnEditPart(object sender, EventArgs e)
        {
            var item = (Button)sender;
            var part = item.CommandParameter as Part;

            if (part is null || IsBusy)
                return;

            // Change the state to allow the user to modify the data in the Editor fields
            part.CanEdit = false;
            part.CanSave = true;
            part.CanDelete = false;
            PartsView.ItemsSource = new ObservableCollection<Part> { part };
            //PartsView.ItemsSource = parts;
            IsBusy = true;
        }

        private async void OnSavePart(object sender, EventArgs e)
        {
            var item = (Button)sender;
            var part = item.CommandParameter as Part;

            try
            {
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
                await this.DisplayAlert("Saved",
                        "Changes saved",
                        "OK");

                // Change the state back to disallow edits
                //PartsView.ItemsSource = null;
                part.CanEdit = true;
                part.CanSave = false;
                part.CanDelete = true;
                PartsView.ItemsSource = parts;
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
                    PartsView.ItemsSource = null;
                    PartsView.ItemsSource = parts;
                    IsBusy = false;
                }
            }
        }
    }
}
