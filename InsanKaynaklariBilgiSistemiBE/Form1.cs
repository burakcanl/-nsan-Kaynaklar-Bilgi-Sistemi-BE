using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace InsanKaynaklariBilgiSistemiBE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static IkiliAramaAgaci IkiliAramaAgaci = new IkiliAramaAgaci();//Kişi Bilgileri
        public static HashTableIsyeri HashTableIsyeri = new HashTableIsyeri();//işyeri bilgileri tutuluyor
        public static HashTableIsIlani HashTableIsIlani= new HashTableIsIlani();//ilan no ve başvuran kişiler atılıyor
        public static HeapAgaci iseBasvuranKisiler = new HeapAgaci(10);

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void gbGenelBilgiler_Enter(object sender, EventArgs e)
        {

        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKullaniciKayit_Click(object sender, EventArgs e)
        {
            Kisi kisi = new Kisi();
            kisi.Ad = txtAd.Text;
            kisi.Soyad = txtSoyad.Text;
            kisi.Adres = txtAdres.Text;
            kisi.TelefonNo = Convert.ToInt64(txtTelefon.Text);
            kisi.ePosta = txtEposta.Text;
            kisi.uyruk = txtUyruk.Text;
            kisi.TCKimlikNo = Convert.ToInt64(txtKimlikNo.Text);
            kisi.dogumYeri = txtDogumYeri.Text;
            kisi.dogumTarihi = Convert.ToDateTime(dtDogumTarihi.Text);
            kisi.medeniDurum = txtMdurum.Text;
            kisi.yabanciDil = txtYbcdil.Text;
            if (kisi.yabanciDil == "İNGİLİZCE" )
            {
                Form1.IkiliAramaAgaci.YabanciDilBilenler.Add(kisi);
            }
            kisi.ilgiAlanlari = txtIlgiAlanlari.Text;
            kisi.Referans = txtReferans.Text;
           
            if (checkIsDeneyimi.Checked)
            {
                isDeneyimi isDeneyimi = new isDeneyimi();
                isDeneyimi.isyeriAd = txtIsyeriAdi.Text;
                isDeneyimi.isyeriAdres = txtIsyeriAdres.Text;
                isDeneyimi.calisilanYilSayisi = Convert.ToInt32(txtCalisilanYilSayisi.Text);
                if(isDeneyimi.calisilanYilSayisi >= 2)
                {
                    Form1.IkiliAramaAgaci.EnAzIkiYilDeneyimliler.Add(kisi);
                }
                isDeneyimi.pozisyon = txtPozisyon.Text;
                
                kisi.IsDeneyimiEkle(isDeneyimi);
                
            }
            EgitimDurumu egitimDurumu = new EgitimDurumu();
            egitimDurumu.OkulAdi = txtOkulAdi.Text;
            egitimDurumu.bolum = txtBolum.Text;
            egitimDurumu.baslangicTarihi = Convert.ToDateTime(dtBaslangicTarihi.Text);
            egitimDurumu.bitisTarihi = Convert.ToDateTime(dtBitisTarihi.Text);
            egitimDurumu.notOrt = Convert.ToInt32(txtNotOrtalamasi.Text);
            kisi.EgitimDurumuAta(egitimDurumu);
            Form1.IkiliAramaAgaci.Ekle(kisi);
            MessageBox.Show("Kişi başarıyla kaydolmuştur");

        }

        private void btnKisiGetir_Click(object sender, EventArgs e)
        {
            Kisi GetirKisi = new Kisi();
            GetirKisi = Form1.IkiliAramaAgaci.Ara(txtKisiGetir.Text).veri;
            if (GetirKisi == null)
            {
                MessageBox.Show("Kişi Bulunamadı");
            }
            else
            {
                txtAdGuncelle.Text = GetirKisi.Ad;
                txtSoyadGuncelle.Text = GetirKisi.Soyad;
                txtTelefonGuncelle.Text = GetirKisi.TelefonNo.ToString();
                txtEpostaGuncelle.Text = GetirKisi.ePosta;
                txtGuncelleUyruk.Text = GetirKisi.uyruk;
                txtKimlikNoGuncelle.Text = GetirKisi.TCKimlikNo.ToString();
                txtDogumYeriGuncelle.Text = GetirKisi.dogumYeri;
                dtDogumTarihiGuncelle.Text = (GetirKisi.dogumTarihi.Date.Day + "/" + GetirKisi.dogumTarihi.Date.Month + "/" + GetirKisi.dogumTarihi.Date.Year).ToString();
                txtGuncelleMedeniDurum.Text = GetirKisi.medeniDurum;
                txtGuncelleYabanciDil.Text = GetirKisi.yabanciDil;
                txtIlgiAlanlariGuncelle.Text = GetirKisi.ilgiAlanlari;
                txtAdresGuncelle.Text = GetirKisi.Adres;

                if (GetirKisi.isDeneyimi.Head != null)
                {
                    txtIsyeriAdiGuncelle.Text = ((isDeneyimi)GetirKisi.isDeneyimi.Head.Data).isyeriAd;
                    txtAdresGuncelle.Text = ((isDeneyimi)GetirKisi.isDeneyimi.Head.Data).isyeriAdres;
                    txtPozisyon.Text = ((isDeneyimi)GetirKisi.isDeneyimi.Head.Data).pozisyon;
                    txtCalisilanYilSayisiGuncelle.Text = ((isDeneyimi)GetirKisi.isDeneyimi.Head.Data).calisilanYilSayisi.ToString();
                }


                txtOkulAdiGuncelle.Text = ((EgitimDurumu)GetirKisi.egitimDurumu.Head.Data).OkulAdi;
                txtBolumGuncelle.Text = ((EgitimDurumu)GetirKisi.egitimDurumu.Head.Data).bolum;
                dtGuncelleBaslangicTarihi.Text = (((EgitimDurumu)GetirKisi.egitimDurumu.Head.Data).baslangicTarihi.Date.Day + "/" + ((EgitimDurumu)GetirKisi.egitimDurumu.Head.Data).baslangicTarihi.Date.Month + "/" + ((EgitimDurumu)GetirKisi.egitimDurumu.Head.Data).baslangicTarihi.Year).ToString();
                dtGuncelleBaslangicTarihi.Text = (((EgitimDurumu)GetirKisi.egitimDurumu.Head.Data).bitisTarihi.Date.Day + "/" + ((EgitimDurumu)GetirKisi.egitimDurumu.Head.Data).bitisTarihi.Date.Month + "/" + ((EgitimDurumu)GetirKisi.egitimDurumu.Head.Data).bitisTarihi.Date.Day).ToString();
                txtNotOrtalamasiGuncelle.Text = ((EgitimDurumu)GetirKisi.egitimDurumu.Head.Data).notOrt.ToString();

                Form1.IkiliAramaAgaci.Sil(txtKisiGetir.Text);
            }
        }

        private void lblKisiGetir_Click(object sender, EventArgs e)
        {

        }

        private void btnBilgileriGuncelle_Click(object sender, EventArgs e)
        {
            Kisi guncelKisi = new Kisi();
            guncelKisi.Ad = txtAdGuncelle.Text;
            guncelKisi.Soyad = txtSoyadGuncelle.Text;
            guncelKisi.Adres = txtAdresGuncelle.Text;
            guncelKisi.TelefonNo = Convert.ToInt64(txtTelefonGuncelle.Text);
            guncelKisi.ePosta = txtEpostaGuncelle.Text;
            guncelKisi.uyruk = txtGuncelleUyruk.Text;
            guncelKisi.TCKimlikNo = Convert.ToInt64(txtKimlikNoGuncelle.Text);
            guncelKisi.dogumYeri = txtDogumYeriGuncelle.Text;
            guncelKisi.dogumTarihi = Convert.ToDateTime(dtDogumTarihiGuncelle.Text);
            guncelKisi.medeniDurum = txtGuncelleMedeniDurum.Text;
            guncelKisi.yabanciDil = txtGuncelleYabanciDil.Text;

            if (guncelKisi.yabanciDil == "İNGİLİZCE")
            {
                Form1.IkiliAramaAgaci.YabanciDilBilenler.Add(guncelKisi);
            }
            guncelKisi.ilgiAlanlari = txtIlgiAlanlariGuncelle.Text;
            guncelKisi.Referans = txtReferansGuncelle.Text;
            if (chcbxGuncelleDeneyim.Checked)
            {
               isDeneyimi guncelleIsDeneyimi = new isDeneyimi();
                guncelleIsDeneyimi.isyeriAd = txtIsyeriAdiGuncelle.Text;
                guncelleIsDeneyimi.isyeriAdres = txtIsyeriAdresiGuncelle.Text;
                guncelleIsDeneyimi.pozisyon = txtPozisyonGuncelle.Text;
                guncelleIsDeneyimi.calisilanYilSayisi = Convert.ToInt32(txtCalisilanYilSayisiGuncelle.Text);
                if (guncelleIsDeneyimi.calisilanYilSayisi >= 2)
                {
                    Form1.IkiliAramaAgaci.EnAzIkiYilDeneyimliler.Add(guncelKisi);
                }
                guncelKisi.isDeneyimi.DeleteFirst();
                guncelKisi.isDeneyimi.InsertLast(guncelleIsDeneyimi);


            }
            EgitimDurumu guncelEgitimDurumu = new EgitimDurumu();
            guncelEgitimDurumu.OkulAdi = txtOkulAdiGuncelle.Text;
            guncelEgitimDurumu.bolum = txtBolumGuncelle.Text;
            guncelEgitimDurumu.baslangicTarihi = Convert.ToDateTime(dtGuncelleBaslangicTarihi.Text);
            guncelEgitimDurumu.bitisTarihi = Convert.ToDateTime(dtGuncelleBaslangicTarihi.Text);
            guncelEgitimDurumu.notOrt = Convert.ToInt32(txtNotOrtalamasiGuncelle.Text);
            


            guncelKisi.egitimDurumu.DeleteFirst();
            guncelKisi.egitimDurumu.InsertLast(guncelEgitimDurumu);

            Form1.IkiliAramaAgaci.Ekle(guncelKisi);

            MessageBox.Show("Güncelleme İşlemi Başarıyla Yapıldı");








        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Form1.IkiliAramaAgaci.Sil(txtAra.Text) == true)
                MessageBox.Show("Kişi Silindi");
            else
                MessageBox.Show("Kişi Bulunamadı");
        }

        private void btnIseBasvuruYap_Click(object sender, EventArgs e)
        {
            Kisi BasvuranEleman = Form1.IkiliAramaAgaci.Ara(txtAdSoyad.Text).veri;

            if (BasvuranEleman != null)
            {



                int ilanno = Convert.ToInt32(txtIlanNo.Text);
                object ilan = Form1.HashTableIsIlani.Get(ilanno);

                
                if (Form1.HashTableIsIlani.Get(ilanno) == null)
                    MessageBox.Show("İlan Bulunamadı");  
                else if (((SirketBilgileri)ilan).IsIlani.basvuracakEleman.Kontrol(BasvuranEleman))
                    MessageBox.Show("Daha Önceden Başvurunuz Bulunuyor");
                else
                {
                    Form1.HashTableIsIlani.isIlaninaBasvuranEkle(ilanno, BasvuranEleman);
                }

                


            }
            else
                MessageBox.Show("Aradığınız Kişi Bulunamadı");
        }

        

        

        private void btnEnAzIkiYilDeneyim_Click_1(object sender, EventArgs e)
        {
            lbxEnAzIkiYil.Items.Clear();
            for (int i = 0; i < Form1.IkiliAramaAgaci.EnAzIkiYilDeneyimliler.Count; i++)
            {
                lbxEnAzIkiYil.Items.Add(Form1.IkiliAramaAgaci.EnAzIkiYilDeneyimliler[i].Ad + Form1.IkiliAramaAgaci.EnAzIkiYilDeneyimliler[i].Soyad);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbxYabanciDİl.Items.Clear();
            for (int i = 0; i < Form1.IkiliAramaAgaci.YabanciDilBilenler.Count; i++)
            {
                lbxYabanciDİl.Items.Add(Form1.IkiliAramaAgaci.YabanciDilBilenler[i].Ad + Form1.IkiliAramaAgaci.YabanciDilBilenler[i].Soyad);
            }
        }

        private void btnIlanaBasvuranlar_Click(object sender, EventArgs e)
        {
            lbxInOrderList.Items.Clear();
            lbxPostOrderList.Items.Clear();
            lbxPreOrderLİst.Items.Clear();
            Form1.IkiliAramaAgaci.InOrder();
            Form1.IkiliAramaAgaci.PostOrder();
            Form1.IkiliAramaAgaci.PreOrder();
            foreach (Kisi Listele in Form1.IkiliAramaAgaci.InOrderList)
            {
                lbxInOrderList.Items.Add(Listele.Ad + " " + Listele.Soyad + " " + Listele.TelefonNo);
            }
            foreach (Kisi Listele in Form1.IkiliAramaAgaci.PostOrderList)
            {
                lbxPostOrderList.Items.Add(Listele.Ad + " " + Listele.Soyad + " " + Listele.TelefonNo);
            }
            foreach (Kisi Listele in Form1.IkiliAramaAgaci.PreOrderList)
            {
                lbxPreOrderLİst.Items.Add(Listele.Ad + " " + Listele.Soyad + " " + Listele.TelefonNo);
            }



        }

        

        private void btnDerinlikBul_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Derinlik : " + IkiliAramaAgaci.DerinlikBul().ToString());
        }

        private void btnElemanSayisi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kayıtlardaki Eleman Sayısı : " + IkiliAramaAgaci.ElemanSayisi().ToString());
        }

        private void btnIsyeriEkle_Click(object sender, EventArgs e)
        {
            SirketBilgileri sirket = new SirketBilgileri();
            sirket.ad = txtIsyeriAdi.Text;
            sirket.telefon = Convert.ToInt64(txtIsyeriTelefon.Text);
            sirket.adres = txtIsyeriAdresi.Text;
            sirket.fax = Convert.ToInt64(txtIsyeriFaks.Text);
            sirket.ePosta = txtIsyeriEposta.Text;
            MessageBox.Show(sirket.sirketNo.ToString() + ("Nolu şirketiniz oluşturulmuştur."));
            txtVerIlanNo.Text = sirket.sirketNo.ToString();
            Form1.HashTableIsyeri.Add(sirket.sirketNo, sirket);
        }

        private void btnIsIlaniVer_Click(object sender, EventArgs e)
        {
            try
            {
                SirketBilgileri sb = new SirketBilgileri();
                sb = (SirketBilgileri)(Form1.HashTableIsyeri.Get(Convert.ToInt32(txtVerIlanNo.Text)));
                sb.IsIlani = new IsIlaniBilgileri();
                sb.ad = txtIsyeriIlanAdi.Text;
                sb.IsIlani.isTanimi = txtIlanIsinTanimi.Text;
                sb.IsIlani.arananOzellik = txtArananEleman.Text;
                sb.IsIlani.Pozisyon = txtIlanPozisyon.Text;
                sb.IsIlaniOlustur(sb.IsIlani);
                Form1.HashTableIsyeri.RemoveSirket(Convert.ToInt32(txtVerIlanNo.Text));
                Form1.HashTableIsyeri.Add(sb.sirketNo, sb);
                MessageBox.Show("İş İlanınız Oluşturulmuştur");
            }
            catch 
            {

                MessageBox.Show("İş İlanınız Maalesef Oluşturalamadı. Lütfen İlan Numaranızı Kontrol Edin.");
            }
        }

        private void btnIsyeriAra_Click(object sender, EventArgs e)
        {
            SirketBilgileri guncelSirket = new SirketBilgileri();
            guncelSirket = (SirketBilgileri)(Form1.HashTableIsyeri.Get(Convert.ToInt32(txtIsyeriNoGir.Text)));
            if (guncelSirket != null)
            {
                txtIsyeriAdıGuncelle.Text = guncelSirket.ad;
                txtIsyeriAdresiniGuncelle.Text = guncelSirket.adres;
                txtIsyeriEpostaGuncelle.Text = guncelSirket.ePosta;
                txtIsyeriTelefonuGuncelle.Text = guncelSirket.telefon.ToString();
                txtFaksGuncelle.Text = guncelSirket.fax.ToString();






            }
            else
                MessageBox.Show("Şirketiniz  bulunamadı");
        }

        private void btnIsyeriniGuncelle_Click(object sender, EventArgs e)
        {

            SirketBilgileri sirket = new SirketBilgileri();
            sirket.ad = txtIsyeriAdi.Text;
            sirket.telefon = Convert.ToInt64(txtIsyeriTelefon.Text);
            sirket.adres = txtIsyeriAdresi.Text;
            sirket.fax = Convert.ToInt64(txtIsyeriFaks.Text);
            sirket.ePosta = txtIsyeriEposta.Text;
            Form1.HashTableIsyeri.Update(Convert.ToInt32(txtIsyeriNoGir.Text), sirket);
            MessageBox.Show("Bilgileriniz Başarıyla Güncellenmiştir");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                object ilan = Form1.HashTableIsIlani.Get(Convert.ToInt32(txtIlanNoGetir.Text));
                string bkisiler = ((SirketBilgileri)ilan).IsIlani.basvuracakEleman.HeapiGoruntule();
                txtAdaylarinIlanlari.Text = bkisiler;
            }
            catch
            {
                MessageBox.Show("İlan bulunamadı");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Kisi iseAlinan = new Kisi();
            object ilan = Form1.HashTableIsIlani.Get(Convert.ToInt32(txtUygunAdayNo.Text));
            iseAlinan = ((SirketBilgileri)ilan).IsIlani.basvuracakEleman.RemoveMax().Deger;
            MessageBox.Show(iseAlinan.Ad + "" + iseAlinan.Soyad + "   İşe Alınmıştır");
            
        }

      

        private void btnIlaniSil_Click(object sender, EventArgs e)
        {
            object ilan = Form1.HashTableIsIlani.Get(Convert.ToInt32(txtIlanAdı.Text));
            int ilanno = ((SirketBilgileri)ilan).IsIlani.ilanNo;
            Form1.HashTableIsIlani.IlaniSil(ilanno);
            MessageBox.Show("İlanınız Başarıyla Silinmiştir");        }

        private void btnIsyeriSl_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.HashTableIsyeri.RemoveSirket(Convert.ToInt32(txtIsyeriSil.Text));
                MessageBox.Show("Şirket Bilgileri Silindi");
            }
            catch
            {
                MessageBox.Show("Şirket Bilgileri Bulunamadı");
                    
                
            }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lbxPozisyonaGore.Items.Clear();
            for (int i = 0; i < Form1.HashTableIsIlani.Pozisyonlar.Count; i++)
            {
                lbxPozisyonaGore.Items.Add(Form1.HashTableIsIlani.Pozisyonlar[i].Pozisyon);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lbxIYAdınaGore.Items.Clear();
            for (int i = 0; i < Form1.HashTableIsIlani.Sirketler.Count; i++)
            {
                lbxIYAdınaGore.Items.Add(Form1.HashTableIsIlani.Sirketler[i].ad);
            }

        }
    }
    }

