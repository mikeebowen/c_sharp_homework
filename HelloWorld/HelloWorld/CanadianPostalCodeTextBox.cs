using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace HelloWorld
{
    public class CanadianPostalCodeTextBox : TextBox
    {
        private string _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";
        private bool _isValidPostalCode = false;
        public bool Valid
        {
            get { return _isValidPostalCode; }
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            //e.Handled = !AreAllValidNumericChars(e.Text);
            if (e.Text.Length >= 6)
            {
                _isValidPostalCode = Regex.Match(e.Text, _caZipRegEx).Success;
                e.Handled = !_isValidPostalCode;
            }
            base.OnPreviewTextInput(e);
        }

        private bool AreAllValidNumericChars(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsNumber(c)) return false;
            }

            return true;
        }
    }
}