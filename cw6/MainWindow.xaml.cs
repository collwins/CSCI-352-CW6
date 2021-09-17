/* Name: Collin Winstead
 * Date: 9/17/2021
 * File name: MainWindow.xaml.cs
 * Description: This file implements the methods needed to access the Access database and display it to the screen.
 */
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace cw6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\cw6Database.accdb";
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection(connString);
        }

        private void SeeAssetsButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                //read[0] = EmployeeID, read[1] = AssetID, read[2] = Description
                data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }
            TextEntry.Text = data;
            //Close connection
            cn.Close();
        }

        private void SeeEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                //read[0] = EmployeeID, read[1] = LastName, read[2] = FirstName
                data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }
            TextEntry2.Text = data;
            cn.Close();
        }

    }
}

