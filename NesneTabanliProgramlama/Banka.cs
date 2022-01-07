using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesneTabanliProgramlama
{
    public class Banka
    {
        private Hesap[] bankaHesaplari = null;
        private int bankaSonHesapID = 10000000;

        private int[] bankaCekilisListesi = null;
        public void hesapListesi()
        {
            if (bankaHesaplari != null)
            {
                Console.WriteLine(">>>>> Bankamızda Bulunan Hesapların Listesi <<<<<");
                foreach (var bankaHesabi in bankaHesaplari)
                    Console.WriteLine(bankaHesabi.HesapBilgisi());
            }
            else
            {
                Console.WriteLine("Görüntülecek Hesap Bulunmamaktadır!");
            }
        }
        public void paraYatir(int hesapNumarasi, double para)
        {
            if (bankaHesaplari != null)
            {
                for (int i = 0; i < bankaHesaplari.Length; i++)
                {
                    if (bankaHesaplari[i].HesapNumarasiAl() == hesapNumarasi)
                    {
                        bankaHesaplari[i].paraYatir(para);
                        Hesap.HesapTuru type = bankaHesaplari[i].HesabinTuru();
                        if (type != Hesap.HesapTuru.Belirtilmedi || type != Hesap.HesapTuru.Cari)
                        {
                            if (para >= 1000)
                            {
                                for (int j = 0; j < para / 1000; j++)
                                {
                                    CekilisNoEkle(bankaHesaplari[i].HesapNumarasiAl());
                                }
                            }
                        }
                        break;
                    }
                }
            }
            else
                Console.WriteLine("Bu Hesap Numarasına Ait Bir Hesap Bulunmamaktadır!");
        }
        public void paraCek(int hesapNumarasi, double para)
        {
            if (bankaHesaplari != null)
            {
                for (int i = 0; i < bankaHesaplari.Length; i++)
                {
                    if (bankaHesaplari[i].HesapNumarasiAl() == hesapNumarasi)
                    {
                        bankaHesaplari[i].paraCek(para);
                        Hesap.HesapTuru type = bankaHesaplari[i].HesabinTuru();
                        if (type != Hesap.HesapTuru.Belirtilmedi || type != Hesap.HesapTuru.Cari)
                        {
                            if (para >= 1000)
                            {
                                for (int j = 0; j < para / 1000; j++)
                                {
                                    CekilisNoEkle(bankaHesaplari[i].HesapNumarasiAl());
                                }
                            }
                        }
                        break;
                    }
                }
            }
            else
                Console.WriteLine("Bu Hesap Numarasına Ait Bir Hesap Bulunmamaktadır!");
        }
        public void CekilisNoEkle(int hesapNumarasi)
        {
            if (bankaCekilisListesi == null)
            {
                bankaCekilisListesi = new int[1];
                bankaCekilisListesi[0] = hesapNumarasi;
            }
            else
            {
                Array.Resize(ref bankaCekilisListesi, bankaCekilisListesi.Length + 1);
                bankaCekilisListesi[bankaCekilisListesi.Length - 1] = hesapNumarasi;
            }
        }
        public void cekilis()
        {
            if (bankaCekilisListesi != null)
            {
                Random rand = new Random();
                int index = rand.Next(bankaCekilisListesi.Length);
                foreach (var bankaHesap in bankaHesaplari)
                {
                    if (bankaHesap.HesapNumarasiAl() == bankaCekilisListesi[index])
                    {
                        Console.WriteLine(@"
  /$$$$$$            /$$       /$$ /$$ /$$                  /$$$$$$                                                   
 /$$__  $$          | $$      |__/| $$|__/                 /$$__  $$                                                  
| $$  \__/  /$$$$$$ | $$   /$$ /$$| $$ /$$  /$$$$$$$      | $$  \__/  /$$$$$$  /$$$$$$$  /$$   /$$  /$$$$$$$ /$$   /$$
| $$       /$$__  $$| $$  /$$/| $$| $$| $$ /$$_____/      |  $$$$$$  /$$__  $$| $$__  $$| $$  | $$ /$$_____/| $$  | $$
| $$      | $$$$$$$$| $$$$$$/ | $$| $$| $$|  $$$$$$        \____  $$| $$  \ $$| $$  \ $$| $$  | $$| $$      | $$  | $$
| $$    $$| $$_____/| $$_  $$ | $$| $$| $$ \____  $$       /$$  \ $$| $$  | $$| $$  | $$| $$  | $$| $$      | $$  | $$
|  $$$$$$/|  $$$$$$$| $$ \  $$| $$| $$| $$ /$$$$$$$/      |  $$$$$$/|  $$$$$$/| $$  | $$|  $$$$$$/|  $$$$$$$|  $$$$$$/
 \______/  \_______/|__/  \__/|__/|__/|__/|_______/        \______/  \______/ |__/  |__/ \______/  \_______/ \______/                      
                    ");
                        Console.WriteLine(String.Format("Çekilişi kazanan müşterimiz: {0}", bankaHesap.HesapAdi()));
                        bankaHesap.cekilisParaYatir(2500);
                        break;
                    }
                }
            }
            else
                Console.WriteLine("Herhangi Bir İşlem Gerçekleştirilmediğinden Dolayı Çekiliş Gerçekleştirilemiyor! ");
        }
        public void hesapDurum(int hesapNumarasi)
        {
            if (bankaHesaplari != null)
            {
                for (int i = 0; i < bankaHesaplari.Length; i++)
                {
                    Console.WriteLine(String.Format(">>>>> {0} Banka Hesabının Durumu <<<<<", bankaHesaplari[i].HesapAdi()));
                    if (bankaHesaplari[i].HesapNumarasiAl() == hesapNumarasi)
                    {
                        bankaHesaplari[i].hesapDurum();
                        break;
                    }
                }
            }
            else
                Console.WriteLine("Girmiş Olduğunuz Hesap Numarasına Ait Bir Hesap Bulunmamaktadır!");
        }

        public void hesapOzeti(int hesapNumarasi)
        {
            if (bankaHesaplari != null)
            {
                for (int i = 0; i < bankaHesaplari.Length; i++)
                {
                    if (bankaHesaplari[i].HesapNumarasiAl() == hesapNumarasi)
                    {
                        bankaHesaplari[i].hesapOzeti();
                        break;
                    }
                }
            }
            else
                Console.WriteLine("Böyle Bir Hesap Bulunmamaktadır!");
        }

        public bool HesapEkle(string hesapIsmi, Hesap.HesapTuru hesapTuru, double hesapBakiye = 0)
        {
            if (bankaHesaplari == null)
            {
                bankaHesaplari = new Hesap[1];
                bankaHesaplari[0] = new Hesap(++bankaSonHesapID, hesapIsmi, hesapTuru, hesapBakiye);
                if (bankaHesaplari[0].HesapNumarasiAl() == 10000000)
                {
                    bankaHesaplari = null;
                    return false;
                }
                return true;
            }
            else
            {
                Array.Resize(ref bankaHesaplari, bankaHesaplari.Length + 1);
                bankaHesaplari[bankaHesaplari.Length - 1] = new Hesap(++bankaSonHesapID, hesapIsmi, hesapTuru, hesapBakiye);
                if (bankaHesaplari[bankaHesaplari.Length - 1].HesapNumarasiAl() == 10000000)
                {
                    Array.Resize(ref bankaHesaplari, bankaHesaplari.Length - 1);
                    return false;
                }
                return true;
            }
        }
    }
}
