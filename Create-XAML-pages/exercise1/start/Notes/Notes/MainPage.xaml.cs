using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace Notes
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
        Editor editor;

        public MainPage()
        {
            var stackLayout = new StackLayout();
            this.Content = stackLayout;
            this.Content.Margin = new Thickness(30, 60, 30, 30);

            var mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1.0, GridUnitType.Auto) });
            mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1.0, GridUnitType.Auto) });
            mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1.0, GridUnitType.Auto) });
            stackLayout.Add(mainGrid);

            var notesHeading = new Label() { Text = "Notes", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            Grid.SetRow(notesHeading, 0);
            mainGrid.Children.Add(notesHeading);

            editor = new Editor() { Placeholder = "Enter your note", HeightRequest = 100 };
            editor.Text = File.Exists(_fileName) ? File.ReadAllText(_fileName) : string.Empty;
            Grid.SetRow(editor, 1);
            mainGrid.Children.Add(editor);

            var buttonsGrid = new Grid() { HeightRequest = 40.0 };
            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });
            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30.0, GridUnitType.Absolute) });
            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });
            Grid.SetRow(buttonsGrid, 2);
            mainGrid.Children.Add(buttonsGrid);

            var saveButton = new Button() { WidthRequest = 100, Text = "Save" };
            saveButton.Clicked += OnSaveButtonClicked;
            Grid.SetColumn(saveButton, 0);
            buttonsGrid.Children.Add(saveButton);

            var deleteButton = new Button() { WidthRequest = 100, Text = "Delete" };
            deleteButton.Clicked += OnDeleteButtonClicked;
            Grid.SetColumn(deleteButton, 2);
            buttonsGrid.Children.Add(deleteButton);
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }
    }
    }
