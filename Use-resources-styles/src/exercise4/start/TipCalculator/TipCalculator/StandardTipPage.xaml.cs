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
            Resources["fgColor"] = Color.FromRgb(0x60, 0x60, 0x60);
            Resources["bgColor"] = Color.FromRgb(0xC0, 0xC0, 0xC0);
        }

        void OnDark(object sender, EventArgs e)
        {
            Resources["fgColor"] = Color.FromRgb(0xC0, 0xC0, 0xC0);
            Resources["bgColor"] = Color.FromRgb(0x60, 0x60, 0x60);
        }
    }
}
