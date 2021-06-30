using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Essentials;

namespace Notes
{
    public partial class UIPage : ContentPage
    {
        string fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

        public UIPage()
        {
            InitializeComponent();

            if (File.Exists(fileName))
            {
                editor.Text = File.ReadAllText(fileName);
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(fileName, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            editor.Text = string.Empty;
        }
    }
}