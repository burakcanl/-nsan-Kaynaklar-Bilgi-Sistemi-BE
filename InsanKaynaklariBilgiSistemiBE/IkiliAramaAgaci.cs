using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemiBE
{
    [Serializable()]
    public class IkiliAramaAgaci
    {
       
       
            private IkiliAramaAgaciDugumu kok;
            private string dugumler;
            public IkiliAramaAgaci()
            {
            }
            public IkiliAramaAgaci(IkiliAramaAgaciDugumu kok)
            {
                this.kok = kok;
            }
            public int DugumSayisi()
            {
                return DugumSayisi(kok);
            }
            public List<Kisi> InOrderList = new List<Kisi>();
            public List<Kisi> PreOrderList = new List<Kisi>();
            public List<Kisi> PostOrderList = new List<Kisi>();
            public List<Kisi> YabanciDilBilenler = new List<Kisi>();
            public List<Kisi> EnAzIkiYilDeneyimliler = new List<Kisi>();
            
            public int DugumSayisi(IkiliAramaAgaciDugumu dugum)
            {
                int count = 0;
                if (dugum != null)
                {
                    count = 1;
                    count += DugumSayisi(dugum.sol);
                    count += DugumSayisi(dugum.sag);
                }
                return count;
            }
            public int YaprakSayisi()
            {
                return YaprakSayisi(kok);
            }
            public int YaprakSayisi(IkiliAramaAgaciDugumu dugum)
            {
                int count = 0;
                if (dugum != null)
                {
                    if ((dugum.sol == null) && (dugum.sag == null))
                        count = 1;
                    else
                        count = count + YaprakSayisi(dugum.sol) + YaprakSayisi(dugum.sag);
                }
                return count;
            }
            public string DugumleriYazdir()
            {
                return dugumler;
            }
            public void PreOrder()
            {
                PreOrderList.Clear();
                PreOrderInt(kok);
            }
            private void PreOrderInt(IkiliAramaAgaciDugumu dugum)
            {
                if (dugum == null)
                    return;
                ZiyaretPreOrder(dugum);
                PreOrderInt(dugum.sol);
                PreOrderInt(dugum.sag);
            }
            public void InOrder()
            {
                InOrderList.Clear();
                InOrderInt(kok);
            }
            private void InOrderInt(IkiliAramaAgaciDugumu dugum)
            {
                if (dugum == null)
                    return;
                InOrderInt(dugum.sol);
                ZiyaretInOrder(dugum);
                InOrderInt(dugum.sag);
            }
            private void Ziyaret(IkiliAramaAgaciDugumu dugum)
            {

                dugumler += dugum.veri + " ";
            }
            private void ZiyaretInOrder(IkiliAramaAgaciDugumu dugum)
            {
                InOrderList.Add(dugum.veri);

            }
            private void ZiyaretPreOrder(IkiliAramaAgaciDugumu dugum)
            {
                PreOrderList.Add(dugum.veri);

            }
            private void ZiyaretPostOrder(IkiliAramaAgaciDugumu dugum)
            {
                PostOrderList.Add(dugum.veri);

            }
            public void PostOrder()
            {
                PostOrderList.Clear();
                PostOrderInt(kok);
            }
            private void PostOrderInt(IkiliAramaAgaciDugumu dugum)
            {
                if (dugum == null)
                    return;
                PostOrderInt(dugum.sol);
                PostOrderInt(dugum.sag);
                ZiyaretPostOrder(dugum);
            }
            public void BuyukKucuk()
            {
                dugumler = "";
                BuyukKucukInt(kok);

            }
            private void BuyukKucukInt(IkiliAramaAgaciDugumu dugum)
            {
                if (dugum == null)
                    return;
                BuyukKucukInt(dugum.sag);
                Ziyaret(dugum);
                BuyukKucukInt(dugum.sol);
            }
            public void Ekle(Kisi deger)
            {
                
                IkiliAramaAgaciDugumu tempParent = new IkiliAramaAgaciDugumu();
                
                IkiliAramaAgaciDugumu tempSearch = kok;





                while (tempSearch != null)
                {
                    tempParent = tempSearch;
                    if (deger.TCKimlikNo== tempSearch.veri.TCKimlikNo)
                        return;
                    else if (deger.TCKimlikNo < tempSearch.veri.TCKimlikNo)
                        tempSearch = tempSearch.sol;
                    else
                        tempSearch = tempSearch.sag;
                }
                IkiliAramaAgaciDugumu eklenecek = new IkiliAramaAgaciDugumu(deger);

                if (kok == null)
                    kok = eklenecek;
                else if (deger.TCKimlikNo < tempParent.veri.TCKimlikNo)
                    tempParent.sol = eklenecek;
                else
                    tempParent.sag = eklenecek;


            }
            
            public IkiliAramaAgaciDugumu Ara(string anahtar)
            {
                return AraInt(kok, anahtar);
            }
            private IkiliAramaAgaciDugumu AraInt(IkiliAramaAgaciDugumu dugum, string anahtar)

            {
                if (dugum == null)
                    return null;
                else if (dugum.veri.Ad == anahtar)
                    return dugum;
                else if (string.Compare(dugum.veri.Ad, anahtar) == -1)
                    return (AraInt(dugum.sag, anahtar));
                else
                    return (AraInt(dugum.sol, anahtar));
            }
            public IkiliAramaAgaciDugumu MinDeger()
            {
                IkiliAramaAgaciDugumu tempSol = kok;
                while (tempSol.sol != null)
                    tempSol = tempSol.sol;
                return tempSol;
            }

            public IkiliAramaAgaciDugumu MaksDeger()
            {
                IkiliAramaAgaciDugumu tempSag = kok;
                while (tempSag.sag != null)
                    tempSag = tempSag.sag;
                return tempSag;
            }

            private IkiliAramaAgaciDugumu Successor(IkiliAramaAgaciDugumu silDugum)
            {
                IkiliAramaAgaciDugumu successorParent = silDugum;
                IkiliAramaAgaciDugumu successor = silDugum;
                IkiliAramaAgaciDugumu current = silDugum.sag;
                while (current != null)
                {
                    successorParent = successor;
                    successor = current;
                    current = current.sol;
                }
                if (successor != silDugum.sag)
                {
                    successorParent.sol = successor.sag;
                    successor.sag = silDugum.sag;
                }
                return successor;
            }
            public bool Sil(string deger)
            {
                IkiliAramaAgaciDugumu current = kok;
                IkiliAramaAgaciDugumu parent = kok;
                bool issol = true;
                
                while (current.veri.Ad.CompareTo(deger) != 0)
                {
                    parent = current;
                    if (string.Compare(deger, current.veri.Ad) == -1)
                    {
                        issol = true;
                        current = current.sol;
                    }
                    else if (string.Compare(deger, current.veri.Ad) == 1)
                    {
                        issol = false;
                        current = current.sag;
                    }

                    if (current == null)
                        return false;


                }


                //DURUM 1: YAPRAK DÜĞÜM
                if (current.sol == null && current.sag == null)
                {
                    if (current == kok)
                        kok = null;
                    else if (issol)
                        parent.sol = null;
                    else
                        parent.sag = null;
                }
                //DURUM 2: TEK ÇOCUKLU DÜĞÜM
                else if (current.sag == null)
                {
                    if (current == kok)
                        kok = current.sol;
                    else if (issol)
                        parent.sol = current.sol;
                    else
                        parent.sag = current.sol;
                }
                else if (current.sol == null)
                {
                    if (current == kok)
                        kok = current.sag;
                    else if (issol)
                        parent.sol = current.sag;
                    else
                        parent.sag = current.sag;
                }
                //DURUM 3: İKİ ÇOCUKLU DÜĞÜM
                else
                {
                    IkiliAramaAgaciDugumu successor = Successor(current);
                    if (current == kok)
                        kok = successor;
                    else if (issol)
                        parent.sol = successor;
                    else
                        parent.sag = successor;
                    successor.sol = current.sol;
                }
                return true;
            }
        private int DerinlikBulInt(IkiliAramaAgaciDugumu dugum)
        {
            if (dugum == null)
                return 0;
            else
            {
                int solYukseklik = 0, sagYukseklik = 0;
                solYukseklik = DerinlikBulInt(dugum.sol); 
                sagYukseklik = DerinlikBulInt(dugum.sag); 
                if (solYukseklik > sagYukseklik)
                    return solYukseklik + 1;
                else
                    return sagYukseklik + 1;
            }
        }

        public int DerinlikBul()
        {
            return DerinlikBulInt(kok);
        }

        public int ElemanSayisi()
        {
            return ElamanSayisiInt(kok);
        }
        private int ElamanSayisiInt(IkiliAramaAgaciDugumu dugum)
        {
            int elemanSayisi = 0;
            if (dugum != null)
            {
                elemanSayisi = 1;
                elemanSayisi += ElamanSayisiInt(dugum.sol);
                elemanSayisi += ElamanSayisiInt(dugum.sag);
            }
            return elemanSayisi;
        }
       

    }
    }


