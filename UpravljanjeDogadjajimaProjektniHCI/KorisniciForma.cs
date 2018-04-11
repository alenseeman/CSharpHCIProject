using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{
    public partial class KorisniciForma : Form
    {
        public KorisniciForma()
        {
            InitializeComponent();
        }

        private void KorisniciForma_Load(object sender, EventArgs e)
        {
            korisnikBindingSource.DataSource = Klasa.baza.korisniks.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NoviKorisnikForma nkf = new NoviKorisnikForma();
            nkf.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            korisnikBindingSource.DataSource = Klasa.baza.korisniks.Where(c => c.ime.Contains(((TextBox)sender).Text)).ToList();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void KorisniciForma_Activated(object sender, EventArgs e)
        {
            korisnikBindingSource.DataSource = Klasa.baza.korisniks.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((korisnikBindingSource.Current) != null)
            {
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni ?", "Brisanje korisnika", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    korisnik kor = (korisnik)this.korisnikBindingSource.Current;
                    Klasa.baza.korisniks.Remove(kor);
                    Klasa.baza.SaveChanges();
                    korisnikBindingSource.DataSource = Klasa.baza.korisniks.ToList();
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
            else
                MessageBox.Show("Izaberite korisnika !");
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((korisnikBindingSource.Current) != null)
            {
                NoviKorisnikForma nkf = new NoviKorisnikForma((korisnik)korisnikBindingSource.Current, "DA");
                nkf.Show();
            }
            else
            {
                MessageBox.Show("Izaberite korisnika !");
                textBox1.Text = "";
            }
        }
    }
}
