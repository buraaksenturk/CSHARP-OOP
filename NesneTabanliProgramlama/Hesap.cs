using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesneTabanliProgramlama
{
    public class Hesap
    {
        public enum HesapTuru
        {
            Belirtilmedi,
            KisaVadeli,
            UzunVadeli,
            Ozel,
            Cari
        };
        public enum HesapIslemTipi
        {
            Belirtilmedi,
            HesapOlusturma,
            ParaYatirma,
            ParaCekme
        };
        struct HesapIslem
        {
            public int id;
            public HesapIslemTipi type;
            public string tarih;
            public double eskiPara;
            public double guncelPara;
            public string mesaj;
            public int cekilisHakki;
            public HesapIslem(int cekilisHakki) : this()
            {
                this.cekilisHakki = cekilisHakki;
            }
        }
        private string hesapIsmi = "";
        private HesapTuru hesapTuru = HesapTuru.Belirtilmedi;
        private int hesapNumarasi = 10000000;
        private double hesapBakiye = 0;
        private double hesapEskiBakiye = 0;
        private double karOrani = 0;
        private HesapIslem[] hesapIslem = null;
        private int hesapSonIslemID = 0;
        private object cekilisHakki;
        public Hesap(int sonID, string hesapIsmi, HesapTuru hesapTuru, double hesapBakiye = 0)
        {
            switch (hesapTuru)
            {
                case HesapTuru.KisaVadeli:
                    if (hesapBakiye >= 5000)
                    {
                        this.hesapIsmi = hesapIsmi;
                        this.hesapTuru = hesapTuru;
                        this.hesapNumarasi = sonID;
                        this.hesapBakiye = hesapBakiye;
                        this.karOrani = 0.15;

                        IslemEkle(HesapIslemTipi.HesapOlusturma, String.Format("{0} Hesabınız Açıldı! Kar Oranı Yıllık %15'tir.", HesapTuruString(hesapTuru)));
                        islemDekontu(hesapSonIslemID);
                        break;
                    }
                    else goto devam;
                case HesapTuru.UzunVadeli:
                    if (hesapBakiye >= 10000)
                    {
                        this.hesapIsmi = hesapIsmi;
                        this.hesapTuru = hesapTuru;
                        this.hesapNumarasi = sonID;
                        this.hesapBakiye = hesapBakiye;
                        this.karOrani = 0.17;
                        IslemEkle(HesapIslemTipi.HesapOlusturma, String.Format("{0} Hesabınız Açıldı! Kar Oranı Yıllık %17'dir.", HesapTuruString(hesapTuru)));
                        islemDekontu(hesapSonIslemID);
                        break;
                    }
                    else goto devam;
                case HesapTuru.Ozel:
                    this.hesapIsmi = hesapIsmi;
                    this.hesapTuru = hesapTuru;
                    this.hesapNumarasi = sonID;
                    this.hesapBakiye = hesapBakiye;
                    this.karOrani = 0.1;
                    IslemEkle(HesapIslemTipi.HesapOlusturma, String.Format("{0} Hesabınız Açıldı! Kar Oranı Yıllık %10'dur.", HesapTuruString(hesapTuru)));
                    islemDekontu(hesapSonIslemID);
                    break;
                case HesapTuru.Cari:
                    this.hesapIsmi = hesapIsmi;
                    this.hesapTuru = hesapTuru;
                    this.hesapNumarasi = sonID;
                    this.hesapBakiye = hesapBakiye;
                    this.karOrani = 0;
                    IslemEkle(HesapIslemTipi.HesapOlusturma, String.Format("{0} Hesabınız Açıldı! Kar Oranı Bulunmamaktadır.", HesapTuruString(hesapTuru)));
                    islemDekontu(hesapSonIslemID);
                    break;
                default:
                devam:
                    break;
            }
        }

        public string HesapAdi()
        {
            return hesapIsmi;
        }

        public HesapTuru HesabinTuru()
        {
            return hesapTuru;
        }

        private string HesapTuruString(HesapTuru type)
        {
            switch (type)
            {
                case HesapTuru.KisaVadeli:
                    return "Kısa Vadeli";

                case HesapTuru.UzunVadeli:
                    return "Uzun Vadeli";

                case HesapTuru.Ozel:
                    return "Özel";

                case HesapTuru.Cari:
                    return "Cari";
            }

            return "";
        }

        public int HesapNumarasiAl()
        {
            return hesapNumarasi;
        }

        public void paraYatir(double para)
        {
            if (!HesapVarMi())
                return;

            Console.WriteLine("Kar Oranı Hesabı İçin İşlem Tarihini Girmeniz Gerekmektedir, ");

        hataliGun:
            Console.Write("Gün Giriniz(1-31): ");
            string gun = Console.ReadLine();
            int gunSayisi = Convert.ToInt32(gun);
            if (!(gunSayisi >= 1 && gunSayisi <= 31))
                goto hataliGun;

        hataliAy:
            Console.Write("Ay Giriniz(1-12): ");
            string ay = Console.ReadLine();
            int aySayisi = Convert.ToInt32(ay);
            if (!(aySayisi >= 1 && aySayisi <= 12))
                goto hataliAy;

        hataliYil:
            Console.Write("Yıl Giriniz(1609-2022): ");
            string yil = Console.ReadLine();
            int yilSayisi = Convert.ToInt32(yil);
            if (!(yilSayisi >= 1609 && yilSayisi <= 2022))
                goto hataliYil;
            hesapEskiBakiye = hesapBakiye;
            hesapBakiye += para;
            IslemEkle(HesapIslemTipi.ParaYatirma, String.Format("{0} TL Yatırıldı! Yeni Bakiye: {1} TL'dir.", para, hesapBakiye), String.Format("{0}/{1}/{2}", gun, ay, yil));
            islemDekontu(hesapSonIslemID);
        }
        public void cekilisParaYatir(double para)
        {
            if (!HesapVarMi())
                return;
            hesapBakiye += para;
            Console.WriteLine(String.Format("Sayın {0}, Çekilişi Kazandığın İçin {1} TL Hesabına Yatırıldı!", HesapAdi(), para));
        }
        public void paraCek(double para)
        {
            if (!HesapVarMi())
                return;

            if (para <= hesapBakiye)
            {
                hesapEskiBakiye = hesapBakiye;
                hesapBakiye -= para;
                IslemEkle(HesapIslemTipi.ParaCekme, String.Format("{0} TL Çekildi! Yeni Bakiye: {1} TL'dir.", para, hesapBakiye));
                islemDekontu(hesapSonIslemID);
            }
            else
            {
                Console.WriteLine("Yeterli Bakiyeniz Olmadığından Para Çekme İşlemi Gerçekleşemedi.");
            }
        }
        public string HesapBilgisi()
        {
            return String.Format("\tHesap No: {0}\n\tHesap Tipi: {1}\n\tHesap Adı: {2}\n\tHesap Bakiyesi: {3}\n", hesapNumarasi, HesapTuruString(hesapTuru), hesapIsmi, hesapBakiye);
        }
        private void IslemEkle(HesapIslemTipi type, string mesaj, string tarih = "")
        {
            if (hesapIslem == null)
            {
                hesapIslem = new HesapIslem[1];
                hesapIslem[0].id = ++hesapSonIslemID;
                hesapIslem[0].type = type;
                hesapIslem[0].tarih = (tarih == "") ? DateTime.Now.ToString("dd.MM.yyyy") : Convert.ToDateTime(tarih).ToString("dd.MM.yyyy");
                hesapIslem[0].eskiPara = hesapEskiBakiye;
                hesapIslem[0].guncelPara = hesapBakiye;
                hesapIslem[0].mesaj = mesaj;
            }
            else
            {
                Array.Resize(ref hesapIslem, hesapIslem.Length + 1);

                hesapIslem[hesapIslem.Length - 1].id = ++hesapSonIslemID;
                hesapIslem[hesapIslem.Length - 1].type = type;
                hesapIslem[hesapIslem.Length - 1].tarih = (tarih == "") ? DateTime.Now.ToString("dd.MM.yyyy") : Convert.ToDateTime(tarih).ToString("dd.MM.yyyy");  
                hesapIslem[hesapIslem.Length - 1].eskiPara = hesapEskiBakiye;
                hesapIslem[hesapIslem.Length - 1].guncelPara = hesapBakiye;
                hesapIslem[hesapIslem.Length - 1].mesaj = mesaj;
            }
        }
        private string IslemTuruAl(HesapIslemTipi type)
        {
            switch (type)
            {
                case HesapIslemTipi.HesapOlusturma:
                    return "Hesap Oluşturma İşlemi";

                case HesapIslemTipi.ParaYatirma:
                    return "Para Yatırma İşlemi";

                case HesapIslemTipi.ParaCekme:
                    return "Para Çekme İşlemi";
            }
            return "";
        }
        private bool HesapVarMi()
        {
            return hesapTuru != HesapTuru.Belirtilmedi;
        }
        public void hesapDurum()
        {
            if (!HesapVarMi())
                return;

            if (hesapTuru != Hesap.HesapTuru.Cari)
            {
                if (hesapTuru == Hesap.HesapTuru.KisaVadeli)
                    cekilisHakki = Convert.ToInt32((hesapBakiye - 5000) / 1000);
                else if (hesapTuru == Hesap.HesapTuru.UzunVadeli)
                    cekilisHakki = Convert.ToInt32((hesapBakiye - 10000) / 1000);
                else
                    cekilisHakki = Convert.ToInt32(hesapBakiye / 1000);
            }
            else
                cekilisHakki = "Çekiliş Hakkınız Bulunmamaktadır.";
            Console.WriteLine(String.Format("Hesap Tipi: {0}\nHesap No: {1}\nHesap Adı: {2}\nBakiye: {3}\nÇekiliş Hakkı: {4}", HesapTuruString(hesapTuru), hesapNumarasi, hesapIsmi, hesapBakiye, cekilisHakki));
        }
        public void hesapNo()
        {
            if (!HesapVarMi())
                return;
            Console.WriteLine(String.Format("Hesap No: {0}", HesapNumarasiAl()));
        }
        public void karTutari()
        {
            if (!HesapVarMi())
                return;
            DateTime hesabinOlusturulmaTarihi = Convert.ToDateTime(hesapIslem[0].tarih);
            TimeSpan deger = DateTime.Now.Subtract(hesabinOlusturulmaTarihi);
            double karTutarıToplam = deger.Days * karOrani / 365;
            Console.WriteLine(String.Format("\tKar Tutarınız: {0}", karTutarıToplam));
        }
        public void hesapOzeti()
        {
            if (!HesapVarMi())
                return;
            Console.WriteLine("Yapılan İşlemler: ");
            foreach (var hIslem in hesapIslem)
                Console.WriteLine(String.Format("\n{0} Nolu İşlem,\n\tTür: {1}\n\tTarih: {2}\n\tÖnceki/Sonraki Bakiye: {3}/{4}\n\tAçıklama: {5}", hIslem.id, IslemTuruAl(hIslem.type), hIslem.tarih, hIslem.eskiPara, hIslem.guncelPara, hIslem.mesaj));
        }
        public void islemDekontu(int islemNo)
        {
            if (!HesapVarMi())
                return;
            foreach (var hIslem in hesapIslem)
            {
                if (hIslem.id == islemNo)
                {
                    Console.WriteLine("\nYapılan İşlemin Dekontu:");
                    Console.WriteLine(String.Format("\tDekont Numarası: {0}", islemNo));
                    Console.WriteLine(String.Format("\tTür: {0}", IslemTuruAl(hIslem.type)));
                    Console.WriteLine(String.Format("\tTarih: {0}", hIslem.tarih));
                    Console.WriteLine(String.Format("\tÖnceki/Sonraki Bakiye: {0}/{1}", hIslem.eskiPara, hIslem.guncelPara));
                    Console.WriteLine(String.Format("\tAçıklama: {0}", hIslem.mesaj));
                    break;
                }
            }
        }
    }
}
