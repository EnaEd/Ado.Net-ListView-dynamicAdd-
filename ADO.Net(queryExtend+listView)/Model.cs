using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Для работы с файлом конфигурации
using System.Configuration;
//Для работы с БД
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ADO.Net_queryExtend_listView_
{
    class Model
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        DataSet set = null;
        SqlDataAdapter sda = null;
        SqlCommandBuilder scb = null;
        private DataGridView dataGridView1 = new DataGridView();
        ListView lv = new ListView();
        List<string> lst = new List<string>();
       
       
        public List<string> Command(string txt) {
            set = new DataSet();
            sda = new SqlDataAdapter(txt, conn);
                scb = new SqlCommandBuilder(sda);
            sda.Fill(set,$"book");
            DataTable dt = set.Tables["book"];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.WriteLine(dt.Rows[i][j].ToString());
                    lst.Add(dt.Rows[i][j].ToString());
                }
            }
            
            
                return lst;
            
        }
    }
}
