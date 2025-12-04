using AkademineIS.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkademineIS.Database
{
    public interface IPazymiaiRepository
    {
        IEnumerable<PazymioEilute> GetByGrupeAndDalykas(int grupeId, int dalykasId);
        void SetPazymys(int studentasId, int dalykasId, int pazymys);
        public IEnumerable<PazymioEilute> GetForStudent(int studentId)
        {
            var list = new List<PazymioEilute>();

            using var conn = Database.GetConnection();
            string sql = @"
                SELECT s.Id,
                       n.Vardas,
                       n.Pavarde,
                       g.Pavadinimas AS Grupe,
                       d.Pavadinimas AS Dalykas,
                       p.Verte AS Pazymys
                FROM Studentai s
                JOIN Naudotojai n ON s.NaudotojasId = n.Id
                JOIN Grupes g ON s.GrupeId = g.Id
                JOIN Dalykai d
                LEFT JOIN Pazymiai p 
                        ON p.StudentasId = s.Id AND p.DalykasId = d.Id
                WHERE s.Id = @studentId;
                ";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@studentId", studentId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PazymioEilute
                {
                    StudentasId = reader.GetInt32(0),
                    StudentasVardas = reader.GetString(1),
                    StudentasPavarde = reader.GetString(2),
                    Grupe = reader.GetString(3),
                    Dalykas = reader.GetString(4),
                    Pazymys = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5)
                });
            }

            return list;
        }
    }
}
    