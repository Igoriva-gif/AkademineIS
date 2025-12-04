namespace AkademineIS
{
    partial class DestytojoForma
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
            cmbGrupe = new ComboBox();
            label2 = new Label();
            cmbDalykas = new ComboBox();
            btnUzkrauti = new Button();
            dgvPazymiai = new DataGridView();
            btnIssaugoti = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPazymiai).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(536, 71);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 0;
            label1.Text = "Grupė:";
            // 
            // cmbGrupe
            // 
            cmbGrupe.FormattingEnabled = true;
            cmbGrupe.Location = new Point(476, 109);
            cmbGrupe.Name = "cmbGrupe";
            cmbGrupe.Size = new Size(182, 33);
            cmbGrupe.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(833, 71);
            label2.Name = "label2";
            label2.Size = new Size(77, 25);
            label2.TabIndex = 2;
            label2.Text = "Dalykas:";
            // 
            // cmbDalykas
            // 
            cmbDalykas.FormattingEnabled = true;
            cmbDalykas.Location = new Point(774, 109);
            cmbDalykas.Name = "cmbDalykas";
            cmbDalykas.Size = new Size(182, 33);
            cmbDalykas.TabIndex = 3;
            // 
            // btnUzkrauti
            // 
            btnUzkrauti.Location = new Point(577, 160);
            btnUzkrauti.Name = "btnUzkrauti";
            btnUzkrauti.Size = new Size(294, 34);
            btnUzkrauti.TabIndex = 4;
            btnUzkrauti.Text = "Užkrauti studentų sąrašą";
            btnUzkrauti.UseVisualStyleBackColor = true;
            btnUzkrauti.Click += btnUzkrauti_Click;
            // 
            // dgvPazymiai
            // 
            dgvPazymiai.AllowUserToAddRows = false;
            dgvPazymiai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPazymiai.Location = new Point(550, 209);
            dgvPazymiai.Name = "dgvPazymiai";
            dgvPazymiai.RowHeadersWidth = 62;
            dgvPazymiai.Size = new Size(360, 225);
            dgvPazymiai.TabIndex = 5;
            // 
            // btnIssaugoti
            // 
            btnIssaugoti.Location = new Point(577, 450);
            btnIssaugoti.Name = "btnIssaugoti";
            btnIssaugoti.Size = new Size(294, 34);
            btnIssaugoti.TabIndex = 6;
            btnIssaugoti.Text = "Išsaugoti pažymius";
            btnIssaugoti.UseVisualStyleBackColor = true;
            btnIssaugoti.Click += btnIssaugoti_Click;
            // 
            // DestytojoForma
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1436, 697);
            Controls.Add(btnIssaugoti);
            Controls.Add(dgvPazymiai);
            Controls.Add(btnUzkrauti);
            Controls.Add(cmbDalykas);
            Controls.Add(label2);
            Controls.Add(cmbGrupe);
            Controls.Add(label1);
            Name = "DestytojoForma";
            Text = "Dėstytojo langas";
            ((System.ComponentModel.ISupportInitialize)dgvPazymiai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbGrupe;
        private Label label2;
        private ComboBox cmbDalykas;
        private Button btnUzkrauti;
        private DataGridView dgvPazymiai;
        private Button btnIssaugoti;
    }
}