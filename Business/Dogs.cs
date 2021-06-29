using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class Dogs
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Raca { get; set; }

        public List<Dogs> Lista()
        {
            var lista = new List<Dogs>();
            var dogDB = new Database.Dogs();
            foreach (DataRow row in dogDB.Lista().Rows)
            {
                var dog = new Dogs();
                dog.Id = Convert.ToInt32(row["id"]);
                dog.Nome = row["nome"].ToString();
                dog.Raca = row["raca"].ToString();
                lista.Add(dog);
            }
            return lista;

        }

        public void Salvar()
        {
            new Database.Dogs().Salvar(this.Id, this.Nome, this.Raca);
        }

        public static Dogs BuscaPorId(int id)
        {
            var dog = new Dogs();
            var dogDB = new Database.Dogs();
            foreach (DataRow row in dogDB.BuscaPorId(id).Rows)
            {
                dog.Id = Convert.ToInt32(row["id"]);
                dog.Nome = row["nome"].ToString();
                dog.Raca = row["raca"].ToString();
            }
            return dog;
        }

        public static void Delete(int Id)
        {
            new Database.Dogs().Delete(Id);
        }
    }
}
