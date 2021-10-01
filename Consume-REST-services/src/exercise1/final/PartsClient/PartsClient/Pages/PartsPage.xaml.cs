using Microsoft.Maui.Controls;
using PartsClient.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PartsClient.Pages
{
    public partial class PartsPage : ContentPage
    {
        readonly IList<Part> parts = new ObservableCollection<Part>();
        readonly PartsManager manager = new PartsManager();

        public PartsPage()
        {
            BindingContext = parts;
            InitializeComponent();
            OnRefresh(this, null);
        }

        async void OnRefresh(object sender, EventArgs e)
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
                        parts.Add(part);
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

        async void OnDeletePart(object sender, EventArgs e)
        {
            var item = (Button)sender;
            var part = item.CommandParameter as Part;
            if (part == null || IsBusy)
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
