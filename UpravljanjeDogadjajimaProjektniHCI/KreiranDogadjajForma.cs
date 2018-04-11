using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{
    public partial class KreiranDogadjajForma : Form
    {
        private string nacinPregleda;
        private dogadjaj dog;
        private List<string> imenaFajlova = new List<string>();
        public KreiranDogadjajForma()
        {
            InitializeComponent();
        }

        public KreiranDogadjajForma(dogadjaj dog, string vr)
        {
            nacinPregleda = vr;
            InitializeComponent();
            this.dog = dog;
            listBox1.DataSource = imenaFajlova;
        }

        public void osvjeziTabelu()
        {
            List<poddogadjaj> lista = Klasa.baza.poddogadjajs.Where(c => c.obrisan == false).ToList();
            poddogadjajBindingSource.DataSource = lista.Where(c => c.dogadjaj_iddogadjaj.Equals(dog.iddogadjaj)).ToList();
        }
        private void KreiranDogadjajForma_Load(object sender, EventArgs e)
        {
            osvjeziTabelu();
            dogadjajBunifuCustomDataGrid.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dogadjajBunifuCustomDataGrid.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            label1.Text = dog.naziv;
            label2.Text = dog.vrsta;

            if (!"NOVI".Equals(nacinPregleda))
            {
               
                    List<fajl> fajlovi = Klasa.baza.fajls.Where(c => c.dogadjaj_iddogadjaj.Equals(dog.iddogadjaj)).ToList();
                    List<string> imena = new List<string>();
                    for (int i = 0; i < fajlovi.Count; i++)
                    {
                        imena.Add(fajlovi[i].naziv);
                    }
                    listBox1.DataSource = imena;
                if ("POSTOJECI".Equals(nacinPregleda))
                {
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    button7.Visible = true;
                }
                if (listBox1.Items.Count == 0)
                {
                    button5.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlavnaForma gf = new GlavnaForma();
            gf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (poddogadjajBindingSource.Current != null)
            {
                KreiranPoddogadjajForma kpf = new KreiranPoddogadjajForma((poddogadjaj)poddogadjajBindingSource.Current, "POSTOJECI");
                kpf.Show();
            }
            else
            {
                MessageBox.Show("Niste izabrali nijedan poddogađaj.");
            }
        }

        private void dogadjajBunifuCustomDataGrid_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {

        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.label1, "Naziv događaja !");
        }


        private void label2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.label2, "Vrsta događaja !");
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            KreirajPoddogadjajForma kppf = new KreirajPoddogadjajForma(dog);
            kppf.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<poddogadjaj> lista = Klasa.baza.poddogadjajs.Where(c => c.obrisan == false).ToList();
            List<poddogadjaj> podpod = lista.Where(c => c.dogadjaj_iddogadjaj.Equals(dog.iddogadjaj)).ToList();
            poddogadjajBindingSource.DataSource = podpod.Where(c => c.naziv.Contains(((TextBox)sender).Text)).ToList();

        }

        private void KreiranDogadjajForma_Activated(object sender, EventArgs e)
        {
            osvjeziTabelu();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dogadjajBunifuCustomDataGrid.SelectedRows.Count > 0)
            {
                poddogadjaj podd = (poddogadjaj)poddogadjajBindingSource.Current;
                KreirajPoddogadjajForma kpf = new KreirajPoddogadjajForma(podd);
                kpf.Show();
            }
            else
            {
                MessageBox.Show("Niste selektovali nijedan poddogađaj.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                string[] tmp = path.Split('\\');
                string sminka = tmp[tmp.Length - 1];
                fajl fajl = new fajl();
                fajl.podaci = File.ReadAllBytes(path);
                fajl.naziv = sminka;
                imenaFajlova.Add(fajl.naziv);
                listBox1.DataSource = null;
                listBox1.DataSource = imenaFajlova;
                fajl.dogadjaj_iddogadjaj = dog.iddogadjaj;
                Klasa.baza.fajls.Add(fajl);
                Klasa.baza.SaveChanges();
                button5.Enabled = true;


            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int selectedIndex = listBox1.SelectedIndex;
                string ime = (string)listBox1.SelectedItem;
                fajl fajll = Klasa.baza.fajls.First(c => c.naziv.Equals(ime));
                Klasa.baza.fajls.Remove(fajll);
                Klasa.baza.SaveChanges();

                try
                {
                    imenaFajlova.RemoveAt(selectedIndex);
                }
                catch
                {
                }

                listBox1.DataSource = null;
                listBox1.DataSource = imenaFajlova;
            }
            else
            {
                MessageBox.Show("Izaberite fajl koji želite obrisati.");
            }
            if (listBox1.Items.Count == 0)
            {
                button5.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                fajl f = Klasa.baza.fajls.First(c => c.naziv.Equals((string)listBox1.SelectedItem));
                Byte[] data = new Byte[0];
                data = (Byte[])f.podaci;
                string myTempFile = Path.Combine(Path.GetTempPath(), f.naziv);
                File.WriteAllBytes(myTempFile, data);
                System.Diagnostics.Process.Start(myTempFile);
            }
            else
            {
                MessageBox.Show("Prvo izaberite fajl koji zelite da prikažete.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dogadjajBunifuCustomDataGrid.SelectedRows.Count > 0)
            {
                poddogadjaj poddog = (poddogadjaj)poddogadjajBindingSource.Current;
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni ?", "Brisanje podogađaja", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    poddog.obrisan = true;
                    Klasa.baza.SaveChanges();
                    osvjeziTabelu();
                }
            }
            else
            {
                MessageBox.Show("Izaberite poddogađaj koji želite obrisati.");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.bunifuImageButton1, "Početak događaja: " + dog.datumPocetka.Date.ToShortDateString() + " " + dog.vrijemePocetka + "\n" + "Kraj događaja: " + dog.datumKraja.Date.ToShortDateString() + " " + dog.vrijemeKraja);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureBox1, "Lokacija događaja: " + dog.lokacija);
        }

        private void KreiranDogadjajForma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                button1_Click_1(sender, e);
            }
            if (e.KeyData == (Keys.Control | Keys.F))
            {
                textBox1.Select();
            }
        }
    }
}
