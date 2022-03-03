using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemiBE
{
    public class HashTableIsyeri
    {
        int TABLE_SIZE = 11;

        HashTableEntry[] table;
        
        public HashTableEntry[] Rturn()
        {
            return table;
        }

       
        public HashTableIsyeri()
        {
            table = new HashTableEntry[TABLE_SIZE];
            for (int i = 0; i < TABLE_SIZE; i++)
                table[i] = null;
        }

        public void Update(int key, SirketBilgileri sirket)
        {
            int hash = (key % TABLE_SIZE);
            HashTableEntry entry = table[hash];
            while (entry != null && entry.Anahtar != key)
            {
                entry = entry.Next;

            }
           ((SirketBilgileri)entry.Deger).ad = sirket.ad;
            ((SirketBilgileri)entry.Deger).adres = sirket.adres;
            ((SirketBilgileri)entry.Deger).ePosta = sirket.ePosta;
            ((SirketBilgileri)entry.Deger).fax = sirket.fax;
            ((SirketBilgileri)entry.Deger).telefon = sirket.telefon;



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

        public void RemoveSirket(int key)
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
