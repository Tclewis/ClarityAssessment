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
    /// Interaction logic for EmailSuccessPopup.xaml
    /// </summary>
    public partial class EmailSuccessPopup : Window
    {
        public EmailSuccessPopup()
        {
            InitializeComponent();
            SuccessPopupWindow.ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
