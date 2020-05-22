using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for CustomControlWindow.xaml
    /// </summary>
    public partial class CustomControlWindow : Window
    {
        public CustomControlWindow()
        {
            InitializeComponent();
        }

        private void uxCanadianPostalCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (uxCanadianPostalCode.Text.Length >= 6)
            {
                uxTextBlock.Text = uxCanadianPostalCode.Valid ? $"{uxCanadianPostalCode.Text} is a valid postal code" : $"{uxCanadianPostalCode.Text} is not a valid postal code";
            }
        }
    }
}
