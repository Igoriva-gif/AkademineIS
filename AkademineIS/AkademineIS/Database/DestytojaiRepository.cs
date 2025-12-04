using System;
using System.Collections.Generic;
using System.Text;
using AkademineIS.Models;
using Microsoft.Data.Sqlite;

namespace AkademineIS.Database
{
    public class DestytojaiRepository : IDestytojaiRepository
    {
        public IEnumerable<DestytojoEile> GetAll()
        {
            var list = new List<DestytojoEile>();

            using var conn = Database.GetConnection();
            string sql = @"
                SELECT d.Id,
                       n.Vardas,
                       n.Pavarde,
                       n.Login
                FROM Destytojai d
                JOIN Naudotojai n ON d.NaudotojasId = n.Id
                WHERE n.Role = 'TEACHER' OR n.Role = 'DESTYTOJAS';
                ";

            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new DestytojoEile
                {
                    Id = reader.GetInt32(0),
                    Vardas = reader.GetString(1),
                    Pavarde = reader.GetString(2),
                    Login = reader.GetString(3)
                });
            }

            return list;
        }

        public void AddDestytojas(string vardas, string pavarde, string login, string password)
        {
            using var conn = Database.GetConnection();
            using var tx = conn.BeginTransaction();

            try
            {
                string insertUserSql = @"
INSERT INTO Naudotojai (Vardas, Pavarde, Role, Login, Slaptazodis)
VALUES (@vardas, @pavarde, 'DESTYTOJAS', @login, @password);
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

                string insertDestytojasSql = @"
INSERT INTO Destytojai (NaudotojasId)
VALUES (@naudotojasId);
";
                using (var cmdDest = new SqliteCommand(insertDestytojasSql, conn, tx))
                {
                    cmdDest.Parameters.AddWithValue("@naudotojasId", naudotojasId);
                    cmdDest.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public void DeleteDestytojas(int destytojasId)
        {
            using var conn = Database.GetConnection();
            using var tx = conn.BeginTransaction();

            try
            {
                int naudotojasId = -1;
                string getUserSql = "SELECT NaudotojasId FROM Destytojai WHERE Id = @id";

                using (var cmdGet = new SqliteCommand(getUserSql, conn, tx))
                {
                    cmdGet.Parameters.AddWithValue("@id", destytojasId);
                    var result = cmdGet.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        naudotojasId = System.Convert.ToInt32(result);
                    }
                }

                string deleteDestSql = "DELETE FROM Destytojai WHERE Id = @id";
                using (var cmdDelDest = new SqliteCommand(deleteDestSql, conn, tx))
                {
                    cmdDelDest.Parameters.AddWithValue("@id", destytojasId);
                    cmdDelDest.ExecuteNonQuery();
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
    }
}