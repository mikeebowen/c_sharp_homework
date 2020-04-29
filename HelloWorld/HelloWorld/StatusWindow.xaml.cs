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
    /// Interaction logic for StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Window
    {
        private int max = 40;
        public StatusWindow()
        {
            InitializeComponent();
            uxTextEditor.MaxLength = max;
            uxProgressBar.Maximum = uxTextEditor.MaxLength;
            uxPercent.Text = $"{(uxProgressBar.Value / max) * 100}%";
            uxTextEditor_SelectionChanged(null, null);
        }
        private void uxTextEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            updateSStatus();
        }
        private void updateSStatus()
        {
            int row;
            int col;
            if (uxTextEditor.CaretIndex == 0)
            {
                row = 0;
                col = 0;
            }
            else
            {
                row = uxTextEditor.GetLineIndexFromCharacterIndex(uxTextEditor.CaretIndex);
                col = uxTextEditor.CaretIndex - uxTextEditor.GetCharacterIndexFromLineIndex(row);
            }
            uxStatus.Text = "Line " + (row + 1) + ", Char " + (col + 1);
            uxProgressBar.Value = uxTextEditor.Text.Length;
            uxPercent.Text = $"{100 * uxProgressBar.Value / max}%";
        }
    }
}
