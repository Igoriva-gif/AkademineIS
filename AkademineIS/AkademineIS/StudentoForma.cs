using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using AkademineIS.Models;
using AkademineIS.Database;
using Microsoft.Data.Sqlite;

namespace AkademineIS
{
    public partial class StudentoForma : Form
    {
        private readonly Naudotojas _user;
        private readonly IPazymiaiRepository _pazymiaiRepo;
        private int _studentoId;

        public StudentoForma(Naudotojas user)
        {

            InitializeComponent();

            _user = user;
            _pazymiaiRepo = new PazymiaiRepository();

            this.Text = $"Studento langas - {_user.Vardas} {_user.Pavarde}";

            _studentoId = GautiStudentoId(_user.Id);

            UzkrautiPazymius();
        }

        private int GautiStudentoId(int naudotojasId)
        {
            using var conn = AkademineIS.Database.Database.GetConnection();
            using var cmd = new SqliteCommand(
                "SELECT Id FROM Studentai WHERE NaudotojasId = @id", conn);

            cmd.Parameters.AddWithValue("@id", naudotojasId);

            var result = cmd.ExecuteScalar();

            if (result == null || result == DBNull.Value)
            {
                throw new Exception(
                    "Studento įrašas lentelėje nerastas. " +
                    "Patikrinkite, ar studentas pridėtas administratoriaus lange.");
            }

            return Convert.ToInt32(result);
        }

        private void UzkrautiPazymius()
        {
            var eilutes = _pazymiaiRepo
        .GetForStudent(_studentoId)
        .Select(e => new
        {
            Dalykas = e.Dalykas,
            Pazymys = e.Pazymys.HasValue ?
                      e.Pazymys.Value.ToString() :
                      "–"
        })
        .ToList();

            dgvPazymiai.DataSource = eilutes;

            dgvPazymiai.ReadOnly = true;
            dgvPazymiai.AllowUserToAddRows = false;
            dgvPazymiai.AllowUserToDeleteRows = false;
            dgvPazymiai.MultiSelect = false;
            dgvPazymiai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPazymiai.RowHeadersVisible = false;
            dgvPazymiai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvPazymiai.Columns["Dalykas"] != null)
                dgvPazymiai.Columns["Dalykas"].HeaderText = "Dalykas";

            if (dgvPazymiai.Columns["Pazymys"] != null)
                dgvPazymiai.Columns["Pazymys"].HeaderText = "Pažymys";
        }
    }
}