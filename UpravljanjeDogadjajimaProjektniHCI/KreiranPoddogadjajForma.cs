using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{
    public partial class KreiranPoddogadjajForma : Form
    {
        private poddogadjaj podd;
        private string nacinPredstavljanja;

        public KreiranPoddogadjajForma()
        {
            InitializeComponent();
        }

        public KreiranPoddogadjajForma(poddogadjaj current, string p)
        {
            InitializeComponent();
            podd = current;
            nacinPredstavljanja = p;
        }
        public void osvjeziTabelu()
        {
            List<element> lista = Klasa.baza.elements.Where(c => c.obrisan == false).ToList();
            elementBindingSource.DataSource = lista.Where(c => c.podDogadjaj_idpodDogadjaj.Equals(podd.idpodDogadjaj)).ToList();
        }

        private void KreiranPoddogadjajForma_Load(object sender, EventArgs e)
        {
            if ("POSTOJECI".Equals(nacinPredstavljanja))
            {
                groupBox1.Visible = false;
            }
            dogadjajBunifuCustomDataGrid.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dogadjajBunifuCustomDataGrid.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            osvjeziTabelu();
            label1.Text = podd.naziv;
            label2.Text = podd.vrsta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajNoviElementForma dnef = new DodajNoviElementForma(podd);
            dnef.Show();
        }

        private void KreiranPoddogadjajForma_Activated(object sender, EventArgs e)
        {
            osvjeziTabelu();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            List<element> lista = Klasa.baza.elements.Where(c => c.obrisan == false).ToList();
            List<element> elementi = lista.Where(c => c.podDogadjaj_idpodDogadjaj.Equals(podd.idpodDogadjaj)).ToList();
            elementBindingSource.DataSource = elementi.Where(c => c.naziv.Contains(((TextBox)sender).Text)).ToList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureBox1, "Lokacija događaja: " + podd.lokacija);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.bunifuImageButton1, "Početak događaja: " + podd.datumPocetka.Date.ToShortDateString() + " " + podd.vrijemePocetka + "\n" + "Kraj događaja: " + podd.datumKraja.Date.ToShortDateString() + " " + podd.vrijemKraja);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dogadjajBunifuCustomDataGrid.SelectedRows.Count > 0)
            {
                element elem = (element)elementBindingSource.Current;
                elem.obrisan = true;
                Klasa.baza.SaveChanges();
                osvjeziTabelu();
            }
            else
            {
                MessageBox.Show("Niste selektovali nijedan element.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dogadjajBunifuCustomDataGrid.SelectedRows.Count > 0)
            {
                element elem = (element)elementBindingSource.Current;
                DodajNoviElementForma dnef = new DodajNoviElementForma(elem);
                dnef.Show();
            }
            else
            {
                MessageBox.Show("Niste selektovali nijedan element.");
            }
        }

        private void label1_MouseHover_1(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.label1, "Naziv poddogađaja !");
        }

        private void label2_MouseHover_1(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.label2, "Vrsta poddogađaja !");
        }

        private void KreiranPoddogadjajForma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                button1_Click(sender, e);

            }
            if (e.KeyData == (Keys.Control | Keys.F))
            {
                textBox1.Select();
            }
        }
    }
}
