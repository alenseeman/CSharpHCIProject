namespace UpravljanjeDogadjajimaProjektniHCI
{
    partial class NoviKorisnikForma
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label imeLabel;
            System.Windows.Forms.Label korisnickoImeLabel;
            System.Windows.Forms.Label prezimeLabel;
            System.Windows.Forms.Label sifraLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoviKorisnikForma));
            this.adminCheckBox = new System.Windows.Forms.CheckBox();
            this.korisnikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imeTextBox = new System.Windows.Forms.TextBox();
            this.korisnickoImeTextBox = new System.Windows.Forms.TextBox();
            this.prezimeTextBox = new System.Windows.Forms.TextBox();
            this.sifraTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.promjenaSifreLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lozinkaLabel = new System.Windows.Forms.Label();
            this.potvrdiLozinkaLabel = new System.Windows.Forms.Label();
            this.promijeniLozinkuButton = new System.Windows.Forms.Button();
            this.lozinkaTextbox = new System.Windows.Forms.TextBox();
            this.potvrdiLozinkaTextbox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            imeLabel = new System.Windows.Forms.Label();
            korisnickoImeLabel = new System.Windows.Forms.Label();
            prezimeLabel = new System.Windows.Forms.Label();
            sifraLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.korisnikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imeLabel
            // 
            imeLabel.AutoSize = true;
            imeLabel.ForeColor = System.Drawing.Color.Gainsboro;
            imeLabel.Location = new System.Drawing.Point(83, 75);
            imeLabel.Name = "imeLabel";
            imeLabel.Size = new System.Drawing.Size(27, 13);
            imeLabel.TabIndex = 5;
            imeLabel.Text = "Ime:";
            // 
            // korisnickoImeLabel
            // 
            korisnickoImeLabel.AutoSize = true;
            korisnickoImeLabel.ForeColor = System.Drawing.Color.Gainsboro;
            korisnickoImeLabel.Location = new System.Drawing.Point(83, 135);
            korisnickoImeLabel.Name = "korisnickoImeLabel";
            korisnickoImeLabel.Size = new System.Drawing.Size(78, 13);
            korisnickoImeLabel.TabIndex = 7;
            korisnickoImeLabel.Text = "Korisničko ime:";
            // 
            // prezimeLabel
            // 
            prezimeLabel.AutoSize = true;
            prezimeLabel.ForeColor = System.Drawing.Color.Gainsboro;
            prezimeLabel.Location = new System.Drawing.Point(83, 105);
            prezimeLabel.Name = "prezimeLabel";
            prezimeLabel.Size = new System.Drawing.Size(47, 13);
            prezimeLabel.TabIndex = 9;
            prezimeLabel.Text = "Prezime:";
            // 
            // sifraLabel
            // 
            sifraLabel.AutoSize = true;
            sifraLabel.ForeColor = System.Drawing.Color.Gainsboro;
            sifraLabel.Location = new System.Drawing.Point(83, 165);
            sifraLabel.Name = "sifraLabel";
            sifraLabel.Size = new System.Drawing.Size(47, 13);
            sifraLabel.TabIndex = 11;
            sifraLabel.Text = "Lozinka:";
            // 
            // adminCheckBox
            // 
            this.adminCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.korisnikBindingSource, "admin", true));
            this.adminCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.adminCheckBox.Location = new System.Drawing.Point(167, 192);
            this.adminCheckBox.Name = "adminCheckBox";
            this.adminCheckBox.Size = new System.Drawing.Size(104, 24);
            this.adminCheckBox.TabIndex = 5;
            this.adminCheckBox.Text = "Admin ?";
            this.adminCheckBox.UseVisualStyleBackColor = true;
            // 
            // korisnikBindingSource
            // 
            this.korisnikBindingSource.DataSource = typeof(UpravljanjeDogadjajimaProjektniHCI.korisnik);
            // 
            // imeTextBox
            // 
            this.imeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.korisnikBindingSource, "ime", true));
            this.imeTextBox.Location = new System.Drawing.Point(167, 72);
            this.imeTextBox.Name = "imeTextBox";
            this.imeTextBox.Size = new System.Drawing.Size(144, 20);
            this.imeTextBox.TabIndex = 1;
            this.imeTextBox.Click += new System.EventHandler(this.imeTextBox_Click);
            // 
            // korisnickoImeTextBox
            // 
            this.korisnickoImeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.korisnikBindingSource, "korisnickoIme", true));
            this.korisnickoImeTextBox.Location = new System.Drawing.Point(167, 132);
            this.korisnickoImeTextBox.Name = "korisnickoImeTextBox";
            this.korisnickoImeTextBox.Size = new System.Drawing.Size(144, 20);
            this.korisnickoImeTextBox.TabIndex = 3;
            this.korisnickoImeTextBox.Click += new System.EventHandler(this.korisnickoImeTextBox_Click);
            // 
            // prezimeTextBox
            // 
            this.prezimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.korisnikBindingSource, "prezime", true));
            this.prezimeTextBox.Location = new System.Drawing.Point(167, 102);
            this.prezimeTextBox.Name = "prezimeTextBox";
            this.prezimeTextBox.Size = new System.Drawing.Size(144, 20);
            this.prezimeTextBox.TabIndex = 2;
            this.prezimeTextBox.Click += new System.EventHandler(this.prezimeTextBox_Click);
            // 
            // sifraTextBox
            // 
            this.sifraTextBox.Location = new System.Drawing.Point(167, 162);
            this.sifraTextBox.Name = "sifraTextBox";
            this.sifraTextBox.Size = new System.Drawing.Size(144, 20);
            this.sifraTextBox.TabIndex = 4;
            this.sifraTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(179)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Korisnik :";
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(179)))), ((int)(((byte)(139)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(227, 269);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 30);
            this.button4.TabIndex = 6;
            this.button4.Text = "Sačuvaj";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(179)))), ((int)(((byte)(139)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(167, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "Promijena lozinke";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // promjenaSifreLabel
            // 
            this.promjenaSifreLabel.AutoSize = true;
            this.promjenaSifreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promjenaSifreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(179)))), ((int)(((byte)(139)))));
            this.promjenaSifreLabel.Location = new System.Drawing.Point(410, 25);
            this.promjenaSifreLabel.Name = "promjenaSifreLabel";
            this.promjenaSifreLabel.Size = new System.Drawing.Size(112, 18);
            this.promjenaSifreLabel.TabIndex = 15;
            this.promjenaSifreLabel.Text = "Promjena šifre :";
            this.promjenaSifreLabel.Visible = false;
            this.promjenaSifreLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UpravljanjeDogadjajimaProjektniHCI.Properties.Resources._12456877162087486429Soeb_Plain_Arrow_7_svg_thumb;
            this.pictureBox1.Location = new System.Drawing.Point(317, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // lozinkaLabel
            // 
            this.lozinkaLabel.AutoSize = true;
            this.lozinkaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lozinkaLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.lozinkaLabel.Location = new System.Drawing.Point(455, 77);
            this.lozinkaLabel.Name = "lozinkaLabel";
            this.lozinkaLabel.Size = new System.Drawing.Size(80, 15);
            this.lozinkaLabel.TabIndex = 17;
            this.lozinkaLabel.Text = "Nova lozinka:";
            this.lozinkaLabel.Visible = false;
            // 
            // potvrdiLozinkaLabel
            // 
            this.potvrdiLozinkaLabel.AutoSize = true;
            this.potvrdiLozinkaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.potvrdiLozinkaLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.potvrdiLozinkaLabel.Location = new System.Drawing.Point(438, 137);
            this.potvrdiLozinkaLabel.Name = "potvrdiLozinkaLabel";
            this.potvrdiLozinkaLabel.Size = new System.Drawing.Size(118, 15);
            this.potvrdiLozinkaLabel.TabIndex = 19;
            this.potvrdiLozinkaLabel.Text = "Potvrdi novu lozinku:";
            this.potvrdiLozinkaLabel.Visible = false;
            // 
            // promijeniLozinkuButton
            // 
            this.promijeniLozinkuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(179)))), ((int)(((byte)(139)))));
            this.promijeniLozinkuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.promijeniLozinkuButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.promijeniLozinkuButton.Location = new System.Drawing.Point(423, 208);
            this.promijeniLozinkuButton.Name = "promijeniLozinkuButton";
            this.promijeniLozinkuButton.Size = new System.Drawing.Size(144, 25);
            this.promijeniLozinkuButton.TabIndex = 20;
            this.promijeniLozinkuButton.Text = "Promijeni lozinku";
            this.promijeniLozinkuButton.UseVisualStyleBackColor = false;
            this.promijeniLozinkuButton.Visible = false;
            this.promijeniLozinkuButton.Click += new System.EventHandler(this.promijeniLozinkuButton_Click);
            // 
            // lozinkaTextbox
            // 
            this.lozinkaTextbox.Location = new System.Drawing.Point(416, 105);
            this.lozinkaTextbox.Name = "lozinkaTextbox";
            this.lozinkaTextbox.Size = new System.Drawing.Size(155, 20);
            this.lozinkaTextbox.TabIndex = 21;
            this.lozinkaTextbox.UseSystemPasswordChar = true;
            this.lozinkaTextbox.Visible = false;
            this.lozinkaTextbox.Click += new System.EventHandler(this.lozinkaTextbox_Click);
            this.lozinkaTextbox.TextChanged += new System.EventHandler(this.lozinkaTextbox_TextChanged);
            // 
            // potvrdiLozinkaTextbox
            // 
            this.potvrdiLozinkaTextbox.Location = new System.Drawing.Point(416, 167);
            this.potvrdiLozinkaTextbox.Name = "potvrdiLozinkaTextbox";
            this.potvrdiLozinkaTextbox.Size = new System.Drawing.Size(155, 20);
            this.potvrdiLozinkaTextbox.TabIndex = 22;
            this.potvrdiLozinkaTextbox.UseSystemPasswordChar = true;
            this.potvrdiLozinkaTextbox.Visible = false;
            this.potvrdiLozinkaTextbox.Click += new System.EventHandler(this.potvrdiLozinkaTextbox_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(179)))), ((int)(((byte)(139)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(423, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 25);
            this.button2.TabIndex = 23;
            this.button2.Text = "Poništi";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(83, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Admin:";
            // 
            // NoviKorisnikForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.potvrdiLozinkaTextbox);
            this.Controls.Add(this.lozinkaTextbox);
            this.Controls.Add(this.promijeniLozinkuButton);
            this.Controls.Add(this.potvrdiLozinkaLabel);
            this.Controls.Add(this.lozinkaLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.promjenaSifreLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.adminCheckBox);
            this.Controls.Add(imeLabel);
            this.Controls.Add(this.imeTextBox);
            this.Controls.Add(korisnickoImeLabel);
            this.Controls.Add(this.korisnickoImeTextBox);
            this.Controls.Add(prezimeLabel);
            this.Controls.Add(this.prezimeTextBox);
            this.Controls.Add(sifraLabel);
            this.Controls.Add(this.sifraTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NoviKorisnikForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mint-Rem";
            this.Load += new System.EventHandler(this.NoviKorisnikForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.korisnikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox adminCheckBox;
        private System.Windows.Forms.TextBox imeTextBox;
        private System.Windows.Forms.TextBox korisnickoImeTextBox;
        private System.Windows.Forms.TextBox prezimeTextBox;
        private System.Windows.Forms.TextBox sifraTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label promjenaSifreLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lozinkaLabel;
        private System.Windows.Forms.Label potvrdiLozinkaLabel;
        private System.Windows.Forms.Button promijeniLozinkuButton;
        private System.Windows.Forms.TextBox lozinkaTextbox;
        private System.Windows.Forms.TextBox potvrdiLozinkaTextbox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource korisnikBindingSource;
        private System.Windows.Forms.Label label2;
    }
}