using System.Net.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClarityAssessment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EmailWindow.ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendMail();
        }
        private async Task SendMail()
        {
            SendEmail.EmailSender se = new SendEmail.EmailSender();

            String senderStr = EmailSenderField.Text;
            String recipientStr = EmailRecipientField.Text;
            String subjectStr = EmailSubjectField.Text;
            String messageStr = EmailMessageField.Text;

            string response = await Task.Run( () => { return se.sendEmail(senderStr, recipientStr, subjectStr, messageStr); });

            if (response.Equals("success"))
            {
                EmailSuccessPopup popup = new EmailSuccessPopup();
                popup.Show();
            }
            else if (response.Equals("invalid"))
            {
                EmailInvalidPopup popup = new EmailInvalidPopup();
                popup.Show();
            }
            else if (response.Equals("timeout"))
            {
                EmailTimeoutPopup popup = new EmailTimeoutPopup();
                popup.Show();
            }
        }

        private void Button_Click_Other_Page(object sender, RoutedEventArgs e)
        {
            OtherPage otherPage = new OtherPage();
            otherPage.Show();
            Close();
        }
    }
}