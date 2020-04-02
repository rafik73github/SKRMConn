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

namespace SKRMConn
{
    /// <summary>
    /// Logika interakcji dla klasy XMLEdit.xaml
    /// </summary>
    public partial class XMLEdit : Window
    {
        public XMLEdit()
        {
            InitializeComponent();
        }

        readonly XMLRead SessionXML = new XMLRead();


        private void SaveXMLButton_Click(object sender, RoutedEventArgs e)
        {

            string serwerXMLText = SerwerXMLTextBox.Text;
            string databaseXMLTextBox = DatabaseXMLTextBox.Text;
            string userXMLTextBox = UserXMLTextBox.Text;
            string passXMLPassBox = PassXMLPassBox.Password;

            if (serwerXMLText == "" || databaseXMLTextBox == "" || userXMLTextBox == "" || passXMLPassBox == "")
            {
                MessageBox.Show("Wypełnij wszystkie pola !");
            }
            else
            {
                SessionXML.CreateXML(serwerXMLText, databaseXMLTextBox, userXMLTextBox, passXMLPassBox);
            }

        }
    }
}
