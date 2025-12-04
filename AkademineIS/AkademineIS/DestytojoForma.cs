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

namespace AkademineIS
{
    public partial class DestytojoForma : Form
    {
        private readonly Naudotojas _user;
        private readonly IGrupesRepository _grupesRepo;
        private readonly IDalykaiRepository _dalykaiRepo;
        private readonly IPazymiaiRepository _pazymiaiRepo;

        private int _pasirinktaGrupeId;
        private int _pasirinktasDalykasId;

        public DestytojoForma(Naudotojas user)
        {
            InitializeComponent();
            dgvPazymiai.EditingControlShowing += dgvPazymiai_EditingControlShowing;
            _user = user;
            _grupesRepo = new GrupesRepository();
            _dalykaiRepo = new DalykaiRepository();
            _pazymiaiRepo = new PazymiaiRepository();

            this.Text = $"Dėstytojo langas - {_user.Vardas} {_user.Pavarde}";

            UzkrautiGrupes();
            UzkrautiDalykus();
        }

        private void dgvPazymiai_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvPazymiai.CurrentCell == null)
                return;

            var owningColumn = dgvPazymiai.CurrentCell.OwningColumn;
            if (owningColumn != null && owningColumn.Name == nameof(PazymioEilute.Pazymys)
                && e.Control is TextBox tb)
            {
                tb.KeyPress -= Pazymys_KeyPress;
                tb.KeyPress += Pazymys_KeyPress;
            }
        }

        private void Pazymys_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void UzkrautiGrupes()
        {
            var grupes = _grupesRepo.GetAll().ToList();
            cmbGrupe.DataSource = grupes;
            cmbGrupe.DisplayMember = "Pavadinimas";
            cmbGrupe.ValueMember = "Id";
        }

        private void UzkrautiDalykus()
        {
            var dalykai = _dalykaiRepo.GetAll().ToList();
            cmbDalykas.DataSource = dalykai;
            cmbDalykas.DisplayMember = "Pavadinimas";
            cmbDalykas.ValueMember = "Id";
        }

        private void btnUzkrauti_Click(object sender, EventArgs e)
        {
            if (cmbGrupe.SelectedItem is not Grupe grupe)
            {
                MessageBox.Show("Pasirinkite grupę.");
                return;
            }

            if (cmbDalykas.SelectedItem is not Dalykas dalykas)
            {
                MessageBox.Show("Pasirinkite dalyką.");
                return;
            }

            _pasirinktaGrupeId = grupe.Id;
            _pasirinktasDalykasId = dalykas.Id;

            var eilutes = _pazymiaiRepo
                .GetByGrupeAndDalykas(_pasirinktaGrupeId, _pasirinktasDalykasId)
                .ToList();

            dgvPazymiai.DataSource = eilutes;

            foreach (DataGridViewColumn col in dgvPazymiai.Columns)
            {
                col.ReadOnly = col.Name != nameof(PazymioEilute.Pazymys);
            }
        }

        private void btnIssaugoti_Click(object sender, EventArgs e)
        {
            {
                if (dgvPazymiai.DataSource is not List<PazymioEilute> eilutes)
                {
                    MessageBox.Show("Nėra duomenų išsaugojimui.");
                    return;
                }

                try
                {
                    foreach (var eil in eilutes)
                    {
                        if (!eil.Pazymys.HasValue)
                            continue; // пустая ячейка

                        int paz = eil.Pazymys.Value;

                        // диапазон 1–10
                        if (paz < 1 || paz > 10)
                        {
                            MessageBox.Show(
                                $"Neteisingas pažymys studentui {eil.StudentasVardas} {eil.StudentasPavarde}: {paz}. " +
                                "Leistinas intervalas yra nuo 1 iki 10.");
                            return;
                        }

                        _pazymiaiRepo.SetPazymys(eil.StudentasId, _pasirinktasDalykasId, paz);
                    }

                    MessageBox.Show("Pažymiai išsaugoti.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klaida išsaugant pažymius: " + ex.Message);
                }
            }
        }
    }
}