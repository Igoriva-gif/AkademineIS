using Microsoft.Data.Sqlite;
using AkademineIS.Database;
using AkademineIS.Models;
using AkademineIS.Servisai;
namespace AkademineIS
{
    public partial class PrisijungimoForma : Form
    {
        private readonly Autentifikacija _autentifikacija;
        public PrisijungimoForma()
        {
            InitializeComponent();

            var repo = new NaudotojasRepository();
            _autentifikacija = new Autentifikacija(repo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Įveskite prisijungimo vardą ir slaptažodį!");
                return;
            }

            if (login.Length < 3)
            {
                MessageBox.Show("Prisijungimo vardas turi būti bent 3 simbolių.");
                return;
            }

            if (login.Contains(" "))
            {
                MessageBox.Show("Prisijungimo varde negali būti tarpų.");
                return;
            }

            if (!login.All(c => char.IsLetterOrDigit(c) || c == '.' || c == '_' || c == '-'))
            {
                MessageBox.Show("Prisijungimo varde leidžiamos tik raidės, skaičiai ir simboliai . _ -");
                return;
            }

            if (password.Length < 4)
            {
                MessageBox.Show("Slaptažodis turi būti bent 4 simbolių.");
                return;
            }

            try
            {
                var user = _autentifikacija.Login(login, password);

                if (user == null)
                {
                    MessageBox.Show("Neteisingas prisijungimo vardas arba slaptažodis.");
                    return;
                }

                var role = (user.Role ?? string.Empty).Trim().ToUpperInvariant();
                MessageBox.Show($"Prisijungta kaip {role}: {user.Vardas} {user.Pavarde}");

                if (role == "ADMIN")
                {
                    var adminForm = new AdministratoriausForma(user);
                    adminForm.Show();
                    this.Hide();
                }
                else if (role == "DESTYTOJAS")
                {
                    var destytojasForm = new DestytojoForma(user);
                    destytojasForm.Show();
                    this.Hide();
                }
                else if (role == "STUDENTAS")
                {
                    var studentasForm = new StudentoForma(user);
                    studentasForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nežinoma rolė: " + user.Role);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Įvyko klaida: " + ex.Message);
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
