
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Data;
using System.Windows.Controls;

namespace SKRMConn
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        readonly MysqlConn Conn1 = new MysqlConn();
        

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

            List<string> xx1 = Conn1.DoConn("id_event", "SELECT * FROM events ORDER BY event ASC");
            foreach (string a1 in xx1)
            {
                comboBox1.Items.Add(a1);
            }
           
            if(xx.Count() == 0 || xx1.Count() == 0)
            {

                XMLEdit xmlEditWindow = new XMLEdit();
                this.Close();
                xmlEditWindow.Show();

            }
            //MessageBox.Show(xx.Count().ToString());
           
        }

        private void ConnButton2_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt1 = Conn1.GetDataMysqlDataTable("SELECT * FROM events ORDER BY event ASC");
            
            dataGrid.ItemsSource = dt1.DefaultView;
            textBox1.Text = dt1.Rows[1]["id_event"].ToString();
            textBox2.Text = dt1.Columns[1].ToString();
            textBox3.Text = dt1.Columns.Count.ToString();
            textBox4.Text = dt1.Rows.Count.ToString();
            //blabla
        }
    }
}
