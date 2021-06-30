using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using PartsClient.Data;

// THIS CODE NEEDS REPLACING WITH CODE FOR THE ADD AND EDIT PAGES DISPLAYED IN THE SHELL
namespace PartsClient
{
    public class AddEditPartsPage : ContentPage, IPage
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
                Root = new TableRoot(existingPart != null ? "Edit Part" : "New Part") {
                    new TableSection("Details") {
                        new TextCell {
                            Text = "PartID",
                            Detail = (existingPart != null) ? existingPart.PartID : "Will be generated"
                        },
                        (partNameCell = new EntryCell {
                            Label = "Part Name",
                            Placeholder = "add part name",
                            Text = (existingPart != null) ? existingPart.PartName : null,
                        }),
                        (partTypeCell = new EntryCell {
                            Label = "Part Type",
                            Placeholder = "add part type",
                            Text = (existingPart != null) ? existingPart.PartType : null,
                        }),
                        (supplierCell = new EntryCell {
                            Label = "Supplier",
                            Placeholder = "add supplier",
                            Text = (existingPart != null) ? existingPart.Suppliers.FirstOrDefault() : null,
                        }),
                    },
                }
            };

            Button button = new Button()
            {
                BackgroundColor = existingPart != null ? Color.FromRgb(0xC0, 0xC0, 0xC0) : Color.FromRgb(0x0, 0xFF, 0x0),
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
                        "You must enter values for the Part Name, Supplier, and Part Type.",
                        "OK");
                }
                else
                {
                    IsBusy = true;
                    if (existingPart != null)
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
                        var book = await manager.Add(partName, supplier, partType);
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