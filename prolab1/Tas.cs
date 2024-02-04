using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace prolab1
{
    class Tas : nesne
    {


        //Bu sınıfa özel özellik tanımlaniyor ve getter setter işlemleri yapılıyor
        private double katilik = 2;

        public double Katilik
        {
            get { return katilik; }
            set { katilik = Katilik; }
        }



        public Tas()
        {

        }

        public Tas(double dayaniklik , double seviyePuani , double katilik)
        {
            this.katilik = katilik;
            this.seviyePuani = seviyePuani;
            this.dayaniklik = dayaniklik;
            nesneAdi = "TAŞ";

        }

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
            double etki = 0;
            if (nesne.Equals(r1.GetType(), new Makas().GetType()))
            {
                Makas makas = (Makas)r1;
                etki = katilik;
                etki /= (0.2) * makas.Keskinlik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new Kagit().GetType()))
            {
                Kagit kagit = (Kagit)r1;
                etki = katilik;
                etki /= (1 - 0.2) * kagit.Nüfuz;
                return etki;
            }
            else if (nesne.Equals(r1.GetType(), this.GetType()))
            {
                etki = katilik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType() , new AgirTas().GetType()))
            {
                AgirTas agirTas = (AgirTas)r1;
                etki = Katilik;
                return etki;
            }
            else if (nesne.Equals(r1.GetType() , new ozelKagit().GetType()))
            {
                ozelKagit ozelkagit = (ozelKagit)r1;
                etki = katilik;
                etki /= (1 - 0.2) * ozelkagit.Nüfuz * ozelkagit.Kalinlik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new ustaMakas().GetType()))
            {
                ustaMakas ustaMakas = (ustaMakas)r1;
                etki = katilik;
                etki /= (0.2) * ustaMakas.Keskinlik * ustaMakas.hiz;
                return etki;
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
