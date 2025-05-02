using System.Configuration;
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
    /// Main Email Sending window
    /// Contains email sending stuff, a button to navigate to another page and a button to print Sqlite
    /// database to console
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLiteOps sql;
        public MainWindow()
        {
            InitializeComponent();
            EmailWindow.ResizeMode = ResizeMode.NoResize;
            sql = new SQLiteOps();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendMail();
        }
        //Main Method to drive sending email
        private async Task SendMail()
        {
            SendEmail.EmailSender se = new SendEmail.EmailSender();

            //Pulling data from input form in window. Sender credentials are pulled from appsettings
            String senderStr = ConfigurationManager.AppSettings["senderEmail"];
            String recipientStr = EmailRecipientField.Text;
            String subjectStr = EmailSubjectField.Text;
            String messageStr = EmailMessageField.Text;
            String credentialsStr = ConfigurationManager.AppSettings["senderPassword"];

            //Calling the actual email sending logic in dll. Request is asynchronous so it doesn't lock the UI
            string response = await Task.Run( () => { return se.sendEmail(senderStr, recipientStr, subjectStr, messageStr, credentialsStr); });

            //Once we have a response, log all the email data into our sqlite database
            sql.InsertData(senderStr, recipientStr, subjectStr, messageStr, response);

            //Showing different dialog boxes for email status
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

        //Button to navigate to the other page
        private void Button_Click_Other_Page(object sender, RoutedEventArgs e)
        {
            OtherPage otherPage = new OtherPage();
            otherPage.Show();
            Close();
        }

        //Button to print sqlite database to console
        private void Button_Click_DBPrint(object sender, RoutedEventArgs e)
        {
            sql.ReadData();
        }
    }
}