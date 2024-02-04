using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace prolab1
{
    abstract class nesne
    {

        public double dayaniklik;
        public double seviyePuani;
        public String nesneAdi;

        public nesne()
        {

        }

        public nesne(int dayaniklik , int seviyePuani)
        {

        }

        public abstract void nesnePuaniGoster(List<Label> labels , Button btn );

        public abstract double etkiPuaniHesapla(nesne r1);

        public abstract void durumGuncelle(double etki , Boolean yendiMi);



    }
}
