namespace AkademineIS
{
    partial class StudentoForma
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
            dgvPazymiai = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPazymiai).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(681, 97);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 0;
            label1.Text = "Pažymiai";
            // 
            // dgvPazymiai
            // 
            dgvPazymiai.AllowUserToAddRows = false;
            dgvPazymiai.AllowUserToDeleteRows = false;
            dgvPazymiai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPazymiai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPazymiai.Location = new Point(465, 125);
            dgvPazymiai.Name = "dgvPazymiai";
            dgvPazymiai.ReadOnly = true;
            dgvPazymiai.RowHeadersWidth = 62;
            dgvPazymiai.Size = new Size(521, 353);
            dgvPazymiai.TabIndex = 1;
            // 
            // StudentoForma
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1425, 701);
            Controls.Add(dgvPazymiai);
            Controls.Add(label1);
            Name = "StudentoForma";
            Text = "Studento langas";
            ((System.ComponentModel.ISupportInitialize)dgvPazymiai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvPazymiai;
    }
}