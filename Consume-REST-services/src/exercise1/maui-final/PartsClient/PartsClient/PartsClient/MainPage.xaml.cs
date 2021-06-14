using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using PartsClient.Data;

namespace PartsClient
{
    public partial class MainPage : ContentPage, IPage
    {
        readonly IList<Part> parts = new ObservableCollection<Part>();
        readonly PartsManager manager = new PartsManager();

        public MainPage()
        {
            BindingContext = parts;
            InitializeComponent();
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

        async void OnAddNewPart(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(
                new AddEditPartsPage(manager, parts));
        }

        async void OnEditPart(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(
                new AddEditPartsPage(manager, parts, (Part)e.Item));
        }

        async void OnDeletePart(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var part = item.CommandParameter as Part;
            if (part == null || IsBusy)
                return;

            if (await this.DisplayAlert("Delete Part?",
                "Are you sure you want to delete the part '"
                    + part.PartName + "'?", "Yes", "Cancel") == true)
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
