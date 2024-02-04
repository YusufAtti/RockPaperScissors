using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab1
{

    class Bilgisayar : Oyuncu
    {
        public List<int> secilenSayilar = new List<int>();
        
        public Bilgisayar()
        {

        }

        public Bilgisayar(int oyuncuId, String oyuncuAdi , int skor , List<nesne> bilgisayarinDestesi)
        {
            this.oyuncuAdi = oyuncuAdi;
            this.oyuncuId = oyuncuId;
            this.skor = skor;
            nesneListesi = bilgisayarinDestesi;
        }

        //Random nesne seçmek için override yapıyoruz.
        public override nesne nesneSec()
        {
           // int nesneListesiElamanSayisi = nesneListesi.Count;
            Console.WriteLine(oyuncuId + "  *************Nesne Listesi Sayisi : " + nesneListesi.Count);
            if (secilenSayilar.Count == nesneListesi.Count)
                secilenSayilar.Clear();
            Random rnd = new Random();
            int sayi;
            Boolean varMi;
            while (true)
            {
                varMi = false;
                sayi = rnd.Next(0, nesneListesi.Count);
                foreach (var item in secilenSayilar)
                {
                    if(item == sayi)
                    {
                        varMi = true;
                        break;
                    }
                }
                if(varMi == false)
                {
                    secilenSayilar.Add(sayi);
                    break;
                }
            }
            Console.WriteLine("Bilgisayarin Sectigi kart" + nesneListesi[sayi] + " Rastgele Sayi : " + sayi);
            return nesneListesi[sayi];
        }
       
    }
}
