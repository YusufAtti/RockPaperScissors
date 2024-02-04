using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab1
{
    abstract class Oyuncu
    {
        public int oyuncuId;
        public String oyuncuAdi;
        public int skor;
        public List<nesne> nesneListesi = new List<nesne>();


        public Oyuncu()
        {

        }

        public Oyuncu(int oyuncuId , String oyuncuAdi , int skor)
        {
            this.oyuncuAdi = oyuncuAdi;
            this.oyuncuId = oyuncuId;
            this.skor = skor;
        }

        public void skorGoster() {

        }

        public abstract nesne nesneSec();




    }
}
