using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemiBE
{
    public class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public long  TelefonNo { get; set; }
        public string ePosta { get; set; }
        public string  uyruk { get; set; }
        public long TCKimlikNo{ get; set; }
        public string dogumYeri { get; set; }
        public DateTime dogumTarihi { get; set; }
        public string medeniDurum { get; set; }
        public string yabanciDil { get; set; }
        public string ilgiAlanlari { get; set; }
        public string Referans { get; set; }

        
        public double UygunlukDurumu  { get; set; }
        public LinkedList isDeneyimi;
        public LinkedList egitimDurumu;

        public Kisi()
        {

            UygunlukDurumu = UygunlukDurumuAta();
            isDeneyimi = new LinkedList();
            egitimDurumu = new LinkedList();

            
        }
        public void EgitimDurumuAta (EgitimDurumu egitim)
        {
            egitimDurumu.InsertLast(egitim);
        }
        public void IsDeneyimiEkle(isDeneyimi deneyim)
        {
            isDeneyimi.InsertLast(deneyim);
        }

        public double UygunlukDurumuAta()
        {
            Random random = new Random();
            return random.NextDouble() * (10 - 0) + 0;  
        }
    }
}
