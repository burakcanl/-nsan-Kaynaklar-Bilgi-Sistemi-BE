using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemiBE
{
    public class SirketBilgileri
    {
        public string ad { get; set; }
        public string adres { get; set; }
        public long telefon { get; set; }
        public long  fax { get; set; }
        public string ePosta { get; set; }
        public int sirketNo { get; set; }
        public IsIlaniBilgileri IsIlani;

        public void IsIlaniOlustur(IsIlaniBilgileri job)
        {
            Form1.HashTableIsIlani.Add(job.ilanNo, this);
        }
        public SirketBilgileri()
        {
            Random random = new Random();
            sirketNo = random.Next();

        }

    }
}
