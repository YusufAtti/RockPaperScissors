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
    public partial class Form1 : Form
    {
        List<nesne> bilgisayarınDestesi1 = new List<nesne>();
        List<nesne> bilgisayarınDestesi2 = new List<nesne>();
        ArrayList liste = new ArrayList();
        

        public Form1()
        {
            liste.Add("Tas");
            liste.Add("Kagit");
            liste.Add("Makas");
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                int sayi = rnd.Next(0, 3);
                Console.WriteLine("Rastgele Sayi : " + sayi);
                if (liste[sayi].Equals("Tas"))
                {
                    bilgisayarınDestesi1.Add(new Tas(20, 0, 2));
                }
                else if (liste[sayi].Equals("Makas"))
                {
                    bilgisayarınDestesi1.Add(new Makas(20, 0, 2));
                }
                else if (liste[sayi].Equals("Kagit"))
                {
                    bilgisayarınDestesi1.Add(new Kagit(20, 0, 2));
                }
            }
            Console.WriteLine("-------------------");
            System.Threading.Thread.Sleep(500);
            Random rnd1 = new Random();
            for (int i = 0; i < 5; i++)
            {
                int sayi1 = rnd1.Next(0, 3);
                Console.WriteLine("Rastgele Sayi : " + sayi1);
                if (liste[sayi1].Equals("Tas"))
                {
                    bilgisayarınDestesi2.Add(new Tas(20, 0, 2));
                }
                else if (liste[sayi1].Equals("Makas"))
                {
                    bilgisayarınDestesi2.Add(new Makas(20, 0, 2));
                }
                else if (liste[sayi1].Equals("Kagit"))
                {
                    bilgisayarınDestesi2.Add(new Kagit(20, 0, 2));
                }
            }


            Bilgisayar bilgisayar1 = new Bilgisayar(1, "Bilgisayar_1", 0, bilgisayarınDestesi1);
            Bilgisayar bilgisayar2 = new Bilgisayar(2, "Bilgisayar_2", 0, bilgisayarınDestesi2);
            BilgisayarVsBilgisayar bilgisayarVsBilgisayar = new BilgisayarVsBilgisayar(bilgisayar1, bilgisayar2);
            this.Hide();
            bilgisayarVsBilgisayar.Show();
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void labelLoginPage_Click(object sender, EventArgs e)
        {

        }

        private void textBoxOyuncuAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(buttonLogin.Visible == true)
                Application.Exit();
            else
            {
                String oyuncuAdi = textBoxName.Text.ToString();
                this.Hide();
                Savasalani.hamleSayisi = Convert.ToInt32(textBoxHamleSayisi.Text);
                Destesecim ds = new Destesecim(oyuncuAdi);
                ds.Show();
            }
                   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxName.Visible = true;
            textBoxHamleSayisi.Visible = true;
            buttonLogin.Visible = false;
            button1.Visible = false;
            button2.Text = "Giriş";
        }

        private void textBoxName_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxName.Text = "";
        }

        private void textBoxHamleSayisi_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxHamleSayisi.Text = "";
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
