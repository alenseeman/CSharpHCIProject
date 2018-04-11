using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{
    public partial class NoviKorisnikForma : Form
    {
        private korisnik korr;
        private string nacinPregleda;
        public NoviKorisnikForma()
        {
            InitializeComponent();
        }
        public NoviKorisnikForma(korisnik korisnikk, string i)
        {
            InitializeComponent();
            korr = korisnikk;
            nacinPregleda = i;
        }

        private void NoviKorisnikForma_Load(object sender, EventArgs e)
        {
            if (korr != null)
            {
                if ("IZMJENA".Equals(nacinPregleda))
                {
                    adminCheckBox.Visible = false;
                    label2.Visible = false;
                }
                korisnik kopiranKorisnik = korisnik.DeepClone(korr);
                korisnikBindingSource.DataSource = kopiranKorisnik;
                sifraTextBox.Visible = false;
                button1.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (korr == null)
            {
                if (imeTextBox.Text != "" && prezimeTextBox.Text != "" && korisnickoImeTextBox.Text != "" && sifraTextBox.Text != "")
                {
                    byte[] salt1 = new byte[8];
                    using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
                    {
                        rngCsp.GetBytes(salt1);
                    }

                    korisnik kor = new korisnik();
                    kor.ime = imeTextBox.Text;
                    kor.prezime = prezimeTextBox.Text;
                    kor.korisnickoIme = korisnickoImeTextBox.Text;
                    kor.salt = salt1;
                    kor.admin = adminCheckBox.Checked;
                    String pwd1 = sifraTextBox.Text;
                    kor.sifra = Convert.ToBase64String((new Rfc2898DeriveBytes(pwd1, salt1)).GetBytes(20));
                    Klasa.baza.korisniks.Add(kor);
                    Klasa.baza.SaveChanges();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Nisu uneseni svi potrebni podaci.");
                }
            }
            else
            {
                if (imeTextBox.Text != "" && prezimeTextBox.Text != "" && korisnickoImeTextBox.Text != "")
                {
                    korr.ime = imeTextBox.Text;
                    korr.prezime = prezimeTextBox.Text;
                    korr.korisnickoIme = korisnickoImeTextBox.Text;
                    korr.admin = adminCheckBox.Checked;
                    Klasa.baza.SaveChanges();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Nisu uneseni svi potrebni podaci.");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Size.Width != 600)
            {
                for (int i = 400; i < 601; i++)
                {
                    this.Size = new Size(i, 350);
                    Thread.Sleep(2);
                }
                lozinkaLabel.Visible = true;
                lozinkaTextbox.Visible = true;
                promijeniLozinkuButton.Visible = true;
                promjenaSifreLabel.Visible = true;
                potvrdiLozinkaLabel.Visible = true;
                potvrdiLozinkaTextbox.Visible = true;
                button2.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void promijeniLozinkuButton_Click(object sender, EventArgs e)
        {
            if (lozinkaTextbox.Text != "" && potvrdiLozinkaTextbox.Text != "")
            {
                if (lozinkaTextbox.Text.Equals(potvrdiLozinkaTextbox.Text))
                {
                    korr.sifra = Convert.ToBase64String((new Rfc2898DeriveBytes(lozinkaTextbox.Text, korr.salt)).GetBytes(20));
                    for (int i = 600; i > 399; i--)
                    {
                        this.Size = new Size(i, 350);
                        Thread.Sleep(2);
                    }
                    lozinkaLabel.Visible = false;
                    lozinkaTextbox.Visible = false;
                    promijeniLozinkuButton.Visible = false;
                    promjenaSifreLabel.Visible = false;
                    potvrdiLozinkaLabel.Visible = false;
                    potvrdiLozinkaTextbox.Visible = false;
                    button2.Visible = false;

                }
                else
                {
                    MessageBox.Show("Lozinke nisu iste !");
                }
            }
            else
            {
                MessageBox.Show("Popunite sva polja!");
            }
        }

        private void lozinkaTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lozinkaTextbox_Click(object sender, EventArgs e)
        {
            lozinkaTextbox.Text = "";
        }

        private void potvrdiLozinkaTextbox_Click(object sender, EventArgs e)
        {
            potvrdiLozinkaTextbox.Text = "";
        }

        private void imeTextBox_Click(object sender, EventArgs e)
        {
            imeTextBox.SelectAll();
        }

        private void prezimeTextBox_Click(object sender, EventArgs e)
        {
            prezimeTextBox.SelectAll();
        }

        private void korisnickoImeTextBox_Click(object sender, EventArgs e)
        {
            korisnickoImeTextBox.SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 600; i > 399; i--)
            {
                this.Size = new Size(i, 350);
                Thread.Sleep(2);
            }
            lozinkaLabel.Visible = false;
            lozinkaTextbox.Visible = false;
            promijeniLozinkuButton.Visible = false;
            promjenaSifreLabel.Visible = false;
            potvrdiLozinkaLabel.Visible = false;
            potvrdiLozinkaTextbox.Visible = false;
            button2.Visible = false;
        }
    }
}
