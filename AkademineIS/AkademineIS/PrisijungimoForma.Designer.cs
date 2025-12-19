namespace AkademineIS
{
    partial class PrisijungimoForma
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLogin = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(348, 138);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(164, 31);
            txtLogin.TabIndex = 0;
            txtLogin.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(171, 141);
            label1.Name = "label1";
            label1.Size = new Size(171, 25);
            label1.TabIndex = 1;
            label1.Text = "Prisijungimo vardas:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 179);
            label2.Name = "label2";
            label2.Size = new Size(107, 25);
            label2.TabIndex = 2;
            label2.Text = "Slaptažodis:";
            label2.Click += label2_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(348, 179);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(164, 31);
            txtPassword.TabIndex = 3;
            txtPassword.TextChanged += textBox1_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Enabled = false;
            btnLogin.Location = new Point(304, 225);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(133, 40);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Prisijungti";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 69);
            label3.Name = "label3";
            label3.Size = new Size(121, 25);
            label3.TabIndex = 5;
            label3.Text = "Akademinė IS";
            // 
            // PrisijungimoForma
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLogin);
            Name = "PrisijungimoForma";
            Text = "Akademinė Informacinė Sistema";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // No action required when label is clicked.
            // Labels are not interactive in this form; avoid throwing exceptions.
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // No action required when label is clicked.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Update the login button enabled state when either input changes.
            btnLogin.Enabled = !string.IsNullOrWhiteSpace(txtLogin.Text)
                               && !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        #endregion

        private TextBox txtLogin;
        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label label3;
    }
}
