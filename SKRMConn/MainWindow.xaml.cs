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

namespace SKRMConn
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        readonly MysqlConn Conn1 = new MysqlConn("");
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> xx = Conn1.DoConn("event","SELECT * FROM events ORDER BY event ASC");
            foreach (string a in xx)
            {
                comboBox.Items.Add(a);
            }
             //   textBox1.Text = Conn1.DoConn("SELECT * FROM events");
        }
    }
}
