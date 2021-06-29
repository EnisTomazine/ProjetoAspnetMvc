using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;    
using System.Text;

namespace Database
{
    public class Dono
    {

        private string sqlConn() {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista() {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Donos";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
        }

        public void Salvar(int id, string nome)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into donos(nome) values('" + nome + "')";
                if(id != 0)
                {
                    queryString = "update donos set nome = '" + nome + "' where id = " + id;
                }
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

                


            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Donos where id = "+ id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {

                if (id != 0)
                {
                    string queryString = "delete from Donos where id =" + id;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                }

            }
        }
    }
}
