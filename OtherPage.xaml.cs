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
    /// This is "the other page". It's just there to demonstrate that the UI is not locked during
    /// the email sending attempts
    /// </summary>
    public partial class OtherPage : Window
    {
        public OtherPage()
        {
            InitializeComponent();
            OtherPageWindow.ResizeMode = ResizeMode.NoResize;
        }

        //Button to go back to Email Sending page
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow emailWindow = new MainWindow();
            emailWindow.Show();
            Close();
        }
    }
}
