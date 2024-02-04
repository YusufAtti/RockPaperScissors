using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace prolab1
{
    partial class Savasalani : Form
    {
        public static int nesneListesiSayisi = 5;
        public static int hamleSayisi;
        public static int sayac = 0;
        Kullanici _kullanici = new Kullanici();
        Bilgisayar _bilgisayar = new Bilgisayar();
        List<Button> buttons = new List<Button>();
        List<Label> labels = new List<Label>();
        List<int> kullanicininSectigi = new List<int>();
        private nesne bilgisayarinSectigi;
        


        public Savasalani(Kullanici kullanici , Bilgisayar bilgisayar)
        {
            _bilgisayar = bilgisayar;
            _kullanici = kullanici;
            InitializeComponent();
        }

        

        private void kartlariEkranaYansit()
        {
            deste1Ad.Text = _kullanici.nesneListesi[0].nesneAdi;
            deste1Dayaniklik.Text = _kullanici.nesneListesi[0].dayaniklik.ToString();
            deste1SeviyePuani.Text = _kullanici.nesneListesi[0].seviyePuani.ToString();

            deste2Ad.Text = _kullanici.nesneListesi[1].nesneAdi;
            deste2Dayaniklik.Text = _kullanici.nesneListesi[1].dayaniklik.ToString();
            deste2SeviyePuani.Text = _kullanici.nesneListesi[1].seviyePuani.ToString();

            deste3Ad.Text = _kullanici.nesneListesi[2].nesneAdi;
            deste3Dayaniklik.Text = _kullanici.nesneListesi[2].dayaniklik.ToString();
            deste3SeviyePuani.Text = _kullanici.nesneListesi[2].seviyePuani.ToString();

            deste4Ad.Text = _kullanici.nesneListesi[3].nesneAdi;
            deste4Dayaniklik.Text = _kullanici.nesneListesi[3].dayaniklik.ToString();
            deste4SeviyePuani.Text = _kullanici.nesneListesi[3].seviyePuani.ToString();

            deste5Ad.Text = _kullanici.nesneListesi[4].nesneAdi;
            deste5Dayaniklik.Text = _kullanici.nesneListesi[4].dayaniklik.ToString();
            deste5SeviyePuani.Text = _kullanici.nesneListesi[4].seviyePuani.ToString();
        }

        private void bilgisayarEkranaYansit()
        {
            int nesneElamanSayisi = _bilgisayar.nesneListesi.Count;
            for(int i = 0; i < nesneElamanSayisi; i++)
            {
                if (_bilgisayar.nesneListesi[i].dayaniklik <= 0)
                {
                    buttons[i].Text = "I am dead";
                    buttons[i].Enabled = false;

                    Console.WriteLine("Kart : " + (i + 1) + " " + _bilgisayar.nesneListesi[i].dayaniklik);
                    _bilgisayar.nesneListesi.Remove(_bilgisayar.nesneListesi[i]);
                    buttons.RemoveAt(i);
                    Console.WriteLine("Nesne Listesi : ");

                    foreach (var item in _bilgisayar.nesneListesi)
                    {
                        Console.WriteLine(item);
                    }

                    _bilgisayar.secilenSayilar.Remove(i);
                    nesneElamanSayisi--;
                }
            }
                   
        }

        



        private void Savasalani_Load(object sender, EventArgs e)
        {
            kullaniciAdi.Text = _kullanici.oyuncuAdi;
            kullaniciSkor.Text = _kullanici.skor.ToString();
            bilgisayarSkor.Text = _bilgisayar.skor.ToString();
            bilgisayarID.Text = _bilgisayar.oyuncuId.ToString();
            buttons.Add(pcDeste1);
            buttons.Add(pcDeste2);
            buttons.Add(pcDeste3);
            buttons.Add(pcDeste4);
            buttons.Add(pcDeste5);
            kartlariEkranaYansit();
        }

        
        private void deste1_Click(object sender, EventArgs e)
        {
            //Oyun hamlesi için sayac arttırılıyor
            sayac++;

            //Paremetre olarak gönderilecek labeller ekleniyor.
            labels.Add(deste1Ad);
            labels.Add(deste1Dayaniklik);
            labels.Add(deste1SeviyePuani);


            //Bilgisayara Rastgele bir kart seçtiriyoruz ve ekrana yansıtıyoruz.
            bilgisayarinSectigi = _bilgisayar.nesneSec();

            //Bilgisayarın ve Kullanıcının seçtiği kartları ortaya yansitiyoruz.
            bilgisayarinKarti.Text = bilgisayarinSectigi.nesneAdi;
            secilenKart.Text = _kullanici.nesneListesi[0].nesneAdi;


            //Etki Hesaplama
            double kullaniciEtkisi = _kullanici.nesneListesi[0].etkiPuaniHesapla(bilgisayarinSectigi);
            double bilgisayarinEtkisi = bilgisayarinSectigi.etkiPuaniHesapla(_kullanici.nesneListesi[0]);
            Console.WriteLine("Kullanici Etkisi : " + kullaniciEtkisi + "  Nesne Dayanikligi : " + _kullanici.nesneListesi[0].dayaniklik);
            Console.WriteLine("Bilgisayar Etkisi : " + bilgisayarinEtkisi + "  Nesne Dayanikligi : " + bilgisayarinSectigi.dayaniklik);


            //Puanlari Guncelleme
            if(kullaniciEtkisi < bilgisayarinEtkisi)
            {
                _kullanici.nesneListesi[0].durumGuncelle(bilgisayarinEtkisi , false);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi , true);
                _bilgisayar.skor++;
            }
            else if (kullaniciEtkisi > bilgisayarinEtkisi)
            {
                _kullanici.nesneListesi[0].durumGuncelle(bilgisayarinEtkisi, true);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, false);
                _kullanici.skor++;
            }
            else
            {
                _kullanici.nesneListesi[0].durumGuncelle(bilgisayarinEtkisi, false);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, false);
            }

            Console.WriteLine("Nesne Dayanikligi : " + _kullanici.nesneListesi[0].dayaniklik);
            Console.WriteLine("Nesne Dayanikligi : " + bilgisayarinSectigi.dayaniklik);

            if (_kullanici.nesneListesi[0].seviyePuani >= 30)
            {
                if(nesne.Equals(_kullanici.nesneListesi[0].GetType(), new Tas().GetType()))
                {
                    _kullanici.nesneListesi[0] = new AgirTas(20 , (int)_kullanici.nesneListesi[0].seviyePuani , 2);
                }
                else if (nesne.Equals(_kullanici.nesneListesi[0].GetType(), new Makas().GetType()))
                {
                    _kullanici.nesneListesi[0] = new ustaMakas(20, (int)_kullanici.nesneListesi[0].seviyePuani, 2);
                }
                else if (nesne.Equals(_kullanici.nesneListesi[0].GetType(), new Kagit().GetType()))
                {
                    _kullanici.nesneListesi[0] = new ozelKagit(20, (int)_kullanici.nesneListesi[0].seviyePuani, 2);
                }
            }
            else if(bilgisayarinSectigi.seviyePuani >= 30)
            {
                int index = _bilgisayar.nesneListesi.FindIndex(a => a == bilgisayarinSectigi);
                if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Tas().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new AgirTas(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                }
                else if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Makas().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new ustaMakas(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                }
                else if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Kagit().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new ozelKagit(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                }

            }




            //Puanlar ekrana yansitiliyor.
            _kullanici.nesneListesi[0].nesnePuaniGoster(labels , deste1);
            bilgisayarEkranaYansit();

            //Kullanıcın seçtiği indexi  ekliyoruz.
            kullanicininSectigi.Add(0);

            //Butonları kapatmak için seçilip seçilmediğini kontrol ediyoruz.
            foreach (var item in kullanicininSectigi)
            {
                if (item == 0)
                {
                    deste1.Enabled = false;
                    break;
                }
            }

            //Destedeki tüm kartlar seçildiğinde dayanikliği > 0 olan butonları açıyoruz. ve Seçilen kartlar arrayini temizliyoruz.
            if (kullanicininSectigi.Count == nesneListesiSayisi)
            {
                if (_kullanici.nesneListesi[0].dayaniklik > 0)
                    deste1.Enabled = true;
                if (_kullanici.nesneListesi[1].dayaniklik > 0)
                    deste2.Enabled = true;
                if (_kullanici.nesneListesi[2].dayaniklik > 0)
                    deste3.Enabled = true;
                if (_kullanici.nesneListesi[3].dayaniklik > 0)
                    deste4.Enabled = true;
                if (_kullanici.nesneListesi[4].dayaniklik > 0)
                    deste5.Enabled = true;
                kullanicininSectigi.Clear();
            }

            //Ölen kartları seçilenlerden siliyoruz.
            if (_kullanici.nesneListesi[0].dayaniklik <= 0)
            {
                nesneListesiSayisi--;
                kullanicininSectigi.Remove(0);
            }

            //Temizleme ve yansitma işlemleri
            labels.Clear();
            kullaniciSkor.Text = _kullanici.skor.ToString();
            bilgisayarSkor.Text = _bilgisayar.skor.ToString();

            //Sayac ve oyun sonu kontrolleri
            if (sayac == hamleSayisi)
            {
                if(_kullanici.skor > _bilgisayar.skor)
                    MessageBox.Show("Tebrikler Kazandin" + _kullanici.oyuncuAdi);
                else if(_bilgisayar.skor > _kullanici.skor)
                    MessageBox.Show("Tebrikler Bilgisayar");
                else
                    MessageBox.Show("Berabere");
                Application.Exit();
            }

            if (_bilgisayar.nesneListesi.Count == 0)
            {
                MessageBox.Show("Oyun bitti Tebrik Ediyorum brom " + _kullanici.oyuncuAdi);
                Application.Exit();
            }
            else if (deste1.Enabled == false && deste2.Enabled == false && deste3.Enabled == false && deste4.Enabled == false && deste5.Enabled == false)
            {
                MessageBox.Show("Oyun bitti Bilgisayar Kazandı");
                Application.Exit();
            }

        }

        private void deste2_Click(object sender, EventArgs e)
        {
            
            sayac++;

            //Paremetre olarak gönderilecek labeller hazırlanıyor.
            labels.Add(deste2Ad);
            labels.Add(deste2Dayaniklik);
            labels.Add(deste2SeviyePuani);

            //Bilgisayar öne süreceği kartı seçiyor
            bilgisayarinSectigi = _bilgisayar.nesneSec();


            //Ekranda gösterme
            bilgisayarinKarti.Text = bilgisayarinSectigi.nesneAdi;
            secilenKart.Text = _kullanici.nesneListesi[1].nesneAdi;



            //Etkiler hesaplanıypor.
            double kullaniciEtkisi = _kullanici.nesneListesi[1].etkiPuaniHesapla(bilgisayarinSectigi);
            double bilgisayarinEtkisi = bilgisayarinSectigi.etkiPuaniHesapla(_kullanici.nesneListesi[1]);
            Console.WriteLine("Kullanici Etkisi : " + kullaniciEtkisi);
            Console.WriteLine("Bilgisayar Etkisi : " + bilgisayarinEtkisi);


            //Puanlari Guncelleme
            if (kullaniciEtkisi < bilgisayarinEtkisi)
            {
                _kullanici.nesneListesi[1].durumGuncelle(bilgisayarinEtkisi, false);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, true);
                _bilgisayar.skor++;
            }
            else if (kullaniciEtkisi > bilgisayarinEtkisi)
            {
                _kullanici.nesneListesi[1].durumGuncelle(bilgisayarinEtkisi, true);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, false);
                _kullanici.skor++;
            }
            else
            {
                _kullanici.nesneListesi[1].durumGuncelle(bilgisayarinEtkisi, false);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, false);
            }

            if (_kullanici.nesneListesi[1].seviyePuani >= 30)
            {
                if (nesne.Equals(_kullanici.nesneListesi[1].GetType(), new Tas().GetType()))
                {
                    _kullanici.nesneListesi[1] = new AgirTas(20, (int)_kullanici.nesneListesi[1].seviyePuani, 2);
                }
                else if (nesne.Equals(_kullanici.nesneListesi[1].GetType(), new Makas().GetType()))
                {
                    _kullanici.nesneListesi[1] = new ustaMakas(20, (int)_kullanici.nesneListesi[1].seviyePuani, 2);
                }
                else if (nesne.Equals(_kullanici.nesneListesi[1].GetType(), new Kagit().GetType()))
                {
                    _kullanici.nesneListesi[1] = new ozelKagit(20, (int)_kullanici.nesneListesi[1].seviyePuani, 2);
                }
            }
            else if (bilgisayarinSectigi.seviyePuani >= 30)
            {
                int index = _bilgisayar.nesneListesi.FindIndex(a => a == bilgisayarinSectigi);
                if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Tas().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new AgirTas(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    Console.WriteLine("Seviye Atladi agirtas");
                }
                else if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Makas().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new ustaMakas(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    Console.WriteLine("Seviye Atladi usta Makas");

                }
                else if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Kagit().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new ozelKagit(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    Console.WriteLine("Seviye Atladi ozelkagit");
                }
            }


           

            //Puanlar gösteriliyor.
            _kullanici.nesneListesi[1].nesnePuaniGoster(labels , deste2);
            bilgisayarEkranaYansit();


            //Label listesi temizleniyor.
            kullanicininSectigi.Add(1);

            foreach (var item in kullanicininSectigi)
            {
                if (item == 1)
                {
                    deste2.Enabled = false;
                    break;
                }
            }

            


            if (kullanicininSectigi.Count == nesneListesiSayisi)
            {
                if (_kullanici.nesneListesi[0].dayaniklik > 0)
                    deste1.Enabled = true;
                if (_kullanici.nesneListesi[1].dayaniklik > 0)
                    deste2.Enabled = true;
                if (_kullanici.nesneListesi[2].dayaniklik > 0)
                    deste3.Enabled = true;
                if (_kullanici.nesneListesi[3].dayaniklik > 0)
                    deste4.Enabled = true;
                if (_kullanici.nesneListesi[4].dayaniklik > 0)
                    deste5.Enabled = true;

                kullanicininSectigi.Clear();
            }

            if (_kullanici.nesneListesi[1].dayaniklik <= 0)
            {
                nesneListesiSayisi--;
                kullanicininSectigi.Remove(1);
            }
           



            kullaniciSkor.Text = _kullanici.skor.ToString();
            bilgisayarSkor.Text = _bilgisayar.skor.ToString();
            labels.Clear();

            if (sayac == hamleSayisi)
            {
                if (_kullanici.skor > _bilgisayar.skor)
                    MessageBox.Show("Tebrikler Kazandin" + _kullanici.oyuncuAdi);
                else if (_bilgisayar.skor > _kullanici.skor)
                    MessageBox.Show("Tebrikler Bilgisayar");
                else
                    MessageBox.Show("Berabere");
                Application.Exit();
            }
            if (_bilgisayar.nesneListesi.Count == 0)
            {
                MessageBox.Show("Oyun bitti Tebrik Ediyorum brom " + _kullanici.oyuncuAdi);
                Application.Exit();
            }
            else if (deste1.Enabled == false && deste2.Enabled == false && deste3.Enabled == false && deste4.Enabled == false && deste5.Enabled == false)
            {
                MessageBox.Show("Oyun bitti Bilgisayar Kazandı");
                Application.Exit();
            }

        }

        private void deste3_Click(object sender, EventArgs e)
        {
            
            sayac++;

            //Paremetre olarak gönderilecek labeller ekleniyor.
            labels.Add(deste3Ad);
            labels.Add(deste3Dayaniklik);
            labels.Add(deste3SeviyePuani);


            //Seçilen kart bilgileri ekranın ortasına yansıtılıyor.
            bilgisayarinSectigi = _bilgisayar.nesneSec();
            bilgisayarinKarti.Text = bilgisayarinSectigi.nesneAdi;
            secilenKart.Text = _kullanici.nesneListesi[2].nesneAdi;

            //Etkiler hesaplanıyor
            double kullaniciEtkisi = _kullanici.nesneListesi[2].etkiPuaniHesapla(bilgisayarinSectigi);
            double bilgisayarinEtkisi = bilgisayarinSectigi.etkiPuaniHesapla(_kullanici.nesneListesi[2]);
            Console.WriteLine("Kullanici Etkisi : " + kullaniciEtkisi);
            Console.WriteLine("Bilgisayar Etkisi : " + bilgisayarinEtkisi);


            //Puanlari Guncelleme
            if (kullaniciEtkisi < bilgisayarinEtkisi)
            {
                _kullanici.nesneListesi[2].durumGuncelle(bilgisayarinEtkisi, false);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, true);
                _bilgisayar.skor++;
            }
            else if (kullaniciEtkisi > bilgisayarinEtkisi)
            {
                _kullanici.nesneListesi[2].durumGuncelle(bilgisayarinEtkisi, true);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, false);
                _kullanici.skor++;
            }
            else
            {
                _kullanici.nesneListesi[2].durumGuncelle(bilgisayarinEtkisi, false);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, false);
            }


            if (_kullanici.nesneListesi[2].seviyePuani >= 30)
            {
                if (nesne.Equals(_kullanici.nesneListesi[2].GetType(), new Tas().GetType()))
                {
                    _kullanici.nesneListesi[2] = new AgirTas(20, (int)_kullanici.nesneListesi[2].seviyePuani, 2);
                }
                else if (nesne.Equals(_kullanici.nesneListesi[2].GetType(), new Makas().GetType()))
                {
                    _kullanici.nesneListesi[2] = new ustaMakas(20, (int)_kullanici.nesneListesi[2].seviyePuani, 2);
                }
                else if (nesne.Equals(_kullanici.nesneListesi[2].GetType(), new Kagit().GetType()))
                {
                    _kullanici.nesneListesi[2] = new ozelKagit(20, (int)_kullanici.nesneListesi[2].seviyePuani, 2);
                }
            }
            else if (bilgisayarinSectigi.seviyePuani >= 30)
            {
                int index = _bilgisayar.nesneListesi.FindIndex(a => a == bilgisayarinSectigi);
                if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Tas().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new AgirTas(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    Console.WriteLine("Seviye Atladi agirtas");
                }
                else if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Makas().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new ustaMakas(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    Console.WriteLine("Seviye Atladi usta Makas");

                }
                else if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Kagit().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new ozelKagit(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    Console.WriteLine("Seviye Atladi ozelkagit");
                }
            }


            
            //Puanlar gösteriliyor.
            _kullanici.nesneListesi[2].nesnePuaniGoster(labels , deste3);
            bilgisayarEkranaYansit();

            //Label listesi temizleniyor
            kullanicininSectigi.Add(2);

            foreach (var item in kullanicininSectigi)
            {
                if (item == 2)
                {
                    deste3.Enabled = false;
                    break;
                }
            }


            if (kullanicininSectigi.Count == nesneListesiSayisi)
            {
                if (_kullanici.nesneListesi[0].dayaniklik > 0)
                    deste1.Enabled = true;
                if (_kullanici.nesneListesi[1].dayaniklik > 0)
                    deste2.Enabled = true;
                if (_kullanici.nesneListesi[2].dayaniklik > 0)
                    deste3.Enabled = true;
                if (_kullanici.nesneListesi[3].dayaniklik > 0)
                    deste4.Enabled = true;
                if (_kullanici.nesneListesi[4].dayaniklik > 0)
                    deste5.Enabled = true;

                kullanicininSectigi.Clear();
            }

            if (_kullanici.nesneListesi[2].dayaniklik <= 0)
            {
                nesneListesiSayisi--;
                kullanicininSectigi.Remove(2);
            }
           
            kullaniciSkor.Text = _kullanici.skor.ToString();
            bilgisayarSkor.Text = _bilgisayar.skor.ToString();

            labels.Clear();
            if (sayac == hamleSayisi)
            {
                if (_kullanici.skor > _bilgisayar.skor)
                    MessageBox.Show("Tebrikler Kazandin" + _kullanici.oyuncuAdi);
                else if (_bilgisayar.skor > _kullanici.skor)
                    MessageBox.Show("Tebrikler Bilgisayar");
                else
                    MessageBox.Show("Berabere");
                Application.Exit();
            }

            if (_bilgisayar.nesneListesi.Count == 0)
            {
                MessageBox.Show("Oyun bitti Tebrik Ediyorum brom " + _kullanici.oyuncuAdi);
                Application.Exit();
            }
            else if (deste1.Enabled == false && deste2.Enabled == false && deste3.Enabled == false && deste4.Enabled == false && deste5.Enabled == false)
            {
                MessageBox.Show("Oyun bitti Bilgisayar Kazandı");
                Application.Exit();
            }

        }

        private void deste4_Click(object sender, EventArgs e)
        {
            
            sayac++;


            //Paremetre olarak gönderilecek labeller ekleniyor.
            labels.Add(deste4Ad);
            labels.Add(deste4Dayaniklik);
            labels.Add(deste4SeviyePuani);

            //Secilen kartlar savaş alanının ortasına yansılıyor.
            bilgisayarinSectigi = _bilgisayar.nesneSec();
            bilgisayarinKarti.Text = bilgisayarinSectigi.nesneAdi;
            secilenKart.Text = _kullanici.nesneListesi[3].nesneAdi;


            //Etkiler hesaplanıyor
            double kullaniciEtkisi = _kullanici.nesneListesi[3].etkiPuaniHesapla(bilgisayarinSectigi);
            double bilgisayarinEtkisi = bilgisayarinSectigi.etkiPuaniHesapla(_kullanici.nesneListesi[3]);
            Console.WriteLine("Kullanici Etkisi : " + kullaniciEtkisi);
            Console.WriteLine("Bilgisayar Etkisi : " + bilgisayarinEtkisi);


            //Puanlari Guncelleme
            if (kullaniciEtkisi < bilgisayarinEtkisi)
            {
                _kullanici.nesneListesi[3].durumGuncelle(bilgisayarinEtkisi, false);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, true);
                _bilgisayar.skor++;
            }
            else if (kullaniciEtkisi > bilgisayarinEtkisi)
            {
                _kullanici.nesneListesi[3].durumGuncelle(bilgisayarinEtkisi, true);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, false);
                _kullanici.skor++;
            }
            else
            {
                _kullanici.nesneListesi[3].durumGuncelle(bilgisayarinEtkisi, false);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, false);
            }


            if (_kullanici.nesneListesi[3].seviyePuani >= 30)
            {
                if (nesne.Equals(_kullanici.nesneListesi[3].GetType(), new Tas().GetType()))
                {
                    _kullanici.nesneListesi[3] = new AgirTas(20, (int)_kullanici.nesneListesi[3].seviyePuani, 2);
                }
                else if (nesne.Equals(_kullanici.nesneListesi[3].GetType(), new Makas().GetType()))
                {
                    _kullanici.nesneListesi[3] = new ustaMakas(20, (int)_kullanici.nesneListesi[3].seviyePuani, 2);
                }
                else if (nesne.Equals(_kullanici.nesneListesi[3].GetType(), new Kagit().GetType()))
                {
                    _kullanici.nesneListesi[3] = new ozelKagit(20, (int)_kullanici.nesneListesi[3].seviyePuani, 2);
                }
            }
            else if (bilgisayarinSectigi.seviyePuani >= 30)
            {
                int index = _bilgisayar.nesneListesi.FindIndex(a => a == bilgisayarinSectigi);
                if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Tas().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new AgirTas(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    Console.WriteLine("Seviye Atladi agirtas");
                }
                else if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Makas().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new ustaMakas(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    Console.WriteLine("Seviye Atladi usta Makas");

                }
                else if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Kagit().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new ozelKagit(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    Console.WriteLine("Seviye Atladi ozelkagit");
                }
            }



            //kartlariEkranaYansit();
            _kullanici.nesneListesi[3].nesnePuaniGoster(labels , deste4);
            bilgisayarEkranaYansit();



            //label listesi temizleniyor.
            kullanicininSectigi.Add(3);

            foreach (var item in kullanicininSectigi)
            {
                if (item == 3)
                {
                    deste4.Enabled = false;
                    break;
                }
            }

            

            if (kullanicininSectigi.Count == nesneListesiSayisi)
            {
                if (_kullanici.nesneListesi[0].dayaniklik > 0)
                    deste1.Enabled = true;
                if (_kullanici.nesneListesi[1].dayaniklik > 0)
                    deste2.Enabled = true;
                if (_kullanici.nesneListesi[2].dayaniklik > 0)
                    deste3.Enabled = true;
                if (_kullanici.nesneListesi[3].dayaniklik > 0)
                    deste4.Enabled = true;
                if (_kullanici.nesneListesi[4].dayaniklik > 0)
                    deste5.Enabled = true;

                kullanicininSectigi.Clear();
                
            }

            if (_kullanici.nesneListesi[3].dayaniklik <= 0)
            {
                nesneListesiSayisi--;
                kullanicininSectigi.Remove(3);
            }


            kullaniciSkor.Text = _kullanici.skor.ToString();
            bilgisayarSkor.Text = _bilgisayar.skor.ToString();

            labels.Clear();
            if (sayac == hamleSayisi)
            {
                if (_kullanici.skor > _bilgisayar.skor)
                    MessageBox.Show("Tebrikler Kazandin" + _kullanici.oyuncuAdi);
                else if (_bilgisayar.skor > _kullanici.skor)
                    MessageBox.Show("Tebrikler Bilgisayar");
                else
                    MessageBox.Show("Berabere");
                Application.Exit();
            }

            if (_bilgisayar.nesneListesi.Count == 0)
            {
                MessageBox.Show("Oyun bitti Tebrik Ediyorum brom " + _kullanici.oyuncuAdi);
                Application.Exit();
            }
            else if (deste1.Enabled == false && deste2.Enabled == false && deste3.Enabled == false && deste4.Enabled == false && deste5.Enabled == false)
            {
                MessageBox.Show("Oyun bitti Bilgisayar Kazandı");
                Application.Exit();
            }

        }

        private void deste5_Click(object sender, EventArgs e)
        {
            

            sayac++;


            //Değiştirilmek üzere gönderilecek olan labeller ekleniyor.
            labels.Add(deste5Ad);
            labels.Add(deste5Dayaniklik);
            labels.Add(deste5SeviyePuani);


            //Secilen Kartlar Savaş Alanının ortasına yansıtılıyor
            bilgisayarinSectigi = _bilgisayar.nesneSec();
            bilgisayarinKarti.Text = bilgisayarinSectigi.nesneAdi;
            secilenKart.Text = _kullanici.nesneListesi[4].nesneAdi;


            //Etkiler Hesaplaniyor
            double kullaniciEtkisi = _kullanici.nesneListesi[4].etkiPuaniHesapla(bilgisayarinSectigi);
            double bilgisayarinEtkisi = bilgisayarinSectigi.etkiPuaniHesapla(_kullanici.nesneListesi[4]);
            Console.WriteLine("Kullanici Etkisi : " + kullaniciEtkisi);
            Console.WriteLine("Bilgisayar Etkisi : " + bilgisayarinEtkisi);



            //Puanlari Guncelleme
            if (kullaniciEtkisi < bilgisayarinEtkisi)
            {
                _kullanici.nesneListesi[4].durumGuncelle(bilgisayarinEtkisi, false);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, true);
                _bilgisayar.skor++;
            }
            else if(kullaniciEtkisi >  bilgisayarinEtkisi)
            {
                _kullanici.nesneListesi[4].durumGuncelle(bilgisayarinEtkisi, true);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, false);
                _kullanici.skor++;
            }
            else
            {
                _kullanici.nesneListesi[4].durumGuncelle(bilgisayarinEtkisi, false);
                bilgisayarinSectigi.durumGuncelle(kullaniciEtkisi, false);
            }

            //Level atlatma
            if (_kullanici.nesneListesi[4].seviyePuani >= 30)
            {
                if (nesne.Equals(_kullanici.nesneListesi[4].GetType(), new Tas().GetType()))
                {
                    //_kullanici.nesneListesi.Insert(0, new AgirTas(20, (int)_kullanici.nesneListesi[0].seviyePuani , 2));
                    _kullanici.nesneListesi[4] = new AgirTas(20, (int)_kullanici.nesneListesi[4].seviyePuani, 2);
                }
                else if (nesne.Equals(_kullanici.nesneListesi[4].GetType(), new Makas().GetType()))
                {
                    _kullanici.nesneListesi[4] = new ustaMakas(20, (int)_kullanici.nesneListesi[4].seviyePuani, 2);
                    //_kullanici.nesneListesi.Insert(0, new ustaMakas(20, (int)_kullanici.nesneListesi[0].seviyePuani, 2));
                }
                else if (nesne.Equals(_kullanici.nesneListesi[4].GetType(), new Kagit().GetType()))
                {
                    _kullanici.nesneListesi[4] = new ozelKagit(20, (int)_kullanici.nesneListesi[4].seviyePuani, 2);
                    //_kullanici.nesneListesi.Insert(0, new ozelKagit(20, (int)_kullanici.nesneListesi[0].seviyePuani, 2));
                }
            }
            else if (bilgisayarinSectigi.seviyePuani >= 30)
            {
                int index = _bilgisayar.nesneListesi.FindIndex(a => a == bilgisayarinSectigi);
                if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Tas().GetType()))
                {
                    //_kullanici.nesneListesi.Insert(0, new AgirTas(20, (int)_kullanici.nesneListesi[0].seviyePuani , 2));
                    _bilgisayar.nesneListesi[index] = new AgirTas(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    Console.WriteLine("Seviye Atladi agirtas");
                }
                else if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Makas().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new ustaMakas(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    //_kullanici.nesneListesi.Insert(0, new ustaMakas(20, (int)_kullanici.nesneListesi[0].seviyePuani, 2));
                    Console.WriteLine("Seviye Atladi usta Makas");

                }
                else if (nesne.Equals(_bilgisayar.nesneListesi[index].GetType(), new Kagit().GetType()))
                {
                    _bilgisayar.nesneListesi[index] = new ozelKagit(20, (int)_bilgisayar.nesneListesi[index].seviyePuani, 2);
                    //_kullanici.nesneListesi.Insert(0, new ozelKagit(20, (int)_kullanici.nesneListesi[0].seviyePuani, 2));
                    Console.WriteLine("Seviye Atladi ozelkagit");
                }
            }



            //Ekrandaki Kartları güncelliyoruz.
            _kullanici.nesneListesi[4].nesnePuaniGoster(labels , deste5);
            bilgisayarEkranaYansit();



            //Label listesi temizleniyor.
            kullanicininSectigi.Add(4);

            foreach (var item in kullanicininSectigi)
            {
                if (item == 4)
                {
                    deste5.Enabled = false;
                    break;
                }
            }

            


            if (kullanicininSectigi.Count == nesneListesiSayisi)
            {
                if (_kullanici.nesneListesi[0].dayaniklik > 0)
                    deste1.Enabled = true;
                if (_kullanici.nesneListesi[1].dayaniklik > 0)
                    deste2.Enabled = true;
                if (_kullanici.nesneListesi[2].dayaniklik > 0)
                    deste3.Enabled = true;
                if (_kullanici.nesneListesi[3].dayaniklik > 0)
                    deste4.Enabled = true;
                if (_kullanici.nesneListesi[4].dayaniklik > 0)
                    deste5.Enabled = true;
                kullanicininSectigi.Clear();
            }

            if (_kullanici.nesneListesi[4].dayaniklik <= 0)
            {
                nesneListesiSayisi--;
                kullanicininSectigi.Remove(4);
            }


            bilgisayarSkor.Text = _bilgisayar.skor.ToString();
            kullaniciSkor.Text = _kullanici.skor.ToString();
            labels.Clear();

            if (sayac == hamleSayisi)
            {
                if (_kullanici.skor > _bilgisayar.skor)
                    MessageBox.Show("Tebrikler Kazandin" + _kullanici.oyuncuAdi);
                else if (_bilgisayar.skor > _kullanici.skor)
                    MessageBox.Show("Tebrikler Bilgisayar");
                else
                    MessageBox.Show("Berabere");
                Application.Exit();
            }

            if (_bilgisayar.nesneListesi.Count == 0)
            {
                MessageBox.Show("Oyun bitti Tebrik Ediyorum brom " + _kullanici.oyuncuAdi);
                Application.Exit();
            }
            else if (deste1.Enabled == false && deste2.Enabled == false && deste3.Enabled == false && deste4.Enabled == false && deste5.Enabled == false)
            {
                MessageBox.Show("Oyun bitti Bilgisayar Kazandı");
                Application.Exit();
            }

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
