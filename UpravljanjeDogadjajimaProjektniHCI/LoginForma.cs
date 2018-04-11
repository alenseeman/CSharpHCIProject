using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{

    public partial class LoginForma : Form
    {
        public static korisnik korisnik;

        public LoginForma()
        {
            InitializeComponent();
        }
        public object KeyDerivationPrf { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Select();
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.UseSystemPasswordChar = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string sif = textBox2.Text;
            if (sif != "" && user != "")
            {
                try
                {
                    korisnik emp = Klasa.baza.korisniks.First(i => i.korisnickoIme.Equals(user));
                    if (emp != null)
                    {
                        string sifra = Convert.ToBase64String((new Rfc2898DeriveBytes(sif, emp.salt)).GetBytes(20));

                        if (emp.sifra.Equals(sifra))
                        {
                            DialogResult = DialogResult.OK;
                            korisnik = emp;

                        }
                        else
                        {
                            MessageBox.Show("Pogrešno unijeti podaci !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pogrešno unijeti podaci !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne postoji korisnik sa takvim imenom.");
                }
            }
            else
            {
                MessageBox.Show("Pogrešno unijeti podaci !");
            }
        }


        private void textBox2_TabIndexChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox2.Text = "";
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                label2_Click(sender, e);
            }
        }
    }

}
