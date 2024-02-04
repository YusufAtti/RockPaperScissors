using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;


namespace prolab1
{
    class Makas : nesne
    {

        //Bu sınıfa özel özellik tanımlaniyor ve getter setter işlemleri yapılıyor
        private double keskinlik = 2;

        public double Keskinlik
        {
            get { return keskinlik; }
            set { keskinlik = Keskinlik; }
        }



        //Paremetresiz kurucu metod
        public Makas()
        {
            
        }


        //Paremetleri Kurucu metod
        public Makas(int dayaniklik , int seviyePuani , int keskinlik)
        {
            this.dayaniklik = dayaniklik;
            this.seviyePuani = seviyePuani;
            this.keskinlik = keskinlik;
            nesneAdi = "Makas";
        }



        //Override edilen fonksiyonlar
        public override void durumGuncelle(double etki , Boolean yendiMi)
        {
            this.dayaniklik -= etki;
            if (yendiMi)
            {
                seviyePuani += 20;
            }

        }

        public override double etkiPuaniHesapla(nesne r1)
        {
            double makasEtkisi;
            if(nesne.Equals(r1.GetType(), new Tas().GetType()))
            {
                Tas ts = (Tas)r1;
                makasEtkisi = keskinlik;
                makasEtkisi /= (1 - 0.2) * ts.Katilik;
                return makasEtkisi;
            }

            else if(nesne.Equals(r1.GetType(), new Kagit().GetType()))
            {
                Kagit kagit = (Kagit)r1;
                makasEtkisi = keskinlik;
                makasEtkisi /= (0.2) * kagit.Nüfuz;
                return makasEtkisi;
            }
            else if(nesne.Equals(r1.GetType(), this.GetType()))
            {
                makasEtkisi = keskinlik;
                return makasEtkisi;
            }

            else if (nesne.Equals(r1.GetType(), new AgirTas().GetType()))
            {
                AgirTas agirTas = (AgirTas)r1;
                makasEtkisi = Keskinlik;
                makasEtkisi /= (1 - 0.2) * agirTas.Katilik * agirTas.sicaklik; 
                return makasEtkisi;
            }
            else if (nesne.Equals(r1.GetType(), new ozelKagit().GetType()))
            {
                ozelKagit ozelkagit = (ozelKagit)r1;
                makasEtkisi = Keskinlik;
                makasEtkisi /= (0.2) * ozelkagit.Nüfuz * ozelkagit.Kalinlik;
                return makasEtkisi;
            }

            else if (nesne.Equals(r1.GetType(), new ustaMakas().GetType()))
            {
                ustaMakas ustaMakas = (ustaMakas)r1;
                makasEtkisi = Keskinlik;
                return makasEtkisi;
            }

            return 0;
        }

        public override void nesnePuaniGoster(List<Label> labels , Button btn)
        {
            if (dayaniklik <= 0)
            {
                btn.Enabled = false;
                btn.Text = "I am dead Man";
            }

            labels[0].Text = nesneAdi;
            labels[1].Text = dayaniklik.ToString();
            labels[2].Text = seviyePuani.ToString();                
            
        }
    }
}
