using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using AkademineIS.Models;

namespace AkademineIS.Database
{
    public class StudentaiRepository : IStudentaiRepository
    {
        public IEnumerable<StudentoEile> GetAll()
        {
            var list = new List<StudentoEile>();

            using var conn = Database.GetConnection();
            string sql = @"
SELECT s.Id,
       n.Vardas,
       n.Pavarde,
       n.Login,
       g.Pavadinimas AS Grupe
FROM Studentai s
JOIN Naudotojai n ON s.NaudotojasId = n.Id
JOIN Grupes g ON s.GrupeId = g.Id
WHERE n.Role = 'STUDENTAS';
";

            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new StudentoEile
                {
                    Id = reader.GetInt32(0),
                    Vardas = reader.GetString(1),
                    Pavarde = reader.GetString(2),
                    Login = reader.GetString(3),
                    Grupe = reader.GetString(4)
                });
            }

            return list;
        }

        public void AddStudentas(string vardas, string pavarde, string login, string password, string grupeId)
        {
            using var conn = Database.GetConnection();
            using var tx = conn.BeginTransaction();

            try
            {
                string insertUserSql = @"
            INSERT INTO Naudotojai (Vardas, Pavarde, Role, Login, Slaptazodis)
            VALUES (@vardas, @pavarde, 'STUDENTAS', @login, @password);
            SELECT last_insert_rowid();
        ";

                long naudotojasId;

                using (var cmdUser = new SqliteCommand(insertUserSql, conn, tx))
                {
                    cmdUser.Parameters.AddWithValue("@vardas", vardas);
                    cmdUser.Parameters.AddWithValue("@pavarde", pavarde);
                    cmdUser.Parameters.AddWithValue("@login", login);
                    cmdUser.Parameters.AddWithValue("@password", password);

                    var scalarResult = cmdUser.ExecuteScalar();
                    if (scalarResult == null || scalarResult == DBNull.Value)
                    {
                        throw new InvalidOperationException("Failed to insert Naudotojai or retrieve new Id.");
                    }
                    naudotojasId = Convert.ToInt64(scalarResult);
                }

                string insertStudentSql = @"
            INSERT INTO Studentai (NaudotojasId, GrupeId)
            VALUES (@naudotojasId, @grupeId);
        ";

                using (var cmdStud = new SqliteCommand(insertStudentSql, conn, tx))
                {
                    cmdStud.Parameters.AddWithValue("@naudotojasId", naudotojasId);
                    cmdStud.Parameters.AddWithValue("@grupeId", grupeId);

                    cmdStud.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }


        public void DeleteStudentas(int studentasId)
        {
            using var conn = Database.GetConnection();
            using var tx = conn.BeginTransaction();

            try
            {
                using (var cmdFkOff = new SqliteCommand("PRAGMA foreign_keys = OFF;", conn, tx))
                {
                    cmdFkOff.ExecuteNonQuery();
                }

                int naudotojasId = -1;
                const string getUserSql = "SELECT NaudotojasId FROM Studentai WHERE Id = @id";

                using (var cmdGet = new SqliteCommand(getUserSql, conn, tx))
                {
                    cmdGet.Parameters.AddWithValue("@id", studentasId);
                    var result = cmdGet.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        naudotojasId = Convert.ToInt32(result);
                    }
                }

                const string deleteMarksSql = "DELETE FROM Pazymiai WHERE StudentasId = @id";
                using (var cmdMarks = new SqliteCommand(deleteMarksSql, conn, tx))
                {
                    cmdMarks.Parameters.AddWithValue("@id", studentasId);
                    cmdMarks.ExecuteNonQuery();
                }

                const string deleteStudentasSql = "DELETE FROM Studentai WHERE Id = @id";
                using (var cmdStud = new SqliteCommand(deleteStudentasSql, conn, tx))
                {
                    cmdStud.Parameters.AddWithValue("@id", studentasId);
                    cmdStud.ExecuteNonQuery();
                }

                if (naudotojasId > 0)
                {
                    const string deleteUserSql = "DELETE FROM Naudotojai WHERE Id = @id";
                    using (var cmdUser = new SqliteCommand(deleteUserSql, conn, tx))
                    {
                        cmdUser.Parameters.AddWithValue("@id", naudotojasId);
                        cmdUser.ExecuteNonQuery();
                    }
                }

                using (var cmdFkOn = new SqliteCommand("PRAGMA foreign_keys = ON;", conn, tx))
                {
                    cmdFkOn.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }
}