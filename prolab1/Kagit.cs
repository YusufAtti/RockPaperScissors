using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace prolab1
{
    class Kagit : nesne
    {

        //Bu sınıfa özel özellik tanımlaniyor ve getter setter işlemleri yapılıyor

        private double nüfuz = 2;
       
        public double Nüfuz
        {
            get { return nüfuz; }
            set { nüfuz = Nüfuz; }
        }

        public Kagit() {
                
        }

        public Kagit (int dayaniklik , int seviyePuani , int nüfuz)
        {
            this.nüfuz = nüfuz;
            this.dayaniklik = dayaniklik;
            this.seviyePuani = seviyePuani;
            nesneAdi = "KAĞIT";         
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
            double etki;
            if (nesne.Equals(r1.GetType(), new Tas().GetType()))
            {
                Tas ts = (Tas)r1;
                etki = nüfuz;
                etki /= (0.2) * ts.Katilik;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new Makas().GetType()))
            {
                Makas makas = (Makas)r1;
                etki = nüfuz;
                etki /= (1 - 0.2) * makas.Keskinlik;
                return etki;
            }
            else if (nesne.Equals(r1.GetType(), this.GetType()))
            {
                etki = nüfuz;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new AgirTas().GetType()))
            {
                AgirTas agirTas = (AgirTas)r1;
                etki = Nüfuz;
                etki /= (0.2) * agirTas.Katilik * agirTas.sicaklik;
                return etki;
            }
            else if (nesne.Equals(r1.GetType(), new ozelKagit().GetType()))
            {
                ozelKagit ozelkagit = (ozelKagit)r1;
                etki = Nüfuz;
                return etki;
            }

            else if (nesne.Equals(r1.GetType(), new ustaMakas().GetType()))
            {
                ustaMakas ustaMakas = (ustaMakas)r1;
                etki = Nüfuz;
                etki /= (1 - 0.2) * ustaMakas.Keskinlik * ustaMakas.hiz;
                return etki;
            }
            return 0;
        }

        public override void nesnePuaniGoster(List<Label> labels , Button btn)
        {
            if(dayaniklik <= 0)
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
