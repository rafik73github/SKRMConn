using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Data;

namespace SKRMConn
{
    class MysqlConn
    {
        //string dataFromQuery;
        string skrmConnString;
        readonly List<string> skrmDataList = new List<string>();
        XMLRead getDBCredentials = new XMLRead();

        public List<string> DoConn(string columnName , string sql)
        {
            string[] crDB = getDBCredentials.ReadXML();

            skrmConnString = "Server ="+crDB[0]+"; Database = "+crDB[1]+"; Uid = "+crDB[2]+"; Pwd = "+crDB[3]+";";

            skrmDataList.Clear();
            MySqlConnection SkrmConn = new MySqlConnection(skrmConnString);
            try
            {
                SkrmConn.Open();
                MySqlCommand Cmd = new MySqlCommand(sql, SkrmConn);
                MySqlDataReader rdr = Cmd.ExecuteReader();

                
                // while (rdr.Read())
                // {
                //    win.textBox1.Text = rdr.GetString(1);
                // }

                while (rdr.Read())
                {
                   //dataFromQuery += rdr.GetValue(1).ToString();
                    //skrmDataList.Add(rdr.GetValue(columnNumber).ToString());
                    skrmDataList.Add(rdr.GetString(columnName).ToString());
                }

               SkrmConn.Close();
                return skrmDataList;
            }
            catch (Exception connErr)
            {
                
                MessageBox.Show(connErr.ToString());
                
                skrmDataList.Clear();
                return skrmDataList;
            }
            
            
        }

        public DataTable GetDataMysql(string sql1)
        {
            string[] crDB = getDBCredentials.ReadXML();
            skrmConnString = "Server =" + crDB[0] + "; Database = " + crDB[1] + "; Uid = " + crDB[2] + "; Pwd = " + crDB[3] + ";";
            MySqlConnection SkrmConn1 = new MySqlConnection(skrmConnString);
            DataTable dt = new DataTable("Test");
            try
            {
                SkrmConn1.Open();
                
                MySqlDataAdapter returnVal = new MySqlDataAdapter(sql1, SkrmConn1);
                
                returnVal.Fill(dt);
                SkrmConn1.Close();
                
            }
            catch (Exception connErr)
            {

                MessageBox.Show(connErr.ToString());

            }
            return dt;
        }

     }
}
