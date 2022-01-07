using System;
using System.Threading;

namespace NesneTabanliProgramlama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banka banka = new Banka();

        Menu:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
                                 .-'``'-.
                                / ______; \
                               { _______}\|
                                (/ O O \)(_)
                                (.-. \.-.)
   _______________________ooo__(   '--'    )__________________________
  /                             '-.___.-'                            \
 |                      PARANIZIN GÜVENLE TUTULDUĞU                   |
 |                         KYK BANKA HOŞGELDİNİZ                      |
  \________________________________________ooo_______________________/
                                | _ | _ | 
                ");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Hesap Açma İşlemleri");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2. Para Yatırma İşlemi (Hesap No ile)");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("3. Para Çekme İşlemi (Hesap No ile)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("4. Hesap Listesi");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("5. Hesap Durum (Hesap No ile)");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("6. Hesap İşlem Kayıtları (Hesap No ile)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("7. Çekiliş");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("________________________________________");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Yapmak İsteğiniz İşlemi Giriniz: ");
            string islemNumarasi = Console.ReadLine();
            Console.WriteLine(@"
          _..._
        .'     '.
       /  _   _  \
       | (o)_(o) |
        \(     ) /
        //'._.'\ \          _________________________
       //   .   \ \        /                         \
      ||   .     \ \      |    Yönlendiriliyorsunuz   |
      |\   :     / |      |      Lütfen Bekleyiniz    |
      \ `) '   (`  /_      \_________________________/
    _)``'.____,.''` (_
    )     )'--'(     (
     '---`      `---`
                    ");
            Thread.Sleep(2000);
            if (islemNumarasi == "1")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"
###############################################################################################################################
# 1 - Kısa Vadeli Hesap Açma(Hesabın Kâr Oranı Yıllık %15’tir. Hesabın Açılabilmesi İçin En Az 5.000 TL Bakiye Gereklidir.)   #
# 2 - Uzun Vadeli Hesap Açma(Hesabın Kâr Oranı Yıllık %17’tir. Hesabın Açılabilmesi İçin En Az 10.000 TL Bakiye Gereklidir.)  #
# 3 - Özel Hesap Açma(Hesabın Kâr Oranı Yıllık %10’dur. Hesabın Açılabilmesi İçin Minimum Tutar Zorunluluğu Yoktur.)          #
# 4 - Cari Hesap Açma(Hesap Kâr Getirisi Olmayan Hesaptır.)                                                                   #
###############################################################################################################################
");
                Console.Write("-> Lütfen Açmak İstediğiniz Hesap Türünü Seçiniz: ");
                islemNumarasi += "." + Console.ReadLine();
                Console.WriteLine(@"
          _..._
        .'     '.
       /  _   _  \
       | (o)_(o) |
        \(     ) /
        //'._.'\ \          _________________________
       //   .   \ \        /                         \
      ||   .     \ \      |    Yönlendiriliyorsunuz   |
      |\   :     / |      |      Lütfen Bekleyiniz    |
      \ `) '   (`  /_      \_________________________/
    _)``'.____,.''` (_
    )     )'--'(     (
     '---`      `---`
                    ");
                Thread.Sleep(2000);
            }

            switch (islemNumarasi)
            {
                case "1.1":
                    Console.WriteLine(">>>>> Kısa Vadeli Hesap Açma <<<<<");
                    Console.Write("-> Adınızı Giriniz: ");
                    string hesapIsmi = Console.ReadLine();
                    Console.Write("-> Yüklemek İstediğiniz Bakiyeyi Giriniz: ");
                    double hesapBakiye = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(@"
          _..._
        .'     '.
       /  _   _  \
       | (o)_(o) |
        \(     ) /
        //'._.'\ \          _______________________________
       //   .   \ \        /                                \
      ||   .     \ \      |   İşleminiz Gerçekleştiriliyor  |
      |\   :     / |      |        Lütfen Bekleyiniz        |
      \ `) '   (`  /_      \________________________________/
    _)``'.____,.''` (_
    )     )'--'(     (
     '---`      `---`
                    ");
                    Thread.Sleep(2000);
                    if (banka.HesapEkle(hesapIsmi, Hesap.HesapTuru.KisaVadeli, hesapBakiye))
                        Console.WriteLine("Hesap Başarıyla Oluşturuldu.");
                    else
                        Console.WriteLine("Bakiyeniz Kısa Vadeli Hesap Açmak İçin Gerekli Miktarı Karşılamamaktadır. Minimum Bakiye: 5000 olmalıdır.");
                    break;

                case "1.2":
                    Console.WriteLine(">>>>> Uzun Vadeli Hesap Açma <<<<<");
                    Console.Write("-> Adınızı Giriniz: ");
                    hesapIsmi = Console.ReadLine();
                    Console.Write("-> Yüklemek İstediğiniz Bakiyeyi Giriniz: ");
                    hesapBakiye = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(@"
          _..._
        .'     '.
       /  _   _  \
       | (o)_(o) |
        \(     ) /
        //'._.'\ \          _______________________________
       //   .   \ \        /                                \
      ||   .     \ \      |   İşleminiz Gerçekleştiriliyor  |
      |\   :     / |      |        Lütfen Bekleyiniz        |
      \ `) '   (`  /_      \________________________________/
    _)``'.____,.''` (_
    )     )'--'(     (
     '---`      `---`
                    ");
                    Thread.Sleep(2000);
                    if (banka.HesapEkle(hesapIsmi, Hesap.HesapTuru.UzunVadeli, hesapBakiye))
                        Console.WriteLine("Hesap Başarıyla Oluşturuldu.");
                    else
                        Console.WriteLine("Bakiyeniz Uzun Vadeli Hesap Açmak İçin Gerekli Miktarı Karşılamamaktadır. Minimum Bakiye: 10000 olmalıdır.");
                    break;

                case "1.3":
                    Console.WriteLine(">>>>> Özel Hesap Açma <<<<<");
                    Console.Write("-> Adınızı Giriniz: ");
                    hesapIsmi = Console.ReadLine();
                    Console.Write("-> Yüklemek İstediğiniz Bakiyeyi Giriniz: ");
                    hesapBakiye = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(@"
          _..._
        .'     '.
       /  _   _  \
       | (o)_(o) |
        \(     ) /
        //'._.'\ \          _______________________________
       //   .   \ \        /                                \
      ||   .     \ \      |   İşleminiz Gerçekleştiriliyor  |
      |\   :     / |      |        Lütfen Bekleyiniz        |
      \ `) '   (`  /_      \________________________________/
    _)``'.____,.''` (_
    )     )'--'(     (
     '---`      `---`
                    ");
                    Thread.Sleep(2000);
                    if (banka.HesapEkle(hesapIsmi, Hesap.HesapTuru.Ozel, hesapBakiye))
                        Console.WriteLine("Hesap Başarıyla Oluşturuldu.");
                    else
                        Console.WriteLine("Hesap Oluşturulurken Hata Oluştu.");
                    break;

                case "1.4":
                    Console.WriteLine(">>>>> Cari Hesap Açma <<<<<");
                    Console.Write("-> Adınızı Giriniz: ");
                    hesapIsmi = Console.ReadLine();
                    Console.Write("-> Yüklemek İstediğiniz Bakiyeyi Giriniz: ");
                    hesapBakiye = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(@"
          _..._
        .'     '.
       /  _   _  \
       | (o)_(o) |
        \(     ) /
        //'._.'\ \          _______________________________
       //   .   \ \        /                                \
      ||   .     \ \      |   İşleminiz Gerçekleştiriliyor  |
      |\   :     / |      |        Lütfen Bekleyiniz        |
      \ `) '   (`  /_      \________________________________/
    _)``'.____,.''` (_
    )     )'--'(     (
     '---`      `---`
                    ");
                    Thread.Sleep(2000);
                    if (banka.HesapEkle(hesapIsmi, Hesap.HesapTuru.Cari, hesapBakiye))
                        Console.WriteLine("Hesap Başarıyla Oluşturuldu.");
                    else
                        Console.WriteLine("Hesap Oluşturulurken Hata Oluştu.");
                    break;

                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(">>>>> Para Yatırma İşlemi <<<<<");
                    Console.Write("-> İşlem Yapmak İstediğiniz Hesap Numaranızı giriniz: ");
                    int hesapNumarasi = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-> Yatırmak İstediğiniz Tutarı giriniz: ");
                    hesapBakiye = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(@"
          _..._
        .'     '.
       /  _   _  \
       | (o)_(o) |
        \(     ) /
        //'._.'\ \          _______________________________
       //   .   \ \        /                                \
      ||   .     \ \      |   İşleminiz Gerçekleştiriliyor  |
      |\   :     / |      |        Lütfen Bekleyiniz        |
      \ `) '   (`  /_      \________________________________/
    _)``'.____,.''` (_
    )     )'--'(     (
     '---`      `---`
                    ");
                    Thread.Sleep(2000);
                    banka.paraYatir(hesapNumarasi, hesapBakiye);
                    break;

                case "3":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(">>>>> Para Çekme İşlemi <<<<<");
                    Console.Write("-> İşlem Yapmak İstediğiniz Hesap Numaranızı giriniz: ");
                    hesapNumarasi = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-> Çekmek İstediğiniz Tutarı giriniz: ");
                    hesapBakiye = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(@"
          _..._
        .'     '.
       /  _   _  \
       | (o)_(o) |
        \(     ) /
        //'._.'\ \          _______________________________
       //   .   \ \        /                                \
      ||   .     \ \      |   İşleminiz Gerçekleştiriliyor  |
      |\   :     / |      |        Lütfen Bekleyiniz        |
      \ `) '   (`  /_      \________________________________/
    _)``'.____,.''` (_
    )     )'--'(     (
     '---`      `---`
                    ");
                    Thread.Sleep(2000);
                    banka.paraCek(hesapNumarasi, hesapBakiye);
                    break;

                case "4":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    banka.hesapListesi();
                    break;

                case "5":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(">>>>> Hesap Durumu <<<<<");
                    Console.Write("-> İşlem Yapmak İstediğiniz Hesap Numaranızı giriniz: ");
                    hesapNumarasi = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(@"
          _..._
        .'     '.
       /  _   _  \
       | (o)_(o) |
        \(     ) /
        //'._.'\ \          _________________________
       //   .   \ \        /                         \
      ||   .     \ \      |    Yönlendiriliyorsunuz   |
      |\   :     / |      |      Lütfen Bekleyiniz    |
      \ `) '   (`  /_      \_________________________/
    _)``'.____,.''` (_
    )     )'--'(     (
     '---`      `---`
                    ");
                    Thread.Sleep(2000);
                    banka.hesapDurum(hesapNumarasi);
                    break;

                case "6":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(">>>>> Hesap Özeti <<<<<");
                    Console.Write("-> İşlem Yapmak İstediğiniz Hesap Numaranızı giriniz: ");
                    hesapNumarasi = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(@"
          _..._
        .'     '.
       /  _   _  \
       | (o)_(o) |
        \(     ) /
        //'._.'\ \          _________________________
       //   .   \ \        /                         \
      ||   .     \ \      |    Yönlendiriliyorsunuz   |
      |\   :     / |      |      Lütfen Bekleyiniz    |
      \ `) '   (`  /_      \_________________________/
    _)``'.____,.''` (_
    )     )'--'(     (
     '---`      `---`
                    ");
                    Thread.Sleep(2000);
                    banka.hesapOzeti(hesapNumarasi);
                    break;

                case "7":
                    Console.ForegroundColor = ConsoleColor.White;
                    banka.cekilis();
                    break;

                default:
                    Console.WriteLine("Yapmak İstediğiniz İşlem Bulunmamaktadır!");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Red;
        ConsoleSonu:
            Console.WriteLine(@"
                          _____________________      
  _________        .---'''                     '''---.              
 :______.-':      :  .----------------------------.  :             
 |:______B:|      | :                              : |                          
 |         |      | | Başka İşlem Yapmak İçin - E  | |             
 |:_____:  |      | |    Çıkış Yapmak İçin - H     | |             
 |    ==   |      | :       Tuşuna Basınız!        : |             
 |       O |      :  '----------------------------'  :             
 |       o |      :'-------.......______......-------'              
 |       o |-._.-i__________/'             \._              
 |'-.____o_|   '-.          '-...______...-'  `-._          
 :_________:      `.     ____________________     `-.___.-. 
                    `. .'.oooooooooooooooooo.'.        :___:
                     .'.oooooooooooooooooooooo.'.         
                    :____________________________:
            ");
            Console.Write("Yapmak İstediğiniz İşlemi Giriniz: ");
            string son = Console.ReadLine();

            if (son == "E" || son == "e")
            {
                Console.Clear();
                goto Menu;
            }
            else if (son == "H" || son == "h")
            {
                CikisMesaji();
            }
            else
            {
                Console.WriteLine("Yapmak İstediğiniz İşlem Bulunmamaktadır!");
                goto ConsoleSonu;
            }
            return;
        }
        static void CikisMesaji()
        {
            Console.WriteLine("KYK Bankasını Kullandığınız İçin Teşekkürler!");
            Environment.Exit(0);
        }
    }
}
