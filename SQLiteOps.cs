using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;
using System.Diagnostics;


namespace ClarityAssessment
{
    internal class SQLiteOps
    {
        SQLiteConnection sqlite_conn;
        public SQLiteOps()
        {
            sqlite_conn = CreateConnection();
            //CreateTable(sqlite_conn);
            //InsertData();
            //ReadData();
        }

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }
        static void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE Emails(Sender TEXT, Recipient TEXT, Subject TEXT, Message TEXT, Status TEXT)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();

        }
        public void InsertData(string senderStr, string recipientStr, string subjectStr, string messageStr, string statusStr)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"INSERT INTO Emails(Sender, Recipient, Subject, Message, Status) VALUES('{senderStr}', '{recipientStr}', '{subjectStr}', '{messageStr}', '{statusStr}'); ";
            sqlite_cmd.ExecuteNonQuery();
        }
        public void ReadData()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Emails";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                Debug.Write(sqlite_datareader.GetString(0) + "  ");
                Debug.Write(sqlite_datareader.GetString(1) + "  ");
                Debug.Write(sqlite_datareader.GetString(2) + "  ");
                Debug.Write(sqlite_datareader.GetString(3) + "  ");
                Debug.Write(sqlite_datareader.GetString(4) + "  ");
                Debug.WriteLine("");
                Debug.WriteLine("");
            }
            sqlite_conn.Close();
        }
    }
}
