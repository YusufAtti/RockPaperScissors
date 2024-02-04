using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab1
{
    class Kullanici : Oyuncu
    {




        public Kullanici()
        {

        }

        public Kullanici(int oyuncuId, String oyuncuAdi , int skor , List<nesne> nesneListesi)
        {
            this.oyuncuAdi = oyuncuAdi;
            this.oyuncuId = oyuncuId;
            this.skor = skor;
            this.nesneListesi = nesneListesi;
        }

        public override nesne nesneSec()
        {
            throw new NotImplementedException();
        }
    }
}
