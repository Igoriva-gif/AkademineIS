using AkademineIS.Database;

namespace AkademineIS
{
    partial class AdministratoriausForma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dgvGrupes = new DataGridView();
            txtNaujaGrupe = new TextBox();
            btnPridetiGrupe = new Button();
            btnPasalintiGrupe = new Button();
            label2 = new Label();
            dgvStudentai = new DataGridView();
            Vardas = new Label();
            txtStudentoVardas = new TextBox();
            label3 = new Label();
            Pavarde = new Label();
            txtStudentoPavarde = new TextBox();
            label4 = new Label();
            txtStudentoLoginas = new TextBox();
            label5 = new Label();
            txtStudentoSlaptazodis = new TextBox();
            label6 = new Label();
            cmbStudentoGrupe = new ComboBox();
            btnPridetiStudenta = new Button();
            btnPasalintiStudenta = new Button();
            label7 = new Label();
            dgvDestytojai = new DataGridView();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtDestVardas = new TextBox();
            txtDestPavarde = new TextBox();
            txtDestLoginas = new TextBox();
            txtDestSlaptazodis = new TextBox();
            btnPridetiDestytoja = new Button();
            btnPasalintiDestytoja = new Button();
            label12 = new Label();
            dgvDalykai = new DataGridView();
            label13 = new Label();
            txtNaujasDalykas = new TextBox();
            btnPridetiDalyka = new Button();
            btnPasalintiDalyka = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGrupes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudentai).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDestytojai).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDalykai).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(151, 34);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 0;
            label1.Text = "Grupės:";
            label1.Click += label1_Click;
            // 
            // dgvGrupes
            // 
            dgvGrupes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvGrupes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrupes.Location = new Point(12, 77);
            dgvGrupes.Name = "dgvGrupes";
            dgvGrupes.ReadOnly = true;
            dgvGrupes.RowHeadersWidth = 62;
            dgvGrupes.Size = new Size(347, 152);
            dgvGrupes.TabIndex = 1;
            dgvGrupes.CellContentClick += dataGridView1_CellContentClick;
            // 
            // txtNaujaGrupe
            // 
            txtNaujaGrupe.Location = new Point(161, 240);
            txtNaujaGrupe.Name = "txtNaujaGrupe";
            txtNaujaGrupe.Size = new Size(129, 31);
            txtNaujaGrupe.TabIndex = 2;
            // 
            // btnPridetiGrupe
            // 
            btnPridetiGrupe.Location = new Point(65, 287);
            btnPridetiGrupe.Name = "btnPridetiGrupe";
            btnPridetiGrupe.Size = new Size(225, 42);
            btnPridetiGrupe.TabIndex = 3;
            btnPridetiGrupe.Text = "Pridėti grupę";
            btnPridetiGrupe.UseVisualStyleBackColor = true;
            btnPridetiGrupe.Click += btnPridetiGrupe_Click;
            // 
            // btnPasalintiGrupe
            // 
            btnPasalintiGrupe.Location = new Point(22, 335);
            btnPasalintiGrupe.Name = "btnPasalintiGrupe";
            btnPasalintiGrupe.Size = new Size(326, 46);
            btnPasalintiGrupe.TabIndex = 4;
            btnPasalintiGrupe.Text = "Pašalinti pasirinktą grupę";
            btnPasalintiGrupe.UseVisualStyleBackColor = true;
            btnPasalintiGrupe.Click += btnPasalintiGrupe_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(679, 34);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 5;
            label2.Text = "Studentai:";
            label2.Click += label2_Click;
            // 
            // dgvStudentai
            // 
            dgvStudentai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentai.Location = new Point(431, 77);
            dgvStudentai.Name = "dgvStudentai";
            dgvStudentai.ReadOnly = true;
            dgvStudentai.RowHeadersWidth = 62;
            dgvStudentai.Size = new Size(611, 440);
            dgvStudentai.TabIndex = 6;
            // 
            // Vardas
            // 
            Vardas.AutoSize = true;
            Vardas.Location = new Point(476, 535);
            Vardas.Name = "Vardas";
            Vardas.Size = new Size(145, 25);
            Vardas.TabIndex = 7;
            Vardas.Text = "Studento vardas:";
            Vardas.Click += label3_Click;
            // 
            // txtStudentoVardas
            // 
            txtStudentoVardas.Location = new Point(619, 529);
            txtStudentoVardas.Name = "txtStudentoVardas";
            txtStudentoVardas.Size = new Size(150, 31);
            txtStudentoVardas.TabIndex = 8;
            txtStudentoVardas.TextChanged += Vardas1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 246);
            label3.Name = "label3";
            label3.Size = new Size(127, 25);
            label3.TabIndex = 9;
            label3.Text = "Įveskite grupę:";
            label3.Click += label3_Click_1;
            // 
            // Pavarde
            // 
            Pavarde.AutoSize = true;
            Pavarde.Location = new Point(464, 569);
            Pavarde.Name = "Pavarde";
            Pavarde.Size = new Size(157, 25);
            Pavarde.TabIndex = 10;
            Pavarde.Text = "Studento pavardė:";
            Pavarde.Click += label4_Click;
            // 
            // txtStudentoPavarde
            // 
            txtStudentoPavarde.Location = new Point(619, 563);
            txtStudentoPavarde.Name = "txtStudentoPavarde";
            txtStudentoPavarde.Size = new Size(150, 31);
            txtStudentoPavarde.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(545, 638);
            label4.Name = "label4";
            label4.Size = new Size(77, 25);
            label4.TabIndex = 12;
            label4.Text = "Loginas:";
            label4.Click += label4_Click_1;
            // 
            // txtStudentoLoginas
            // 
            txtStudentoLoginas.Location = new Point(619, 632);
            txtStudentoLoginas.Name = "txtStudentoLoginas";
            txtStudentoLoginas.Size = new Size(150, 31);
            txtStudentoLoginas.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(515, 672);
            label5.Name = "label5";
            label5.Size = new Size(107, 25);
            label5.TabIndex = 14;
            label5.Text = "Slaptažodis:";
            label5.Click += label5_Click;
            // 
            // txtStudentoSlaptazodis
            // 
            txtStudentoSlaptazodis.Location = new Point(619, 666);
            txtStudentoSlaptazodis.Name = "txtStudentoSlaptazodis";
            txtStudentoSlaptazodis.Size = new Size(150, 31);
            txtStudentoSlaptazodis.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(557, 605);
            label6.Name = "label6";
            label6.Size = new Size(64, 25);
            label6.TabIndex = 16;
            label6.Text = "Grupė:";
            // 
            // cmbStudentoGrupe
            // 
            cmbStudentoGrupe.FormattingEnabled = true;
            cmbStudentoGrupe.Location = new Point(619, 597);
            cmbStudentoGrupe.Name = "cmbStudentoGrupe";
            cmbStudentoGrupe.Size = new Size(150, 33);
            cmbStudentoGrupe.TabIndex = 17;
            // 
            // btnPridetiStudenta
            // 
            btnPridetiStudenta.Location = new Point(543, 713);
            btnPridetiStudenta.Name = "btnPridetiStudenta";
            btnPridetiStudenta.Size = new Size(204, 45);
            btnPridetiStudenta.TabIndex = 18;
            btnPridetiStudenta.Text = "Pridėti studentą";
            btnPridetiStudenta.UseVisualStyleBackColor = true;
            btnPridetiStudenta.Click += btnPridetiStudenta_Click;
            // 
            // btnPasalintiStudenta
            // 
            btnPasalintiStudenta.Location = new Point(796, 528);
            btnPasalintiStudenta.Name = "btnPasalintiStudenta";
            btnPasalintiStudenta.Size = new Size(246, 45);
            btnPasalintiStudenta.TabIndex = 19;
            btnPasalintiStudenta.Text = "Pašalinti pasirinktą studentą";
            btnPasalintiStudenta.UseVisualStyleBackColor = true;
            btnPasalintiStudenta.Click += btnPasalintiStudenta_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1326, 34);
            label7.Name = "label7";
            label7.Size = new Size(95, 25);
            label7.TabIndex = 20;
            label7.Text = "Dėstytojai:";
            // 
            // dgvDestytojai
            // 
            dgvDestytojai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDestytojai.Location = new Point(1063, 77);
            dgvDestytojai.Name = "dgvDestytojai";
            dgvDestytojai.RowHeadersWidth = 62;
            dgvDestytojai.Size = new Size(617, 440);
            dgvDestytojai.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1100, 538);
            label8.Name = "label8";
            label8.Size = new Size(150, 25);
            label8.TabIndex = 22;
            label8.Text = "Dėstytojo vardas:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1088, 572);
            label9.Name = "label9";
            label9.Size = new Size(162, 25);
            label9.TabIndex = 23;
            label9.Text = "Dėstytojo pavardė:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1173, 606);
            label10.Name = "label10";
            label10.Size = new Size(77, 25);
            label10.TabIndex = 24;
            label10.Text = "Loginas:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1143, 643);
            label11.Name = "label11";
            label11.Size = new Size(107, 25);
            label11.TabIndex = 25;
            label11.Text = "Slaptažodis:";
            // 
            // txtDestVardas
            // 
            txtDestVardas.Location = new Point(1248, 532);
            txtDestVardas.Name = "txtDestVardas";
            txtDestVardas.Size = new Size(150, 31);
            txtDestVardas.TabIndex = 26;
            // 
            // txtDestPavarde
            // 
            txtDestPavarde.Location = new Point(1248, 566);
            txtDestPavarde.Name = "txtDestPavarde";
            txtDestPavarde.Size = new Size(150, 31);
            txtDestPavarde.TabIndex = 27;
            // 
            // txtDestLoginas
            // 
            txtDestLoginas.Location = new Point(1248, 600);
            txtDestLoginas.Name = "txtDestLoginas";
            txtDestLoginas.Size = new Size(150, 31);
            txtDestLoginas.TabIndex = 28;
            // 
            // txtDestSlaptazodis
            // 
            txtDestSlaptazodis.Location = new Point(1248, 635);
            txtDestSlaptazodis.Name = "txtDestSlaptazodis";
            txtDestSlaptazodis.Size = new Size(150, 31);
            txtDestSlaptazodis.TabIndex = 29;
            // 
            // btnPridetiDestytoja
            // 
            btnPridetiDestytoja.Location = new Point(1133, 683);
            btnPridetiDestytoja.Name = "btnPridetiDestytoja";
            btnPridetiDestytoja.Size = new Size(204, 45);
            btnPridetiDestytoja.TabIndex = 30;
            btnPridetiDestytoja.Text = "Pridėti dėstytoją";
            btnPridetiDestytoja.UseVisualStyleBackColor = true;
            btnPridetiDestytoja.Click += btnPridetiDestytoja_Click;
            // 
            // btnPasalintiDestytoja
            // 
            btnPasalintiDestytoja.Location = new Point(1434, 530);
            btnPasalintiDestytoja.Name = "btnPasalintiDestytoja";
            btnPasalintiDestytoja.Size = new Size(246, 45);
            btnPasalintiDestytoja.TabIndex = 31;
            btnPasalintiDestytoja.Text = "Pašalinti pasirinktą dėstytoją";
            btnPasalintiDestytoja.UseVisualStyleBackColor = true;
            btnPasalintiDestytoja.Click += btnPasalintiDestytoja_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(150, 415);
            label12.Name = "label12";
            label12.Size = new Size(73, 25);
            label12.TabIndex = 32;
            label12.Text = "Dalykai:";
            // 
            // dgvDalykai
            // 
            dgvDalykai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDalykai.Location = new Point(12, 455);
            dgvDalykai.Name = "dgvDalykai";
            dgvDalykai.ReadOnly = true;
            dgvDalykai.RowHeadersWidth = 62;
            dgvDalykai.Size = new Size(347, 152);
            dgvDalykai.TabIndex = 33;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(25, 629);
            label13.Name = "label13";
            label13.Size = new Size(176, 25);
            label13.TabIndex = 34;
            label13.Text = "Dalyko pavadinimas:";
            // 
            // txtNaujasDalykas
            // 
            txtNaujasDalykas.Location = new Point(198, 623);
            txtNaujasDalykas.Name = "txtNaujasDalykas";
            txtNaujasDalykas.Size = new Size(150, 31);
            txtNaujasDalykas.TabIndex = 35;
            // 
            // btnPridetiDalyka
            // 
            btnPridetiDalyka.Location = new Point(86, 666);
            btnPridetiDalyka.Name = "btnPridetiDalyka";
            btnPridetiDalyka.Size = new Size(204, 45);
            btnPridetiDalyka.TabIndex = 36;
            btnPridetiDalyka.Text = "Pridėti dalyką";
            btnPridetiDalyka.UseVisualStyleBackColor = true;
            btnPridetiDalyka.Click += btnPridetiDalyka_Click;
            // 
            // btnPasalintiDalyka
            // 
            btnPasalintiDalyka.Location = new Point(80, 714);
            btnPasalintiDalyka.Name = "btnPasalintiDalyka";
            btnPasalintiDalyka.Size = new Size(220, 45);
            btnPasalintiDalyka.TabIndex = 37;
            btnPasalintiDalyka.Text = "Pašalinti pasirinktą dalyką";
            btnPasalintiDalyka.UseVisualStyleBackColor = true;
            btnPasalintiDalyka.Click += btnPasalintiDalyka_Click;
            // 
            // AdministratoriausForma
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1778, 1506);
            Controls.Add(btnPasalintiDalyka);
            Controls.Add(btnPridetiDalyka);
            Controls.Add(txtNaujasDalykas);
            Controls.Add(label13);
            Controls.Add(dgvDalykai);
            Controls.Add(label12);
            Controls.Add(btnPasalintiDestytoja);
            Controls.Add(btnPridetiDestytoja);
            Controls.Add(txtDestSlaptazodis);
            Controls.Add(txtDestLoginas);
            Controls.Add(txtDestPavarde);
            Controls.Add(txtDestVardas);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(dgvDestytojai);
            Controls.Add(label7);
            Controls.Add(btnPasalintiStudenta);
            Controls.Add(btnPridetiStudenta);
            Controls.Add(cmbStudentoGrupe);
            Controls.Add(label6);
            Controls.Add(txtStudentoSlaptazodis);
            Controls.Add(label5);
            Controls.Add(txtStudentoLoginas);
            Controls.Add(label4);
            Controls.Add(txtStudentoPavarde);
            Controls.Add(Pavarde);
            Controls.Add(label3);
            Controls.Add(txtStudentoVardas);
            Controls.Add(Vardas);
            Controls.Add(dgvStudentai);
            Controls.Add(label2);
            Controls.Add(btnPasalintiGrupe);
            Controls.Add(btnPridetiGrupe);
            Controls.Add(txtNaujaGrupe);
            Controls.Add(dgvGrupes);
            Controls.Add(label1);
            Name = "AdministratoriausForma";
            Text = "Administratoriaus langas";
            Load += AdministratoriausForma_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGrupes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudentai).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDestytojai).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDalykai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvGrupes;
        private TextBox txtNaujaGrupe;
        private Button btnPridetiGrupe;
        private Button btnPasalintiGrupe;
        private Label label2;
        private DataGridView dgvStudentai;
        private Label Vardas;
        private TextBox txtStudentoVardas;
        private Label label3;
        private Label Pavarde;
        private TextBox txtStudentoPavarde;
        private Label label4;
        private TextBox txtStudentoLoginas;
        private Label label5;
        private TextBox txtStudentoSlaptazodis;
        private Label label6;
        private ComboBox cmbStudentoGrupe;
        private Button btnPridetiStudenta;
        private Button btnPasalintiStudenta;
        private Label label7;
        private DataGridView dgvDestytojai;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtDestVardas;
        private TextBox txtDestPavarde;
        private TextBox txtDestLoginas;
        private TextBox txtDestSlaptazodis;
        private Button btnPridetiDestytoja;
        private Button btnPasalintiDestytoja;
        private Label label12;
        private DataGridView dgvDalykai;
        private Label label13;
        private TextBox txtNaujasDalykas;
        private Button btnPridetiDalyka;
        private Button btnPasalintiDalyka;
    }
}