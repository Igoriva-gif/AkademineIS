using System;
using System.Collections.Generic;
using AkademineIS.Database;
using AkademineIS.Models;
using Microsoft.Data.Sqlite;

namespace AkademineIS.Database
{
    public class GrupesRepository : IGrupesRepository
    {
        public IEnumerable<Grupe> GetAll()
        {
            var list = new List<Grupe>();

            using var conn = Database.GetConnection();
            string sql = "SELECT Id, Pavadinimas FROM Grupes";

            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Grupe
                {
                    Id = reader.GetInt32(0),
                    Pavadinimas = reader.GetString(1)
                });
            }

            return list;
        }

        public void Add(Grupe grupe)
        {
            using var conn = Database.GetConnection();
            string sql = "INSERT INTO Grupes (Pavadinimas) VALUES (@pavadinimas)";
            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@pavadinimas", grupe.Pavadinimas);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = Database.GetConnection();
            string sql = "DELETE FROM Grupes WHERE Id = @id";
            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}

