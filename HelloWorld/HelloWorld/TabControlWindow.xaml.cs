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
    /// Interaction logic for TabControlWindow.xaml
    /// </summary>
    public partial class TabControlWindow : Window
    {
        public TabControlWindow()
        {
            InitializeComponent();
        }
        private void setIndex(int i)
        {
            if (i < 0)
            {
                i = uxTab.Items.Count - 1;
            }
            if (i >= uxTab.Items.Count)
            {
                i = 0;
            }
            uxTab.SelectedIndex = i;
        }

        private void uxPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            setIndex(uxTab.SelectedIndex - 1);
        }

        private void uxNextButton_Click(object sender, RoutedEventArgs e)
        {
            setIndex(uxTab.SelectedIndex + 1);
        }
    }
}
