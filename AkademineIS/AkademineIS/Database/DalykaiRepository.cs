using System;
using System.Collections.Generic;
using System.Text;
using AkademineIS.Models;
using Microsoft.Data.Sqlite;

namespace AkademineIS.Database
{
    public class DalykaiRepository : IDalykaiRepository
    {
        public IEnumerable<Dalykas> GetAll()
        {
            var list = new List<Dalykas>();

            using var conn = Database.GetConnection();
            string sql = "SELECT Id, Pavadinimas FROM Dalykai";

            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Dalykas
                {
                    Id = reader.GetInt32(0),
                    Pavadinimas = reader.GetString(1)
                });
            }

            return list;
        }

        public void Add(Dalykas dalykas)
        {
            using var conn = Database.GetConnection();
            string sql = "INSERT INTO Dalykai (Pavadinimas) VALUES (@pavadinimas)";
            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@pavadinimas", dalykas.Pavadinimas);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = Database.GetConnection();
            string sql = "DELETE FROM Dalykai WHERE Id = @id";
            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}