using System;
using System.Collections.Generic;
using System.Text;
using AkademineIS.Models;
using Microsoft.Data.Sqlite;

namespace AkademineIS.Database
{
    public class PazymiaiRepository : IPazymiaiRepository
    {
        public IEnumerable<PazymioEilute> GetByGrupeAndDalykas(int grupeId, int dalykasId)
        {
            var list = new List<PazymioEilute>();

            using var conn = Database.GetConnection();
            string sql = @"
SELECT s.Id AS StudentasId,
       n.Vardas,
       n.Pavarde,
       g.Pavadinimas AS Grupe,
       p.Verte AS Pazymys
FROM Studentai s
JOIN Naudotojai n ON s.NaudotojasId = n.Id
JOIN Grupes g ON s.GrupeId = g.Id
LEFT JOIN Pazymiai p ON p.StudentasId = s.Id AND p.DalykasId = @dalykasId
WHERE s.GrupeId = @grupeId;
";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@grupeId", grupeId);
            cmd.Parameters.AddWithValue("@dalykasId", dalykasId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PazymioEilute
                {
                    StudentasId = reader.GetInt32(0),
                    StudentasVardas = reader.GetString(1),
                    StudentasPavarde = reader.GetString(2),
                    Grupe = reader.GetString(3),
                    Pazymys = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                });
            }

            return list;
        }

        public void SetPazymys(int studentasId, int dalykasId, int pazymys)
        {
            using var conn = Database.GetConnection();

            
            string checkSql = @"
                SELECT Id FROM Pazymiai
                WHERE StudentasId = @studentasId AND DalykasId = @dalykasId;
                ";

            int? existingId = null;
            using (var cmdCheck = new SqliteCommand(checkSql, conn))
            {
                cmdCheck.Parameters.AddWithValue("@studentasId", studentasId);
                cmdCheck.Parameters.AddWithValue("@dalykasId", dalykasId);

                var result = cmdCheck.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    existingId = System.Convert.ToInt32(result);
                }
            }

            if (existingId.HasValue)
            {
                
                string updateSql = "UPDATE Pazymiai SET Verte = @pazymys WHERE Id = @id";
                using var cmdUpdate = new SqliteCommand(updateSql, conn);
                cmdUpdate.Parameters.AddWithValue("@pazymys", pazymys);
                cmdUpdate.Parameters.AddWithValue("@id", existingId.Value);
                cmdUpdate.ExecuteNonQuery();
            }
            else
            {
                
                string insertSql = @"
                    INSERT INTO Pazymiai (StudentasId, DalykasId, Verte)
                    VALUES (@studentasId, @dalykasId, @pazymys);
                    ";
                using var cmdInsert = new SqliteCommand(insertSql, conn);
                cmdInsert.Parameters.AddWithValue("@studentasId", studentasId);
                cmdInsert.Parameters.AddWithValue("@dalykasId", dalykasId);
                cmdInsert.Parameters.AddWithValue("@pazymys", pazymys);
                cmdInsert.ExecuteNonQuery();
            }
        }
        public IEnumerable<PazymioEilute> GetForStudent(int studentasId)
        {
            var list = new List<PazymioEilute>();

            using var conn = Database.GetConnection();
            string sql = @"
                SELECT d.Pavadinimas AS Dalykas,
                       p.Verte AS Pazymys
                FROM Pazymiai p
                JOIN Dalykai d ON d.Id = p.DalykasId
                WHERE p.StudentasId = @studentasId
                ORDER BY d.Pavadinimas;
                ";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@studentasId", studentasId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PazymioEilute
                {
                    Dalykas = reader.GetString(0),
                    Pazymys = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1)
                });
            }

            return list;
        }

    }
}