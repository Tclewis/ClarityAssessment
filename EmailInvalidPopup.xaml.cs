using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClarityAssessment
{
    /// <summary>
    /// Simple information dialog box for status of email
    /// </summary>
    public partial class EmailInvalidPopup : Window
    {
        public EmailInvalidPopup()
        {
            InitializeComponent();
            InvalidPopupWindow.ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
