using AkademineIS.Database;
using AkademineIS.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AkademineIS
{
    public partial class AdministratoriausForma : Form
    {
        private readonly Naudotojas _user;
        private readonly IGrupesRepository _grupesRepo;
        private readonly IStudentaiRepository _studentaiRepo;
        private readonly IDestytojaiRepository _destytojaiRepo;
        private readonly IDalykaiRepository _dalykaiRepo;

        public AdministratoriausForma(Naudotojas user)
        {
            {
                InitializeComponent();

                _user = user;
                _grupesRepo = new GrupesRepository();
                _studentaiRepo = new StudentaiRepository();
                _destytojaiRepo = new DestytojaiRepository();
                _dalykaiRepo = new DalykaiRepository();

                this.Text = $"Administratoriaus langas - {_user.Vardas} {_user.Pavarde}";

                UzkrautiGrupes();
                UzkrautiStudentus();
                UzkrautiGrupesINCombo();
                UzkrautiDestytojus();
                UzkrautiDalykus();
            }
        }
        private bool IsValidName(string text)
        {
            return text.Length >= 2 &&
                   text.All(c => char.IsLetter(c) || c == '-' || c == ' ');
        }

        private bool IsValidLogin(string login)
        {
            if (login.Length < 3)
                return false;
            if (login.Contains(" "))
                return false;

            return login.All(c => char.IsLetterOrDigit(c) || c == '.' || c == '_' || c == '-');
        }

        private bool IsValidTitle(string text)
        {
            text = text.Trim();
            if (text.Length < 2 || text.Length > 30)
                return false;

            return text.All(c => char.IsLetterOrDigit(c) || c == '-' || c == ' ' || c == '.');
        }

        private void UzkrautiGrupes()
        {
            var grupes = _grupesRepo.GetAll();
            dgvGrupes.DataSource = grupes.ToList();
        }
        private void UzkrautiStudentus()
        {
            var studentai = _studentaiRepo.GetAll();
            dgvStudentai.DataSource = studentai.ToList();
        }

        private void UzkrautiGrupesINCombo()
        {
            var grupes = _grupesRepo.GetAll().ToList();
            cmbStudentoGrupe.DataSource = grupes;
            cmbStudentoGrupe.DisplayMember = "Pavadinimas";
            cmbStudentoGrupe.ValueMember = "Id";
        }
        private void UzkrautiDestytojus()
        {
            var destytojai = _destytojaiRepo.GetAll().ToList();
            dgvDestytojai.DataSource = destytojai;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPridetiGrupe_Click(object sender, EventArgs e)
        {
            var pavadinimas = txtNaujaGrupe.Text.Trim();

            if (!IsValidTitle(pavadinimas))
            {
                MessageBox.Show("Grupės pavadinimas turi būti nuo 2 iki 30 simbolių ir negali turėti netinkamų simbolių.");
                return;
            }

            try
            {
                _grupesRepo.Add(new Grupe { Pavadinimas = pavadinimas });
                txtNaujaGrupe.Clear();
                UzkrautiGrupes();
                UzkrautiGrupesINCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Klaida pridedant grupę: " + ex.Message);
            }
        }

        private void btnPasalintiGrupe_Click(object sender, EventArgs e)
        {
            if (dgvGrupes.CurrentRow == null)
            {
                MessageBox.Show("Pasirinkite grupę iš sąrašo.");
                return;
            }

            var grupe = dgvGrupes.CurrentRow.DataBoundItem as Grupe;
            if (grupe == null)
            {
                MessageBox.Show("Nepavyko gauti grupės duomenų.");
                return;
            }

            var result = MessageBox.Show(
                $"Ar tikrai norite pašalinti grupę '{grupe.Pavadinimas}'?",
                "Patvirtinimas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _grupesRepo.Delete(grupe.Id);
                UzkrautiGrupes();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Vardas1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Vardas1(object sender, EventArgs e)
        {
        }

        private void btnPridetiStudenta_Click(object sender, EventArgs e)
        {
            var vardas = txtStudentoVardas.Text.Trim();
            var pavarde = txtStudentoPavarde.Text.Trim();
            var login = txtStudentoLoginas.Text.Trim();
            var password = txtStudentoSlaptazodis.Text.Trim();

            if (string.IsNullOrWhiteSpace(vardas) ||
                string.IsNullOrWhiteSpace(pavarde) ||
                string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Užpildykite visus studento duomenis.");
                return;
            }

            if (!IsValidName(vardas) || !IsValidName(pavarde))
            {
                MessageBox.Show("Vardas ir pavardė turi susidėti tik iš raidžių (gali būti tarpai ir brūkšneliai).");
                return;
            }

            if (!IsValidLogin(login))
            {
                MessageBox.Show("Prisijungimo vardas neteisingas. Leidžiamos raidės, skaičiai ir simboliai . _ -");
                return;
            }

            try
            {
                _studentaiRepo.PridetiStudenta(vardas, pavarde, login, password);
                MessageBox.Show("Studentas pridėtas.");

                txtStudentoVardas.Clear();
                txtStudentoPavarde.Clear();
                txtStudentoLoginas.Clear();
                txtStudentoSlaptazodis.Clear();

                UzkrautiStudentus();
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
            {
                MessageBox.Show("Naudotojas su tokiu prisijungimo vardu jau egzistuoja.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Klaida pridedant studentą: " + ex.Message);
            }
        }

        private void btnPasalintiStudenta_Click(object sender, EventArgs e)
        {
            if (dgvStudentai.CurrentRow == null)
            {
                MessageBox.Show("Pasirinkite studentą iš sąrašo.");
                return;
            }

            if (dgvStudentai.CurrentRow.DataBoundItem is not StudentoEile studentas)
            {
                MessageBox.Show("Nepavyko gauti studento duomenų.");
                return;
            }

            var result = MessageBox.Show(
                $"Ar tikrai norite pašalinti studentą {studentas.Vardas} {studentas.Pavarde}?",
                "Patvirtinimas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _studentaiRepo.DeleteStudent(studentas.Id);
                    UzkrautiStudentus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klaida šalinant studentą: " + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AdministratoriausForma_Load(object sender, EventArgs e)
        {

        }

        private void btnPridetiDestytoja_Click(object sender, EventArgs e)
        {
            var vardas = txtDestVardas.Text.Trim();
            var pavarde = txtDestPavarde.Text.Trim();
            var login = txtDestLoginas.Text.Trim();
            var password = txtDestSlaptazodis.Text.Trim();

            if (string.IsNullOrWhiteSpace(vardas) ||
                string.IsNullOrWhiteSpace(pavarde) ||
                string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Užpildykite visus dėstytojo duomenis.");
                return;
            }

            if (!IsValidName(vardas) || !IsValidName(pavarde))
            {
                MessageBox.Show("Vardas ir pavardė turi susidėti tik iš raidžių (gali būti tarpai ir brūkšneliai).");
                return;
            }

            if (!IsValidLogin(login))
            {
                MessageBox.Show("Prisijungimo vardas neteisingas. Leidžiamos raidės, skaičiai ir simboliai . _ -");
                return;
            }

            try
            {
                _destytojaiRepo.AddDestytojas(vardas, pavarde, login, password);
                MessageBox.Show("Dėstytojas pridėtas.");

                txtDestVardas.Clear();
                txtDestPavarde.Clear();
                txtDestLoginas.Clear();
                txtDestSlaptazodis.Clear();

                UzkrautiDestytojus();
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
            {
                MessageBox.Show("Naudotojas su tokiu prisijungimo vardu jau egzistuoja.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Klaida pridedant dėstytoją: " + ex.Message);
            }
        }

        private void btnPasalintiDestytoja_Click(object sender, EventArgs e)
        {
            if (dgvDestytojai.CurrentRow == null)
            {
                MessageBox.Show("Pasirinkite dėstytoją iš sąrašo.");
                return;
            }

            if (dgvDestytojai.CurrentRow.DataBoundItem is not DestytojoEile dest)
            {
                MessageBox.Show("Nepavyko gauti dėstytojo duomenų.");
                return;
            }

            var result = MessageBox.Show(
                $"Ar tikrai norite pašalinti dėstytoją {dest.Vardas} {dest.Pavarde}?",
                "Patvirtinimas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _destytojaiRepo.DeleteDestytojas(dest.Id);
                    UzkrautiDestytojus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klaida šalinant dėstytoją: " + ex.Message);
                }
            }
        }
        private void UzkrautiDalykus()
        {
            var dalykai = _dalykaiRepo.GetAll().ToList();
            dgvDalykai.DataSource = dalykai;
        }

        private void btnPridetiDalyka_Click(object sender, EventArgs e)
        {
            {
                var pavadinimas = txtNaujasDalykas.Text.Trim();

                if (!IsValidTitle(pavadinimas))
                {
                    MessageBox.Show("Dalyko pavadinimas turi būti nuo 2 iki 30 simbolių ir negali turėti netinkamų simbolių.");
                    return;
                }

                try
                {
                    var dalykas = new Dalykas { Pavadinimas = pavadinimas };
                    _dalykaiRepo.Add(dalykas);
                    txtNaujasDalykas.Clear();
                    UzkrautiDalykus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klaida pridedant dalyką: " + ex.Message);
                }
            }
        }

        private void btnPasalintiDalyka_Click(object sender, EventArgs e)
        {
            if (dgvDalykai.CurrentRow == null)
            {
                MessageBox.Show("Pasirinkite dalyką iš sąrašo.");
                return;
            }

            if (dgvDalykai.CurrentRow.DataBoundItem is not Dalykas dalykas)
            {
                MessageBox.Show("Nepavyko gauti dalyko duomenų.");
                return;
            }

            var result = MessageBox.Show(
                $"Ar tikrai norite pašalinti dalyką '{dalykas.Pavadinimas}'?",
                "Patvirtinimas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _dalykaiRepo.Delete(dalykas.Id);
                    UzkrautiDalykus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klaida šalinant dalyką: " + ex.Message);
                }
            }
        }
    }
}