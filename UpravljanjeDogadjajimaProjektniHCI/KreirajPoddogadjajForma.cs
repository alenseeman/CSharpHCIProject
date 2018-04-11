using System;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{
    public partial class KreirajPoddogadjajForma : Form
    {
        private dogadjaj dog;
        private poddogadjaj poddog;
        private Klasa klasa = new Klasa();

        public KreirajPoddogadjajForma()
        {
            InitializeComponent();
        }

        public KreirajPoddogadjajForma(dogadjaj dog)
        {
            InitializeComponent();
            this.dog = dog;
        }
        public KreirajPoddogadjajForma(poddogadjaj podd)
        {
            InitializeComponent();
            this.poddog = podd;
        }
        private void KreirajPoddogadjajForma_Load(object sender, EventArgs e)
        {
            if (dog != null)
            {
                datumPocetkaDateTimePicker.Value = dog.datumPocetka;
                datumKrajaDateTimePicker.Value = dog.datumKraja;
            }
            if (poddog != null)
            {
                poddogadjaj kopiranPoddogadjaj = poddogadjaj.DeepClone(poddog);
                poddogadjajBindingSource.DataSource = kopiranPoddogadjaj;
                String VPocetka = kopiranPoddogadjaj.vrijemePocetka.ToString();
                string[] VPvremena = VPocetka.Split(':');
                numericUpDown3.Value = int.Parse(VPvremena[0]);
                numericUpDown4.Value = int.Parse(VPvremena[1]);
                String VKraja = kopiranPoddogadjaj.vrijemKraja.ToString();
                string[] VKvremena = VKraja.Split(':');
                numericUpDown1.Value = int.Parse(VKvremena[0]);
                numericUpDown2.Value = int.Parse(VKvremena[1]);
            }
        }


        private void datumKrajaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dog != null)
            {
                if (DateTime.Compare(datumKrajaDateTimePicker.Value, dog.datumKraja) > 0)
                    datumKrajaDateTimePicker.Value = dog.datumKraja;
            }
            klasa.ogranicenjaDatePicker(datumPocetkaDateTimePicker, datumKrajaDateTimePicker);
        }

        private void datumPocetkaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dog != null)
            {
                if (DateTime.Compare(datumPocetkaDateTimePicker.Value, dog.datumPocetka) < 0)
                    datumPocetkaDateTimePicker.Value = dog.datumPocetka;
                if (DateTime.Compare(datumPocetkaDateTimePicker.Value, dog.datumKraja) > 0)
                {
                    datumPocetkaDateTimePicker.Value = dog.datumKraja;
                }
            }
            klasa.ogranicenjaDatePicker(datumPocetkaDateTimePicker, datumKrajaDateTimePicker);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nazivTextBox.Text != "" && vrstaTextBox.Text != "" && lokacijaTextBox.Text != "" && opisTextBox.Text != "" && numericUpDown1.Text != "" && numericUpDown2.Text != "")
            {
                if (poddog == null)
                {
                    poddog = new poddogadjaj();
                }
                poddog.naziv = nazivTextBox.Text;
                poddog.lokacija = lokacijaTextBox.Text;
                poddog.opis = opisTextBox.Text;
                poddog.obrisan = false;
                poddog.vrsta = vrstaTextBox.Text;
                string satPoc = numericUpDown3.Value.ToString();
                decimal minutPoc = numericUpDown4.Value;
                string vrijemePoc = satPoc + ":" + minutPoc.ToString();
                poddog.vrijemePocetka = TimeSpan.Parse(vrijemePoc);
                string sat = numericUpDown1.Value.ToString();
                decimal minut = numericUpDown2.Value;
                string vrijeme = sat + ":" + minut.ToString();
                poddog.vrijemKraja = TimeSpan.Parse(vrijeme);
                poddog.datumPocetka = datumPocetkaDateTimePicker.Value;
                poddog.datumKraja = datumKrajaDateTimePicker.Value;
                if (dog != null)
                {
                    poddog.dogadjaj_iddogadjaj = dog.iddogadjaj;
                    Klasa.baza.poddogadjajs.Add(poddog);
                }
                Klasa.baza.SaveChanges();
                KreiranPoddogadjajForma kpf = new KreiranPoddogadjajForma(poddog, "NOVI");
                kpf.Show();
                this.Dispose();

            }
            else
            {
                MessageBox.Show("Nisu uneseni svi potrebni podaci.");
            }
        }

        private void KreirajPoddogadjajForma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button3_Click(sender, e);
            }
        }
    }
}
