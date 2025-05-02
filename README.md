Clarity Coding Assesment

By Troy Lewis

My implementation uses WPF as a frontend. It works flawlessly within Visual Studio, but may not work as a raw WPF .exe until you install NuGet dependencies within VS.

My solution is very lightweight on libraries and dependencies. I used a new gmail account as the default sender, authenticating with an app password from google.
The mail library used is the default System.Net.Mail library, and for storage I used an SQLite database from the System.Data.SQLite library.
/bin folder is included in git to include the SendMail.dll where the main email sending logic is packaged.

Emails can be sent from the default tclewiscodetest@gmail.com to any recipient email address. The app password credentials are stored in appsettings. 
Note the button for navigating to "Another page". The "other page" is just a dummy page with no use. The purpose of this is to demonstrate that emails are sent
asynchronously, so you can still navigate within the app while the email is attempting to send. 

All emails are logged in an sqlite database within the /bin folder (same place as .dll). 
There is a button on the main window that will print all rows of the email database to the debug console.

There is field validation (for null and invalid format) for the recipient field. A popup window will notify of an invalid format.
In the case of a failed send, the program will retry up to 3 times with a 3 second pause between tries.
If all 3 tries are unsuccessful, you will receive a popup notification of the failure and the sending is cancelled. 

Successful sends will also generate a success popup.

Thanks!

