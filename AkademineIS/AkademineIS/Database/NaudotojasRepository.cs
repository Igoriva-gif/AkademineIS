using System;
using System.Collections.Generic;
using System.Text;
using AkademineIS.Database;
using AkademineIS.Models;
using Microsoft.Data.Sqlite;

namespace AkademineIS.Database
{
    public class NaudotojasRepository : INaudotojasRepository
    {
        public Naudotojas? GetByLogin(string login)
        {
            using var conn = Database.GetConnection();
            string sql = @"
SELECT Id, Vardas, Pavarde, Role, Login, Slaptazodis
FROM Naudotojai
WHERE Login = @login;
";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@login", login);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Naudotojas
                {
                    Id = reader.GetInt32(0),
                    Vardas = reader.GetString(1),
                    Pavarde = reader.GetString(2),
                    Role = reader.GetString(3),
                    Login = reader.GetString(4),
                    Slaptazodis = reader.GetString(5)
                };
            }

            return null;
        }
    }
}
