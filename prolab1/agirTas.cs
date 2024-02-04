using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace prolab1
{
    class AgirTas : Tas
    {
        public int sicaklik = 2;
        
        public AgirTas()
        {

        }

        public AgirTas (int dayaniklik , int seviyePuani ,  int sicaklik)
        {
            this.sicaklik = sicaklik;
            this.dayaniklik = dayaniklik;
            this.seviyePuani = seviyePuani;
            this.nesneAdi = "Agir Tas";
        }


        public override double etkiPuaniHesapla(nesne r1)
        {
            double etki = 0;
            if (nesne.Equals(r1.GetType(), new Makas().GetType()))
            {
                Makas makas = (Makas)r1;
                etki = Katilik * sicaklik;
                etki /= (0.2) * makas.Keskinlik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new Kagit().GetType()))
            {
                Kagit kagit = (Kagit)r1;
                etki = Katilik * sicaklik;
                etki /= (1 - 0.2) * kagit.Nüfuz;
                return etki;
            }
            else if (nesne.Equals(r1.GetType(), new Tas().GetType()))
            {
                etki = Katilik * sicaklik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new AgirTas().GetType()))
            {
                etki = Katilik * sicaklik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new ozelKagit().GetType()))
            {
                ozelKagit _ozelkagit = (ozelKagit)r1;
                etki = Katilik * sicaklik;
                etki /= (1 - 0.2) * _ozelkagit.Nüfuz * _ozelkagit.Kalinlik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new ustaMakas().GetType()))
            {
                ustaMakas _ustamakas = (ustaMakas)r1;
                etki = Katilik * sicaklik;
                etki /= (0.2) * _ustamakas.Keskinlik * _ustamakas.hiz;
                return etki;
            }

            return 0;
        }

        public override void durumGuncelle(double etki, Boolean yendiMi)
        {
            this.dayaniklik -= etki;
            if (yendiMi)
            {
                seviyePuani += 20;
            }

        }
    }
}
