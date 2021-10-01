using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using PartsClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsClient.Pages
{
    public class AddEditPartsPage : ContentPage
    {
        readonly Part existingPart;
        readonly EntryCell partNameCell, partTypeCell, supplierCell;
        readonly IList<Part> parts;
        readonly PartsManager manager;

        public AddEditPartsPage(PartsManager manager, IList<Part> parts, Part existingPart = null)
        {
            this.manager = manager;
            this.parts = parts;
            this.existingPart = existingPart;

            var tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot(existingPart is not null ? "Edit Part" : "New Part") {
                    new TableSection("Details") {
                        new TextCell {
                            Text = "Part ID",
                            Detail = (existingPart is not null) ? existingPart.PartID : "Will be generated"
                        },
                        (partNameCell = new EntryCell {
                            Label = "Part Name",
                            Placeholder = "add part name",
                            Text = (existingPart is not null) ? existingPart.PartName : null,
                        }),
                        (partTypeCell = new EntryCell {
                            Label = "Part Type",
                            Placeholder = "add part type",
                            Text = (existingPart is not null) ? existingPart.PartType : null,
                        }),
                        (supplierCell = new EntryCell {
                            Label = "Suppier",
                            Placeholder = "add supplier",
                            Text = (existingPart is not null) ? existingPart.Suppliers.FirstOrDefault() : null,
                        }),
                    },
                }
            };

            Button button = new Button()
            {
                BackgroundColor = existingPart != null ? Color.FromRgb(0x80, 0x80, 0x80) : Color.FromRgb(0x00, 0xFF, 0x00),
                TextColor = Color.FromRgb(0xFF, 0xFF, 0xFF),
                Text = existingPart != null ? "Finished" : "Add Part",
                CornerRadius = 0,
            };
            button.Clicked += OnDismiss;

            Content = new StackLayout
            {
                Spacing = 0,
                Children = { tableView, button },
            };
        }

        async void OnDismiss(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            try
            {
                string partName = partNameCell.Text;
                string supplier = supplierCell.Text;
                string partType = partTypeCell.Text;

                if (string.IsNullOrWhiteSpace(partName)
                    || string.IsNullOrWhiteSpace(supplier)
                    || string.IsNullOrWhiteSpace(partType))
                {
                    await this.DisplayAlert("Missing Information",
                        "You must enter values for the part name, supplier, and part type.",
                        "OK");
                }
                else
                {
                    IsBusy = true;
                    if (existingPart is not null)
                    {
                        existingPart.PartName = partName;
                        existingPart.PartType = partType;
                        existingPart.Suppliers[0] = supplier;

                        await manager.Update(existingPart);
                        int pos = parts.IndexOf(existingPart);
                        parts.RemoveAt(pos);
                        parts.Insert(pos, existingPart);
                    }
                    else
                    {
                        var part = await manager.Add(partName, supplier, partType);
                    }

                    await Navigation.PopModalAsync();
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
                button.IsEnabled = true;
            }
        }
    }
}
