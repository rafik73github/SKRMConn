using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace SKRMConn
{
    class XMLRead
    {
        string[] dbDataGet = new string[4];
        

        public bool CheckExistXML()
        {

        if(!File.Exists("db.xml"))
            {
                return false;
            }
        else
            {
                return true;
            }

        }

        public void CreateXML(string serwerXMLText, string databaseXMLTextBox, string userXMLTextBox, string passXMLPassBox)
        {

            XmlTextWriter createFile = new XmlTextWriter("db.xml", Encoding.UTF8);
            createFile.Formatting = Formatting.Indented;
            createFile.WriteStartElement("Root");
            createFile.WriteEndElement();
            createFile.Close();

            XmlDocument doc = new XmlDocument();
            doc.Load("db.xml");

            XmlNode ConnData = doc.CreateElement("ConnData");

            XmlNode sr = doc.CreateElement("sr");
            XmlNode de = doc.CreateElement("de");
            XmlNode ur = doc.CreateElement("ur");
            XmlNode pd = doc.CreateElement("pd");

            sr.InnerText = serwerXMLText;
            de.InnerText = databaseXMLTextBox;
            ur.InnerText = userXMLTextBox;
            pd.InnerText = passXMLPassBox;

            ConnData.AppendChild(sr);
            ConnData.AppendChild(de);
            ConnData.AppendChild(ur);
            ConnData.AppendChild(pd);

            doc.DocumentElement.AppendChild(ConnData);
            doc.Save("db.xml");

        }

        public string[] ReadXML()
        {
            

            XmlDocument doc = new XmlDocument();
            doc.Load("db.xml");

            XmlNodeList nodeList = doc.GetElementsByTagName("ConnData");

            foreach (XmlNode readNodeList in nodeList)
            {
                dbDataGet[0] = readNodeList.SelectSingleNode("sr").InnerText;
                dbDataGet[1] = readNodeList.SelectSingleNode("de").InnerText;
                dbDataGet[2] = readNodeList.SelectSingleNode("ur").InnerText;
                dbDataGet[3] = readNodeList.SelectSingleNode("pd").InnerText;
            }
            return dbDataGet;
        }

    }
}
