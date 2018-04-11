using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{
    class Klasa
    {
        public static hciEntities1 baza = new hciEntities1();

        public void podesiDatePicker(DateTimePicker a,DateTimePicker b)
        {
            a.Value = DateTime.Today;
            b.Value = DateTime.Today;
        }

        public void ogranicenjaDatePicker(DateTimePicker a,DateTimePicker b)
        {
            int vrijednost = DateTime.Compare(a.Value, b.Value);
            if (vrijednost > 0)
            {
                b.Value = a.Value;
            }

        }


    }
}
