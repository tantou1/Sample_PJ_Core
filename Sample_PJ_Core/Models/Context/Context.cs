using System;
using System.Collections.Generic;
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
                            sTANTOUSHA = reader["sTANTOUSHA"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
