using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Business
{
    public class DogsDonos
    {
        public int IdDono { get; set; }
        public int IdDog { get; set; }
        public string NomeDono { get; set; }
        public string NomeDog { get; set; }

        public List<DogsDonos> Lista()
        {
            var lista = new List<DogsDonos>();
            var dogsDonosDB = new Database.DogsDonos();
            foreach (DataRow row in dogsDonosDB.Lista().Rows)
            {
                var dogDono = new DogsDonos();
                dogDono.IdDog = Convert.ToInt32(row["idDog"]);
                dogDono.IdDono = Convert.ToInt32(row["idDono"]);
                dogDono.NomeDog = row["nomeDog"].ToString();
                dogDono.NomeDono = row["nomeDono"].ToString();
                lista.Add(dogDono);
            }
            return lista;

        }

        public List<DogsDonos> ListaPorId(int dDono)
        {
            var lista = new List<DogsDonos>();
            var dogsDonosDB = new Database.DogsDonos();
            foreach (DataRow row in dogsDonosDB.ListaPorId(dDono).Rows)
            {
                var dogDono = new DogsDonos();
                dogDono.IdDog = Convert.ToInt32(row["idDog"]);
                dogDono.IdDono = Convert.ToInt32(row["idDono"]);
                dogDono.NomeDog = row["nomeDog"].ToString();
                dogDono.NomeDono = row["nomeDono"].ToString();
                lista.Add(dogDono);
            }
            return lista;

        }


        public void Salvar()
        {
            new Database.DogsDonos().Salvar(this.IdDono, this.IdDog);
        }

        public static DogsDonos BuscaPorId(int idDono)
        {
            var listaDonoDogs = new DogsDonos();
            var dogdonoDB = new Database.DogsDonos();
            foreach (DataRow row in dogdonoDB.BuscaPorId(idDono).Rows)
            {
                listaDonoDogs.IdDog = Convert.ToInt32(row["idDog"]);
                listaDonoDogs.IdDono = Convert.ToInt32(row["idDono"]);
                listaDonoDogs.NomeDog = row["nomeDog"].ToString();
                listaDonoDogs.NomeDono = row["nomeDono"].ToString();
                
            }
            return listaDonoDogs;
        }



        public static void Delete(int IdDono, int IdDog)
        {
            new Database.DogsDonos().Delete(IdDono, IdDog);
        }
    }
}
