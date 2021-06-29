using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Database
{
    public class DogsDonos
    {

        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select c.id as idDog, c.nome as nomeDog, d.id as idDono, d.nome as nomeDono  " +
                    "from Caes_Donos as cd inner Join Caes as c on cd.Id_cao = c.Id " +
                    "inner join Donos as d on cd.Id_dono = d.Id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
        }

        public DataTable ListaPorId(int idDono)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select c.id as idDog, c.nome as nomeDog, d.id as idDono, d.nome as nomeDono  " +
                   "from Caes_Donos as cd inner Join Caes as c on cd.Id_cao = c.Id " +
                   "inner join Donos as d on cd.Id_dono = d.Id where cd.Id_dono =" + idDono;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
        }

        public void Salvar(int idDono, int idDog)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into Caes_Donos(Id_dono, Id_Cao) values('" + idDono + "', '" + idDog + "')";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();




            }
        }

        public DataTable BuscaPorId(int idDono)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select c.id as idDog, c.nome as nomeDog, d.id as idDono, d.nome as nomeDono  " +
                    "from Caes_Donos as cd inner Join Caes as c on cd.Id_cao = c.Id " +
                    "inner join Donos as d on cd.Id_dono = d.Id where cd.Id_dono =" + idDono;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
        }

        public void Delete(int idDono, int idDog)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {

                if (idDono != 0 && idDog != 0)
                {
                    string queryString = "delete from Caes_Donos where id_dono =" + idDono + " and id_cao =" + idDog;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                }

            }
        }
    }
}
