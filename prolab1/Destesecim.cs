using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace prolab1
{
    public partial class Destesecim : Form
    {
        public String oyuncuAdi;
        List<nesne> deste = new List<nesne>();
        List<nesne> bilgisayarınDestesi = new List<nesne>();

        public Destesecim(String oyuncuAdi) 
        {
            this.oyuncuAdi = oyuncuAdi;
            InitializeComponent();
        }

        private void Destesecim_Load(object sender, EventArgs e)
        {
            bilgisayaraTasAta();
        }

        private void bilgisayaraTasAta()
        {
            ArrayList liste = new ArrayList();
            liste.Add("Tas");
            liste.Add("Kagit");
            liste.Add("Makas");
            Random rnd = new Random();
            for(int i = 0; i<5; i++)
            {
                int sayi = rnd.Next(0, 3);
                Console.WriteLine("Rastgele Sayi : " + sayi);
                if (liste[sayi].Equals("Tas"))
                {
                    bilgisayarınDestesi.Add(new Tas(20,0,2));
                }
                else if (liste[sayi].Equals("Makas"))
                {
                    bilgisayarınDestesi.Add(new Makas(20, 0, 2));
                }
                else if (liste[sayi].Equals("Kagit"))
                {
                    bilgisayarınDestesi.Add(new Kagit(20, 0, 2));
                }
            }
        }

        private void buttonTas_Click(object sender, EventArgs e)
        {   
            deste.Add(new Tas(20,0,2));
            if(deste.Count == 5)
            {
                buttonBasla.Enabled = true;
                buttonKagit.Enabled = false;
                buttonMakas.Enabled = false;
                buttonTas.Enabled = false;
            }
        }

        private void buttonKagit_Click(object sender, EventArgs e)
        {
            deste.Add(new Kagit(20, 0, 2));
            if (deste.Count == 5)
            {
                buttonBasla.Enabled = true;
                buttonKagit.Enabled = false;
                buttonMakas.Enabled = false;
                buttonTas.Enabled = false;
            }

        }

        private void buttonMakas_Click(object sender, EventArgs e)
        {
            deste.Add(new Makas(20, 0, 2));
            if (deste.Count == 5)
            {
                buttonBasla.Enabled = true;
                buttonKagit.Enabled = false;
                buttonMakas.Enabled = false;
                buttonTas.Enabled = false;
            }
        }

        private void buttonBasla_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = new Kullanici(1,oyuncuAdi,0,deste);
            Bilgisayar bilgisayar = new Bilgisayar(2, "Bilgisayar", 0 , bilgisayarınDestesi);
            Savasalani savasalani = new Savasalani(kullanici , bilgisayar);
            this.Hide();
            savasalani.Show();
        }
    }
}
