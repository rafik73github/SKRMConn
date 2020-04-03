using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SKRMConn
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            XMLRead CheckXML = new XMLRead();
            XMLEdit xmlEditWindow = new XMLEdit();
            MainWindow mainWindow = new MainWindow();

            if (!CheckXML.CheckExistXML())
            {

                xmlEditWindow.Show();

            }
            else
            {

                mainWindow.Show();

            }
        }

}
}
