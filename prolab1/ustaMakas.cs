using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab1
{
    class ustaMakas : Makas
    {
        public int hiz;

        public ustaMakas(){

        }

        public ustaMakas(int dayaniklik, int seviyePuani,  int hiz)
        {
            this.dayaniklik = dayaniklik;
            this.seviyePuani = seviyePuani;
            this.hiz = hiz;
            this.nesneAdi = "Usta Makas";
        }

        public override double etkiPuaniHesapla(nesne r1)
        {
            double makasEtkisi;
            if (nesne.Equals(r1.GetType(), new Tas().GetType()))
            {
                Tas ts = (Tas)r1;
                makasEtkisi = Keskinlik * hiz;
                makasEtkisi /= (1 - 0.2) * ts.Katilik;
                return makasEtkisi;
            }

            else if (nesne.Equals(r1.GetType(), new Kagit().GetType()))
            {
                Kagit kagit = (Kagit)r1;
                makasEtkisi = Keskinlik * hiz;
                makasEtkisi /= (0.2) * kagit.Nüfuz;
                return makasEtkisi;
            }
            else if (nesne.Equals(r1.GetType(), new Makas().GetType()))
            {
                makasEtkisi = Keskinlik * hiz;
                return makasEtkisi;
            }
            else if (nesne.Equals(r1.GetType(), new ustaMakas().GetType()))
            {
                makasEtkisi = Keskinlik * hiz;
                return makasEtkisi;
            }
            else if (nesne.Equals(r1.GetType(), new AgirTas().GetType()))
            {
                AgirTas agirTas = (AgirTas)r1;
                makasEtkisi = Keskinlik * hiz;
                makasEtkisi /= (1 - 0.2) * agirTas.Katilik * agirTas.sicaklik;
                return makasEtkisi;
            }
            else if (nesne.Equals(r1.GetType(), new ozelKagit().GetType()))
            {
                ozelKagit ozelkagit = (ozelKagit)r1;
                makasEtkisi = Keskinlik * hiz;
                makasEtkisi /= (0.2) * ozelkagit.Nüfuz * ozelkagit.Kalinlik;
                return makasEtkisi;
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
