using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab1
{
    class ozelKagit : Kagit
    {
        private double kalinlik = 2;

        public double Kalinlik
        {
            get { return kalinlik; }
            set { kalinlik = Kalinlik; }
        }

        public ozelKagit()
        {
           
        }

        public ozelKagit(double dayaniklik , double seviyePuani , double kalinlik)
        {
            this.dayaniklik = dayaniklik;
            this.seviyePuani = seviyePuani;
            this.kalinlik = kalinlik;
            this.nesneAdi = "Ozel Kagit";
        }


        public override void durumGuncelle(double etki, Boolean yendiMi)
        {
            this.dayaniklik -= etki;
            if (yendiMi)
            {
                seviyePuani += 20;
            }

        }


        public override double etkiPuaniHesapla(nesne r1)
        {
            double etki;
            if (nesne.Equals(r1.GetType(), new Tas().GetType()))
            {
                Tas ts = (Tas)r1;
                etki = Nüfuz * Kalinlik;
                etki /= (0.2) * ts.Katilik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new Makas().GetType()))
            {
                Makas makas = (Makas)r1;
                etki = Nüfuz * Kalinlik;
                etki /= (1 - 0.2) * makas.Keskinlik;
                return etki;
            }
            else if (nesne.Equals(r1.GetType(), new Kagit().GetType()))
            {
                etki = Nüfuz * Kalinlik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new ozelKagit().GetType()))
            {
                etki = Nüfuz * Kalinlik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new ustaMakas().GetType()))
            {
                ustaMakas _ustamakas = (ustaMakas)r1;
                etki = Nüfuz * Kalinlik;
                etki /= (1 - 0.2) * _ustamakas.Keskinlik * _ustamakas.hiz;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new AgirTas().GetType()))
            {
                AgirTas agirtas = (AgirTas)r1;
                etki = Nüfuz * Kalinlik;
                etki /= (0.2) * agirtas.Katilik * agirtas.sicaklik;
                return etki;
            }

            return 0;
        }






    }
}
