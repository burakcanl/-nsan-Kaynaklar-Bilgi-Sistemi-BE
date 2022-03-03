using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemiBE
{
    public class HeapAgaci
    {
        private HeapDugumu[] heapArray;
        private int maxSize;
        private int currentSize;
        public HeapAgaci(int maxHeapSize)
        {
            maxSize = maxHeapSize;
            heapArray = new HeapDugumu[maxSize];
            currentSize = 0;

        }
        public bool IsEmpty()
        {
            return currentSize == 0;
        }
        public bool Insert(Kisi value)
        {
            if (currentSize == maxSize)
                return false;
            HeapDugumu newHeapDugumu = new HeapDugumu(value);
            heapArray[currentSize] = newHeapDugumu;
            MoveToUp(currentSize++);
            return true;
        }
        public bool Kontrol(Kisi value)
        {
            bool kontrol = false;
            for (int i = 0; i < currentSize; i++)
            {

                if (heapArray[i].Deger.Ad == value.Ad)
                    kontrol = true;
                else
                    kontrol = false;

            }
            return kontrol;
        }
        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapArray[index];
            while (index > 0 && heapArray[parent].Deger.UygunlukDurumu < bottom.Deger.UygunlukDurumu) 
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }
        public HeapDugumu RemoveMax() 
        {
            HeapDugumu root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            MoveToDown(0);
            heapArray[currentSize] = null;
            return root;
        }
        public void MoveToDown(int index)
        {
            int largerChild;
            HeapDugumu top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                
                if (rightChild < currentSize && heapArray[leftChild].Deger.UygunlukDurumu < heapArray[rightChild].Deger.UygunlukDurumu)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (top.Deger.UygunlukDurumu >= heapArray[largerChild].Deger.UygunlukDurumu)
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }
        public string HeapiGoruntule()   

        {
            string sonuc = "";

            for (int i = 0; i < currentSize; i++)
            {

                if (heapArray[i] != null)
                {
                    sonuc += "Aday Ad:" + heapArray[i].Deger.Ad + " Soyad:" + heapArray[i].Deger.Soyad + " Uygunluk Durumu:" + Math.Round(heapArray[i].Deger.UygunlukDurumu, 2).ToString() + "İlgi Alanı" + heapArray[i].Deger.ilgiAlanlari + Environment.NewLine;


                }




            }
            return sonuc;
        }
    }

    }

