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
WHERE n.Role = 'STUDENT';
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

        public void AddStudent(string vardas, string pavarde, string login, string password, int grupeId)
        {
            using var conn = Database.GetConnection();
            using var tx = conn.BeginTransaction();

            try
            {
                
                string insertUserSql = @"
INSERT INTO Naudotojai (Vardas, Pavarde, Role, Login, Slaptazodis)
VALUES (@vardas, @pavarde, 'STUDENT', @login, @password);
SELECT last_insert_rowid();
";

                long naudotojasId;

                using (var cmdUser = new SqliteCommand(insertUserSql, conn, tx))
                {
                    cmdUser.Parameters.AddWithValue("@vardas", vardas);
                    cmdUser.Parameters.AddWithValue("@pavarde", pavarde);
                    cmdUser.Parameters.AddWithValue("@login", login);
                    cmdUser.Parameters.AddWithValue("@password", password);

                    naudotojasId = (long)cmdUser.ExecuteScalar();
                }

                string insertStudentSql = @"
INSERT INTO Studentai (NaudotojasId, GrupeId)
VALUES (@naudotojasId, @grupeId);
";

                using (var cmdStudent = new SqliteCommand(insertStudentSql, conn, tx))
                {
                    cmdStudent.Parameters.AddWithValue("@naudotojasId", naudotojasId);
                    cmdStudent.Parameters.AddWithValue("@grupeId", grupeId);
                    cmdStudent.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public void DeleteStudent(int studentasId)
        {
            using var conn = Database.GetConnection();
            using var tx = conn.BeginTransaction();

            try
            {
                int naudotojasId = -1;
                string getUserSql = "SELECT NaudotojasId FROM Studentai WHERE Id = @id";

                using (var cmdGet = new SqliteCommand(getUserSql, conn, tx))
                {
                    cmdGet.Parameters.AddWithValue("@id", studentasId);
                    var result = cmdGet.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        naudotojasId = System.Convert.ToInt32(result);
                    }
                }

                string deleteStudentSql = "DELETE FROM Studentai WHERE Id = @id";
                using (var cmdDelStudent = new SqliteCommand(deleteStudentSql, conn, tx))
                {
                    cmdDelStudent.Parameters.AddWithValue("@id", studentasId);
                    cmdDelStudent.ExecuteNonQuery();
                }

                if (naudotojasId > 0)
                {
                    string deleteUserSql = "DELETE FROM Naudotojai WHERE Id = @id";
                    using (var cmdDelUser = new SqliteCommand(deleteUserSql, conn, tx))
                    {
                        cmdDelUser.Parameters.AddWithValue("@id", naudotojasId);
                        cmdDelUser.ExecuteNonQuery();
                    }
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public void PridetiStudenta(string vardas, string pavarde, string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
