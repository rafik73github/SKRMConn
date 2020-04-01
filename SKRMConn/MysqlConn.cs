using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace SKRMConn
{
    class MysqlConn
    {
        //string dataFromQuery;
        readonly string skrmConnString;
        readonly List<string> skrmDataList = new List<string>();

        public MysqlConn(string skrmConnString)
        {
            this.skrmConnString = skrmConnString;
        }

        public List<string> DoConn(string columnName , string sql)
        {
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


               // MessageBox.Show("ServerVersion: " + SkrmConn.ServerVersion +
               // "\nState: " + SkrmConn.State.ToString() + "\nDatabase: " + SkrmConn.Database);
               SkrmConn.Close();
            }
            catch (Exception connErr)
            {
                
                MessageBox.Show(connErr.ToString());
               
            }
            return skrmDataList;
        }

    }
}
