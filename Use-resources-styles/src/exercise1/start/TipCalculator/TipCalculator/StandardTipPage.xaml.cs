using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace TipCalculator
{
	public partial class StandardTipPage : ContentPage
	{
        public StandardTipPage()
        {
            InitializeComponent();
            billInput.TextChanged += (s, e) => CalculateTip();
        }

        void CalculateTip()
        {
            double bill;

            if (Double.TryParse(billInput.Text, out bill) && bill > 0)
            {
                double tip = Math.Round(bill * 0.15, 2);
                double final = bill + tip;

                tipOutput.Text = tip.ToString("C");
                totalOutput.Text = final.ToString("C");
            }
        }

        void OnLight(object sender, EventArgs e)
        {
            LayoutRoot.BackgroundColor = Color.FromRgb(0xC0, 0xC0, 0xC0); // Silver

            tipLabel.TextColor = Color.FromRgb(0x60, 0x60, 0x60); // Navy
            billLabel.TextColor = Color.FromRgb(0x60, 0x60, 0x60);
            totalLabel.TextColor = Color.FromRgb(0x60, 0x60, 0x60);
            tipOutput.TextColor = Color.FromRgb(0x60, 0x60, 0x60);
            totalOutput.TextColor = Color.FromRgb(0x60, 0x60, 0x60);
        }

        void OnDark(object sender, EventArgs e)
        {
            LayoutRoot.BackgroundColor = Color.FromRgb(0x60, 0x60, 0x60); // Navy

            tipLabel.TextColor = Color.FromRgb(0xC0, 0xC0, 0xC0); // Silver
            billLabel.TextColor = Color.FromRgb(0xC0, 0xC0, 0xC0);
            totalLabel.TextColor = Color.FromRgb(0xC0, 0xC0, 0xC0);
            tipOutput.TextColor = Color.FromRgb(0xC0, 0xC0, 0xC0);
            totalOutput.TextColor = Color.FromRgb(0xC0, 0xC0, 0xC0);
        }
    }
}
