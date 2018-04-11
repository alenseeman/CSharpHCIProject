using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{
    public partial class Isprobavanje : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        private korisnik kor;
        private List<dogadjaj> topTri = new List<dogadjaj>();
        public Isprobavanje()
        {
            InitializeComponent();
        }
        public void osvjeziFormu()
        {
            linkLabel1.Visible = true;
            linkLabel2.Visible = true;
            linkLabel3.Visible = true;
            dogadjajBindingSource.DataSource = null;
            List<dogadjaj> lista = Klasa.baza.dogadjajs.Where(c => c.obrisan == false).ToList();
            List<dogadjaj> ll = lista.OrderBy(ee => ee.datumPocetka).ThenBy(ee => ee.vrijemePocetka).ToList();
            if (radioButton1.Checked)
            {
                dogadjajBindingSource.DataSource = ll;
            }
            DateTime danas = DateTime.Today;
            topTri = new List<dogadjaj>();
            for (int i = 0; i < ll.Count; i++)
            {
                if (danas.CompareTo(ll[i].datumPocetka) == 0)
                {
                    int time = DateTime.Now.Hour;
                    if (time < ll[i].vrijemePocetka.Hours)
                    {

                        topTri.Add(ll[i]);
                    }
                    else if (time == ll[i].vrijemePocetka.Hours)
                    {
                        int minuti = DateTime.Now.Minute;
                        if (minuti <= ll[i].vrijemePocetka.Minutes)
                        {
                            topTri.Add(ll[i]);
                        }
                    }
                }
                else if (danas.CompareTo(ll[i].datumPocetka) < 0)
                {
                    topTri.Add(ll[i]);
                }
            }
            topTri = topTri.OrderBy(rr => rr.datumPocetka).ThenBy(rr => rr.vrijemePocetka).ToList();
            if (radioButton2.Checked)
            {
                dogadjajBindingSource.DataSource = topTri;
            }
            switch (topTri.Count)
            {
                case 0:

                    {
                        linkLabel1.Visible = false;
                        linkLabel2.Visible = false;
                        linkLabel3.Visible = false;
                        break;
                    }
                case 1:
                    {
                        linkLabel1.Text = "-" + topTri[0].naziv;
                        linkLabel2.Visible = false;
                        linkLabel3.Visible = false;
                        break;
                    }
                case 2:
                    {
                        linkLabel1.Text = "- " + topTri[0].naziv;
                        linkLabel2.Text = "- " + topTri[1].naziv;
                        linkLabel3.Visible = false;
                        break;
                    }
                default:
                    {
                        linkLabel1.Text = "- " + topTri[0].naziv;
                        linkLabel2.Text = "- " + topTri[1].naziv;
                        linkLabel3.Text = "- " + topTri[2].naziv;
                        break;
                    }
            }
        }

        private void Isprobavanje_Load(object sender, EventArgs e)
        {
            osvjeziFormu();
            radioButton1.Checked = true;
            this.KeyPreview = true;
            kor = LoginForma.korisnik;
            if (kor.admin == false)
            {
                button4.Visible = false;
                button2.Visible = false;
                button1.Visible = false;
            }
            bunifuTileButton1.LabelText ="";
            t_Tick(sender, e);
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }
        private void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            string time = "";
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";
            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";
            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            label1.Text = time;
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                List<dogadjaj> lista = Klasa.baza.dogadjajs.Where(c => c.obrisan == false).ToList();
                dogadjajBindingSource.DataSource = lista.Where(c => c.naziv.Contains(((TextBox)sender).Text)).ToList();
            }
            else
                dogadjajBindingSource.DataSource = topTri.Where(c => c.naziv.Contains(((TextBox)sender).Text)).ToList();

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlavnaForma gf = new GlavnaForma();
            gf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dogadjajBunifuCustomDataGrid.SelectedRows.Count > 0)
            {
                dogadjaj dog = (dogadjaj)dogadjajBindingSource.Current;
                KreiranDogadjajForma kdf = new KreiranDogadjajForma(dog, "POSTOJECI");
                kdf.Show();
            }
            else
                MessageBox.Show("Niste selektovali nijedan događaj !");
            textBox1.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((dogadjajBindingSource.Current) != null)
            {
                dogadjaj dog = (dogadjaj)dogadjajBindingSource.Current;
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni ?", "Brisanje korisnika", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dog.obrisan = true;
                    Klasa.baza.SaveChanges();
                    osvjeziFormu();
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali nijedan dogadjaj !");
                textBox1.Text = "";
            }

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(bunifuTileButton1, new Point(0, bunifuTileButton1.Height));
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Program.Main();
            this.Hide();
            DialogResult loginRezultat;
            using (var loginForma = new LoginForma())
              
            loginRezultat = loginForma.ShowDialog();
           
            if (loginRezultat == DialogResult.OK)
            {
                // login was successful
               Isprobavanje iss=new Isprobavanje();
                iss.Show();
            }
           



        }

        private void Isprobavanje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                GlavnaForma gf = new GlavnaForma();
                gf.Show();
               
            }
            if (e.KeyData == (Keys.Control | Keys.F))
            {
                textBox1.Select();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            KorisniciForma form = new KorisniciForma();
            form.Show();

        }
        private void promjeniLozinkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoviKorisnikForma nkf = new NoviKorisnikForma(kor, "IZMJENA");
            nkf.Show();
        }

        private void dogadjajBunifuCustomDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dogadjajBindingSource.Current != null)
            {
                dogadjaj doggg = (dogadjaj)dogadjajBindingSource.Current;
                monthCalendar1.BoldedDates = new DateTime[]
               {
            doggg.datumPocetka,
           doggg.datumKraja
               };
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KreiranDogadjajForma pdf = new KreiranDogadjajForma(topTri[0], "POSTOJECI");
            pdf.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KreiranDogadjajForma pdf = new KreiranDogadjajForma(topTri[1], "POSTOJECI");
            pdf.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KreiranDogadjajForma pdf = new KreiranDogadjajForma(topTri[2], "POSTOJECI");
            pdf.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            osvjeziFormu();
            textBox1.Text = "";
            List<dogadjaj> lista = Klasa.baza.dogadjajs.Where(c => c.obrisan == false).ToList();
            List<dogadjaj> ll = lista.OrderBy(ee => ee.datumPocetka).ThenBy(ee => ee.vrijemePocetka).ToList();
            dogadjajBindingSource.DataSource = ll;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            osvjeziFormu();
            textBox1.Text = "";
            dogadjajBindingSource.DataSource = topTri;
        }

        private void Isprobavanje_Activated(object sender, EventArgs e)
        {
            //bunifuTileButton1.LabelText = kor.korisnickoIme;
            osvjeziFormu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((dogadjaj)dogadjajBindingSource.Current!= null)
                {
                GlavnaForma gf = new GlavnaForma((dogadjaj)dogadjajBindingSource.Current, "IZMJENA");
                gf.Show();
            }
            else
            {
                MessageBox.Show("Izaberite događaj koji želite da izmjenite.");
                textBox1.Text = "";
            }
        }
    }
}
