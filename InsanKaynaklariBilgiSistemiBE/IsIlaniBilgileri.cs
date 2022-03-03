using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemiBE
{
    public class IsIlaniBilgileri
    {
        public int ilanNo { get; set; }
        public string isTanimi { get; set; }

        public string arananOzellik   { get; set; }
        public HeapAgaci basvuracakEleman { get; set; }
        public  string   Pozisyon { get; set; }

        Random random = new Random();
        
        public void basvuracakElemaniEkle(Kisi eleman)
        {
            basvuracakEleman.Insert(eleman); 
        }
        public IsIlaniBilgileri()
        {
            basvuracakEleman = new HeapAgaci(20); 
            Random rand = new Random();
            ilanNo = rand.Next();
            

        }


    }
}
