using System;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{
    public partial class DodajNoviElementForma : Form
    {
        private poddogadjaj podd;
        private Klasa klasa = new Klasa();
        private element el;
        public DodajNoviElementForma(poddogadjaj p)
        {
            InitializeComponent();
            podd = p;
        }
        public DodajNoviElementForma(element ele)
        {
            InitializeComponent();
            el = ele;
        }
        private void DodajNoviElementForma_Load(object sender, EventArgs e)
        {
            if (podd != null)
            {
                datumPocetkaDateTimePicker.Value = podd.datumPocetka;
                datumKrajaDateTimePicker.Value = podd.datumKraja;
            }
            if (el != null)
            {
                element kopiranElement = element.DeepClone(el);
                elementBindingSource.DataSource = kopiranElement;
                String VPocetka = kopiranElement.vrijemePocetka.ToString();
                string[] VPvremena = VPocetka.Split(':');
                numericUpDown3.Value = int.Parse(VPvremena[0]);
                numericUpDown4.Value = int.Parse(VPvremena[1]);
                String VKraja = kopiranElement.vrijemeKraja.ToString();
                string[] VKvremena = VKraja.Split(':');
                numericUpDown1.Value = int.Parse(VKvremena[0]);
                numericUpDown2.Value = int.Parse(VKvremena[1]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nazivTextBox.Text != "" && vrstaTextBox.Text != "" && lokacijaTextBox.Text != "" && opisTextBox.Text != "" && numericUpDown1.Text != "" && numericUpDown2.Text != "")
            {
                if (el == null)
                {
                    el = new element();
                }
                el.naziv = nazivTextBox.Text;
                el.lokacija = lokacijaTextBox.Text;
                el.opis = opisTextBox.Text;
                el.vrsta = vrstaTextBox.Text;
                el.obrisan = false;
                string satPoc = numericUpDown3.Value.ToString();
                decimal minutPoc = numericUpDown4.Value;
                string vrijemePoc = satPoc + ":" + minutPoc.ToString();
                el.vrijemePocetka = TimeSpan.Parse(vrijemePoc);
                string sat = numericUpDown1.Value.ToString();
                decimal minut = numericUpDown2.Value;
                string vrijeme = sat + ":" + minut.ToString();
                el.vrijemeKraja = TimeSpan.Parse(vrijeme);
                el.datumPocetka = datumPocetkaDateTimePicker.Value;
                el.datumKraja = datumKrajaDateTimePicker.Value;

                if (podd != null)
                {
                    el.podDogadjaj_idpodDogadjaj = podd.idpodDogadjaj;
                    Klasa.baza.elements.Add(el);
                }
                Klasa.baza.SaveChanges();
                this.Dispose();

            }
            else
            {
                MessageBox.Show("Nisu uneseni svi potrebni podaci.");
            }
        }

        private void datumPocetkaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (podd != null)
            {
                if (DateTime.Compare(datumPocetkaDateTimePicker.Value, podd.datumPocetka) < 0)
                    datumPocetkaDateTimePicker.Value = podd.datumPocetka;
                if (DateTime.Compare(datumPocetkaDateTimePicker.Value, podd.datumKraja) > 0)
                {
                    datumPocetkaDateTimePicker.Value = podd.datumKraja;
                }
            }
            klasa.ogranicenjaDatePicker(datumPocetkaDateTimePicker, datumKrajaDateTimePicker);
        }

        private void datumKrajaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (podd != null)
            {
                if (DateTime.Compare(datumKrajaDateTimePicker.Value, podd.datumKraja) > 0)
                    datumKrajaDateTimePicker.Value = podd.datumKraja;
            }
            klasa.ogranicenjaDatePicker(datumPocetkaDateTimePicker, datumKrajaDateTimePicker);
        }

        private void DodajNoviElementForma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button3_Click(sender, e);
            }
        }
    }
}
