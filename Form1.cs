using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jubilacrono
{
    public partial class Form1 : Form
    {
        DateTime limite = new DateTime(2026, 11, 30, 13, 45, 00);
        DateTime currentDateTime;
        TimeSpan diferencia;

        public Form1()
        {
            InitializeComponent();
            try
            {
                IResourceReader rr = new ResourceReader("myResources.resources");
                foreach (System.Collections.DictionaryEntry d in rr)
                {
                    limite = (DateTime)d.Value;
                }
                //Close the resxReader
                rr.Close();
            }catch(Exception e)
            {
                Console.WriteLine("no hay elementos guardados.");
            }

            dateTimePicker1.Value = limite;

            currentDateTime = DateTime.Now;
            diferencia = limite - currentDateTime;
            timetoend.Text = diferencia.Days + " Dias \n" + diferencia.Hours + ":" + diferencia.Minutes + ":" + diferencia.Seconds;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentDateTime = DateTime.Now;
            diferencia = limite - currentDateTime;
            timetoend.Text = diferencia.Days + " Dias \n" +diferencia.Hours +":" + diferencia.Minutes +":"+ diferencia.Seconds;
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            limite = dateTimePicker1.Value;
            IResourceWriter rw = new ResourceWriter("myResources.resources");
            rw.AddResource("limite", limite);
            rw.Close();
        }
    }
}
