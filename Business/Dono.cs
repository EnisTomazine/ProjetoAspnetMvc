using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class Dono
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Dono> Lista() 
        {
            var lista = new List<Dono>();
            var donoDB = new Database.Dono();
            foreach (DataRow row in donoDB.Lista().Rows)
            {
                var dono = new Dono();
                dono.Id = Convert.ToInt32(row["id"]);
                dono.Nome = row["nome"].ToString();
                lista.Add(dono);
            }
            return lista;
        
        }

        public void Salvar()
        {
            new Database.Dono().Salvar(this.Id, this.Nome);
        }

        public static Dono BuscaPorId(int id)
        {
            var dono = new Dono();
            var donoDB = new Database.Dono();
            foreach (DataRow row in donoDB.BuscaPorId(id).Rows)
            {
                dono.Id = Convert.ToInt32(row["id"]);
                dono.Nome = row["nome"].ToString();
            }
            return dono;
        }

        public static void Delete(int Id)
        {
            new Database.Dono().Delete(Id);
        }
    }
}
