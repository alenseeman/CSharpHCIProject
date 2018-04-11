using System;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{
    public partial class GlavnaForma : Form
    {
        private Klasa klasa = new Klasa();
        private dogadjaj dog;
        string nacinPredstave;
        public GlavnaForma()
        {
            InitializeComponent();
        }

        public GlavnaForma(dogadjaj d,string na)
        {
            InitializeComponent();
            dog = d;
            nacinPredstave = na;
        }

        private void GlavnaForma_Load(object sender, EventArgs e)
        {
            klasa.podesiDatePicker(datumKrajaDateTimePicker, datumPocetkaDateTimePicker);
            if (dog!=null)
            {
                dogadjaj kopiranDogadjaj = dogadjaj.DeepClone(dog);
                dogadjajBindingSource.DataSource = kopiranDogadjaj;
                String VPocetka = kopiranDogadjaj.vrijemePocetka.ToString();
                string[] VPvremena = VPocetka.Split(':');
                numericUpDown3.Value = int.Parse(VPvremena[0]);
                numericUpDown4.Value = int.Parse(VPvremena[1]);
                String VKraja = kopiranDogadjaj.vrijemeKraja.ToString();
                string[] VKvremena = VKraja.Split(':');
                numericUpDown1.Value = int.Parse(VKvremena[0]);
                numericUpDown2.Value = int.Parse(VKvremena[1]);

            }
           
        }
        private void datumKrajaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            klasa.ogranicenjaDatePicker(datumPocetkaDateTimePicker, datumKrajaDateTimePicker);
        }

        private void datumPocetkaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            klasa.ogranicenjaDatePicker(datumPocetkaDateTimePicker, datumKrajaDateTimePicker);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nazivTextBox.Text != "" && vrstaTextBox.Text != "" && lokacijaTextBox.Text != "" && opisTextBox.Text != "" && numericUpDown1.Text != "" && numericUpDown2.Text != "")
            {
                if (dog == null)
                {
                 dog = new dogadjaj();
                }
                dog.naziv = nazivTextBox.Text;
                dog.lokacija = lokacijaTextBox.Text;
                dog.opis = opisTextBox.Text;
                dog.obrisan = false;
                dog.vrsta = vrstaTextBox.Text;
                string satPoc = numericUpDown3.Value.ToString();
                decimal minutPoc = numericUpDown4.Value;
                string vrijemePoc = satPoc + ":" + minutPoc.ToString();
                dog.vrijemePocetka = TimeSpan.Parse(vrijemePoc);
                string sat = numericUpDown1.Value.ToString();
                decimal minut = numericUpDown2.Value;
                string vrijeme = sat + ":" + minut.ToString();
                dog.vrijemeKraja = TimeSpan.Parse(vrijeme);
                dog.datumPocetka = datumPocetkaDateTimePicker.Value;
                dog.datumKraja = datumKrajaDateTimePicker.Value;
                if ("IZMJENA".Equals(nacinPredstave))
                {
                    
                    KreiranDogadjajForma krf = new KreiranDogadjajForma(dog, "IZMJENA");
                    krf.Show();
                    this.Dispose();
                }
                else
                {
                    Klasa.baza.dogadjajs.Add(dog);
                    KreiranDogadjajForma krf = new KreiranDogadjajForma(dog, "NOVI");
                    krf.Show();
                    this.Dispose();
                }
                Klasa.baza.SaveChanges();
          
            }
            else
            {
                MessageBox.Show("Nisu uneseni svi potrebni podaci.");
            }
        }

        private void GlavnaForma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button3_Click(sender, e);
            }
        }
    }
}