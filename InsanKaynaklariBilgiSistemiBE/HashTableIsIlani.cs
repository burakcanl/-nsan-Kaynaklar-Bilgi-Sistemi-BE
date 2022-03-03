using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemiBE
{
    public class HashTableIsIlani
    {

        int TABLE_SIZE = 11;

        HashTableEntry[] table;
        public List<IsIlaniBilgileri> Pozisyonlar = new List<IsIlaniBilgileri>();
        public List<SirketBilgileri> Sirketler = new List<SirketBilgileri>();


        public HashTableIsIlani()
        {
            table = new HashTableEntry[TABLE_SIZE];
            for (int i = 0; i < TABLE_SIZE; i++)
                table[i] = null;
        }
        public void isIlaninaBasvuranEkle(int key, Kisi value)
        {
            int hash = (key % TABLE_SIZE);
            HashTableEntry entry = table[hash];
            while (entry != null)
            {

                if (entry == null)
                    break;
                else if (entry.Anahtar == key)
                    ((SirketBilgileri)entry.Deger).IsIlani.basvuracakElemaniEkle(value);

                entry = entry.Next;


            }
        }




        public object Get(int key)
        {
            int hash = (key % TABLE_SIZE);
            if (table[hash] == null)
                return null;
            else
            {
                HashTableEntry entry = table[hash];
                while (entry != null && entry.Anahtar != key)
                    entry = entry.Next;
                if (entry == null)
                    return null;
                else
                    return entry.Deger;
            }
        }
        public string GetAll()
        {

            string tmp = "";
            for (int i = 0; i < 10; i++)
            {
                if (table[i] != null)
                {
                    HashTableEntry entry = table[i];
                    while (entry != null)
                    {
                        if (entry == null)
                            return null;
                        else
                            tmp += "Sirket Adı:" + ((SirketBilgileri)table[i].Deger).ad + " İlan No:" + Convert.ToString(((SirketBilgileri)table[i].Deger).IsIlani.ilanNo) + " İş Tanımı:" + ((SirketBilgileri)table[i].Deger).IsIlani.isTanimi + " Aranan Ozellik:" + ((SirketBilgileri)table[i].Deger).IsIlani.arananOzellik + Environment.NewLine;

                        entry = entry.Next;
                    }
                }

            }

            return tmp;
        }
        public void Add(int key, object value)
        {
            int hash = (key % TABLE_SIZE);
            if (table[hash] == null)
                table[hash] = new HashTableEntry(key, value);
            else
            {
                HashTableEntry entry = table[hash];
                while (entry.Next != null && entry.Anahtar != key)
                    entry = entry.Next;
                if (entry.Anahtar == key)
                    entry.Deger = value;
                else
                    entry.Next = new HashTableEntry(key, value);
            }
        }

        public void IlaniSil(int key)
        {
            int hash = (key % TABLE_SIZE);
            if (table[hash] != null)
            {
                HashTableEntry prevEntry = null;
                HashTableEntry entry = table[hash];
                while (entry.Next != null && entry.Anahtar != key)
                {
                    prevEntry = entry;
                    entry = entry.Next;
                }
                if (entry.Anahtar == key)
                {
                    if (prevEntry == null)
                        table[hash] = entry.Next;
                    else
                        prevEntry.Next = entry.Next;
                }
            }
        }

    }
}
