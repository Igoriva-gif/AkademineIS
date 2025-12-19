using System.IO;
using Microsoft.Data.Sqlite;

namespace AkademineIS.Database
{
    public static class Database
    {
        private static readonly string DbFileName = "akademineIS.db";
        private static readonly string ConnectionString =
            $"Data Source={DbFileName}";

        private static bool _initialized = false;

        public static SqliteConnection GetConnection()
        {
            var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            if (!_initialized)
            {
                InitializeDatabase(conn);
                _initialized = true;
            }

            return conn;
        }

        private static void InitializeDatabase(SqliteConnection conn)
        {
            CreateTables(conn);
            SeedAdminUser(conn);
        }

        private static void CreateTables(SqliteConnection conn)
        {
            string sql = @"
CREATE TABLE IF NOT EXISTS Naudotojai (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Vardas TEXT NOT NULL,
    Pavarde TEXT NOT NULL,
    Role TEXT NOT NULL,
    Login TEXT NOT NULL UNIQUE,
    Slaptazodis TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Grupes (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Pavadinimas TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Studentai (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    NaudotojasId INTEGER NOT NULL,
    GrupeId INTEGER NOT NULL,
    FOREIGN KEY (NaudotojasId) REFERENCES Naudotojai(Id),
    FOREIGN KEY (GrupeId) REFERENCES Grupes(Id)
);

CREATE TABLE IF NOT EXISTS Destytojai (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    NaudotojasId INTEGER NOT NULL,
    FOREIGN KEY (NaudotojasId) REFERENCES Naudotojai(Id)
);

CREATE TABLE IF NOT EXISTS Dalykai (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Pavadinimas TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS Pazymiai (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentasId INTEGER NOT NULL,
    DalykasId INTEGER NOT NULL,
    Verte INTEGER NOT NULL,
    FOREIGN KEY (StudentasId) REFERENCES Studentai(Id),
    FOREIGN KEY (DalykasId) REFERENCES Dalykai(Id)
);
CREATE UNIQUE INDEX IF NOT EXISTS idx_pazymiai_studentas_dalykas
ON Pazymiai(StudentasId, DalykasId);
";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }



        private static void SeedAdminUser(SqliteConnection conn)
        {
                       string sql = @"
INSERT INTO Naudotojai (Vardas, Pavarde, Role, Login, Slaptazodis)
SELECT 'Admin', 'Admin', 'ADMIN', 'admin', 'admin'
WHERE NOT EXISTS (SELECT 1 FROM Naudotojai WHERE Login = 'admin');
";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
