
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace SKRMConn
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        readonly MysqlConn Conn1 = new MysqlConn();
        XMLRead CheckXML = new XMLRead();

        public MainWindow()
        {
            if(!CheckXML.CheckExistXML())
            {
                
                XMLEdit xmlEditWindow = new XMLEdit();
                this.Close();
                xmlEditWindow.Show();
            }
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
            //   textBox1.Text = Conn1.DoConn("SELECT * FROM events");
            if(xx.Count() == 0 || xx1.Count() == 0)
            {

                XMLEdit xmlEditWindow = new XMLEdit();
                this.Close();
                xmlEditWindow.Show();

            }
            //MessageBox.Show(xx.Count().ToString());
            // xx.Count();
        }
    }
}
