using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prolab1
{
    partial class BilgisayarVsBilgisayar : Form
    {
        public static int sayac = 0;
        List<Button> buttons = new List<Button>();
        List<Button> buttons1 = new List<Button>();

        Bilgisayar _bilgisayar1 , _bilgisayar2;
        
        public BilgisayarVsBilgisayar(Bilgisayar bilgisayar1 , Bilgisayar bilgisayar2)
        {
            _bilgisayar1 = bilgisayar1;
            _bilgisayar2 = bilgisayar2;
            InitializeComponent();
        }

        
        int bilgisayar1nesneSayisi = 5;
        int bilgisayar2nesneSayisi = 5;

        private void bilgisayarEkranaYansit()
        {
            int nesneElamanSayisi = _bilgisayar1.nesneListesi.Count;
            for (int i = 0; i < nesneElamanSayisi; i++)
            {
                if (_bilgisayar1.nesneListesi[i].dayaniklik <= 0)
                {
                    buttons[i].Text = "I am dead";
                    buttons[i].Enabled = false;

                    Console.WriteLine("Kart : " + (i + 1) + " " + _bilgisayar1.nesneListesi[i].dayaniklik);
                    _bilgisayar1.nesneListesi.Remove(_bilgisayar1.nesneListesi[i]);
                    buttons.RemoveAt(i);
                    Console.WriteLine("Nesne Listesi : ");

                    foreach (var item in _bilgisayar1.nesneListesi)
                    {
                        Console.WriteLine(item);
                    }

                    _bilgisayar1.secilenSayilar.Remove(i);
                    nesneElamanSayisi--;
                }
            }

            int nesneElamanSayisi2 = _bilgisayar2.nesneListesi.Count;
            for (int i = 0; i < nesneElamanSayisi2; i++)
            {
                if (_bilgisayar2.nesneListesi[i].dayaniklik <= 0)
                {
                    buttons1[i].Text = "I am dead";
                    buttons1[i].Enabled = false;

                    Console.WriteLine("Kart : " + (i + 1) + " " + _bilgisayar2.nesneListesi[i].dayaniklik);
                    _bilgisayar2.nesneListesi.Remove(_bilgisayar2.nesneListesi[i]);
                    buttons1.RemoveAt(i);
                    Console.WriteLine("Nesne Listesi : ");

                    foreach (var item in _bilgisayar2.nesneListesi)
                    {
                        Console.WriteLine(item);
                    }

                    _bilgisayar2.secilenSayilar.Remove(i);
                    nesneElamanSayisi2--;
                }
            }

        }


        private void baslat()
        {
                sayac++;

                //Rastgele veriler seçiliyor.
                nesne bilgisayar1Sectigi = _bilgisayar1.nesneSec();
                System.Threading.Thread.Sleep(200);

                nesne bilgisayar2Sectigi = _bilgisayar2.nesneSec();
                //System.Threading.Thread.Sleep(200);
                double bilgisayar1Etkisi = bilgisayar1Sectigi.etkiPuaniHesapla(bilgisayar2Sectigi);
                //System.Threading.Thread.Sleep(200);
                double bilgisayar2Etkisi = bilgisayar2Sectigi.etkiPuaniHesapla(bilgisayar1Sectigi);

                //System.Threading.Thread.Sleep(500);
                
                //Ekranda gösteriliyor
                secilen1.Text = bilgisayar1Sectigi.nesneAdi;
                secilen2.Text = bilgisayar2Sectigi.nesneAdi;
                
                //Etkiler Hesaplandi.


                //Ekranda gösteriliyor
                Console.WriteLine("Bilgisayar 1 : " + bilgisayar1Sectigi + "  Bilgisayar 2 : " + bilgisayar2Sectigi);
                Console.WriteLine("=>>>>>>>>>Bilgisayar 1 Etkisi: " + bilgisayar1Etkisi + "  Bilgisayar 2 : " + bilgisayar2Etkisi);
                Console.WriteLine("=>>>>>>>>>Bilgisayar 1 Dayaniklik : " + bilgisayar1Sectigi.dayaniklik + "  Bilgisayar 2 : " + bilgisayar2Sectigi.dayaniklik);


                //Dayaniklik ve seviye Puani güncelleme
                if (bilgisayar1Etkisi < bilgisayar2Etkisi)
                {
                    _bilgisayar2.skor++;
                    bilgisayar1Sectigi.durumGuncelle(bilgisayar2Etkisi, false);
                    bilgisayar2Sectigi.durumGuncelle(bilgisayar1Etkisi, true);
                }
                else if (bilgisayar2Etkisi < bilgisayar1Etkisi)
                {
                    _bilgisayar1.skor++;
                    bilgisayar1Sectigi.durumGuncelle(bilgisayar2Etkisi, true);
                    bilgisayar2Sectigi.durumGuncelle(bilgisayar1Etkisi, false);
                }
                else
                {
                    bilgisayar1Sectigi.durumGuncelle(bilgisayar2Etkisi, false);
                    bilgisayar2Sectigi.durumGuncelle(bilgisayar1Etkisi, false);
                }

                

                //Seviye Atlama
                if (bilgisayar1Sectigi.seviyePuani >= 30)
                {
                    int index = _bilgisayar1.nesneListesi.FindIndex(a => a == bilgisayar1Sectigi);
                    if (nesne.Equals(_bilgisayar1.nesneListesi[index].GetType(), new Tas().GetType()))
                    {
                        _bilgisayar1.nesneListesi[index] = new AgirTas(20, 0, 2);
                    }
                    else if (nesne.Equals(_bilgisayar1.nesneListesi[index].GetType(), new Makas().GetType()))
                    {
                        _bilgisayar1.nesneListesi[index] = new ustaMakas(20, 0, 2);
                    }
                    else if (nesne.Equals(_bilgisayar1.nesneListesi[index].GetType(), new Kagit().GetType()))
                    {
                        _bilgisayar1.nesneListesi[index] = new ozelKagit(20, 0, 2);
                    }

                }

                if (bilgisayar2Sectigi.seviyePuani >= 30)
                {
                    int index = _bilgisayar2.nesneListesi.FindIndex(a => a == bilgisayar2Sectigi);
                    if (nesne.Equals(_bilgisayar2.nesneListesi[index].GetType(), new Tas().GetType()))
                    {
                        _bilgisayar2.nesneListesi[index] = new AgirTas(20, 0, 2);
                    }
                    else if (nesne.Equals(_bilgisayar2.nesneListesi[index].GetType(), new Makas().GetType()))
                    {
                        _bilgisayar2.nesneListesi[index] = new ustaMakas(20, 0, 2);
                    }
                    else if (nesne.Equals(_bilgisayar2.nesneListesi[index].GetType(), new Kagit().GetType()))
                    {
                        _bilgisayar2.nesneListesi[index] = new ozelKagit(20, 0, 2);
                    }

                }

                //Skor ekranı güncelleniyor.
                labelBilgisayar1Skor.Text = _bilgisayar1.skor.ToString();
                labelBilgisayar2Skor.Text = _bilgisayar2.skor.ToString();
                bilgisayarEkranaYansit();


                if (bilgisayar1Sectigi.dayaniklik <= 0)
                {
                    int index = _bilgisayar1.nesneListesi.FindIndex(a => a == bilgisayar1Sectigi);
                    //_bilgisayar1.nesneListesi.RemoveAt(index);
                    bilgisayar1nesneSayisi--;
                    _bilgisayar1.secilenSayilar.Remove(index);
                    Console.WriteLine("Nesne Silindi : ");
                    foreach (var item in _bilgisayar1.nesneListesi)
                    {
                        Console.WriteLine(item);
                    }
                }

                if (bilgisayar2Sectigi.dayaniklik <= 0)
                {
                    int index = _bilgisayar2.nesneListesi.FindIndex(a => a == bilgisayar2Sectigi);
                    //_bilgisayar2.nesneListesi.RemoveAt(index);
                    bilgisayar2nesneSayisi--;
                    _bilgisayar2.secilenSayilar.Remove(index);
                    Console.WriteLine("Nesne Silindi :");
                    foreach (var item in _bilgisayar2.nesneListesi)
                    {
                        Console.WriteLine(item);
                    }
                }

            if (bilgisayar1nesneSayisi == 0 || bilgisayar2nesneSayisi == 0 || sayac == 80)
            {
                if(_bilgisayar1.skor < _bilgisayar2.skor)
                {
                    MessageBox.Show("Oyun Tamamlanmıştır. Kazanan Bilgisayar ID : " + _bilgisayar2.oyuncuId);
                }
                else if(_bilgisayar1.skor > _bilgisayar2.skor)
                {
                    MessageBox.Show("Oyun Tamamlanmıştır. Kazanan Bilgisayar ID : " + _bilgisayar1.oyuncuId);
                }
                else
                {
                    MessageBox.Show("Oyun Tamamlanmıştır. Berabere iki yarışmacıyıda tebrik ediyoruz.");
                }
                Console.WriteLine("Oyun Tamamlanmıştır.");
                Console.WriteLine("Bilgisayar 1 Skor : " + _bilgisayar1.skor + "  Bilgisayar 2 Skor : " + _bilgisayar2.skor);
                Console.WriteLine("Bilgisayar 1 Deste Sayisi : " + _bilgisayar1.nesneListesi.Count + "  Bilgisayar 2 Deste Sayisi : " + _bilgisayar2.nesneListesi.Count);
                Application.Exit();
            }


        }


        private void button11_Click(object sender, EventArgs e)
        {
            baslat();

        }

        private void BilgisayarVsBilgisayar_Load(object sender, EventArgs e)
        {

            labelBilgisayar1Id.Text = _bilgisayar1.oyuncuId.ToString();
            labelBilgisayar2Id.Text = _bilgisayar2.oyuncuId.ToString();
            labelBilgisayar1Skor.Text = _bilgisayar1.skor.ToString();
            labelBilgisayar2Skor.Text = _bilgisayar2.skor.ToString();

            buttons.Add(bilgisayar1button1);
            buttons.Add(bilgisayar1button2);
            buttons.Add(bilgisayar1button3);
            buttons.Add(bilgisayar1button4);
            buttons.Add(bilgisayar1button5);

            buttons1.Add(bilgisayar2button1);
            buttons1.Add(bilgisayar2button2);
            buttons1.Add(bilgisayar2button3);
            buttons1.Add(bilgisayar2button4);
            buttons1.Add(bilgisayar2button5);


        }
    }
}
