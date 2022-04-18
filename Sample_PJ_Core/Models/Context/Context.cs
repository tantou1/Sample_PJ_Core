using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Sample_PJ_Core.Models.Editdata;

namespace Sample_PJ_Core.Models.Context
{
    public class Context : DbContext
    {
        public string ConnectionString { get; set; }

        public Context(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Tantousha> GetAllTantousha()
        {
            List<Tantousha> list = new List<Tantousha>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from m_j_tantousha", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Tantousha()
                        {
                            cTANTOUSHA = reader["cTANTOUSHA"].ToString(),
                            sTANTOUSHA = reader["sTANTOUSHA"].ToString(),
                            cBUMON = reader["cBUMON"].ToString(),
                            dHENKOU = Convert.ToDateTime(reader["dHENKOU"].ToString()),
                            cHENKOUSYA= reader["cHENKOUSYA"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void CreateTantousha(Tantousha tantousha)
        {
            using (MySqlConnection conn = GetConnection())
            {
                //conn.Open(); 
                string create_query = "insert into m_j_tantousha (cTANTOUSHA,sTANTOUSHA,cBUMON,dHENKOU,cHENKOUSYA) values (" + "'" + tantousha.cTANTOUSHA + "','" + tantousha.sTANTOUSHA + "','" + tantousha.cBUMON + "','" + tantousha.dHENKOU + "','" + tantousha.cHENKOUSYA + "');";
                MySqlCommand cmd = new MySqlCommand(create_query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void EditTantousha(Tantousha tantousha)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string edit_query = "update m_j_tantousha set sTANTOUSHA='" + tantousha.sTANTOUSHA + "',cBUMON='" + tantousha.cBUMON + "',dHENKOU='" + tantousha.dHENKOU + "',cHENKOUSYA='" + tantousha.cHENKOUSYA + "' where cTANTOUSHA='" + tantousha.cTANTOUSHA + "'";
                MySqlCommand cmd = new MySqlCommand(edit_query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteTantousha(string id)        {            using (MySqlConnection conn = GetConnection())            {                string delete_query = "delete from m_j_tantousha where cTANTOUSHA='" + id + "'";                MySqlCommand cmd = new MySqlCommand(delete_query, conn);                conn.Open();                cmd.ExecuteNonQuery();                conn.Close();            }

        }

        public void DetailTantousha(string id)        {            using (MySqlConnection conn = GetConnection())            {                string detail_query = "select * from m_j_tantousha where cTANTOUSHA='" + id + "'";                MySqlCommand cmd = new MySqlCommand(detail_query, conn);                conn.Open();                cmd.ExecuteNonQuery();                conn.Close();            }

        }
    }
}
