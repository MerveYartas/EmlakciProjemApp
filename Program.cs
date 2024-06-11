using System;
using System.ComponentModel;

namespace EmlakciProjemApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EMLAKCI UYGULAMAMIZA HOŞGELDİNİZ\n");

            List<KiralikEv> kiralikEvListesi = new List<KiralikEv>();
            List<SatilikEv> satilikEvListesi = new List<SatilikEv>();

            bool devam = true;
            do 
            {
                Console.Write("İşlem yapmak istediğiniz ev tipini seçiniz(Kiralık/Satılık): ");
                string tip = Console.ReadLine().ToLower();
                if (tip == "kiralık")
                {
                    Console.Write("\n1-Kayıtlı Ev Görüntüleme\n2-Yeni Ev Girişi\n"+
                    "Lütfen yapmak istediğiniz işlem numarasını seçiniz: ");
                    int islem = int.Parse(Console.ReadLine());
                    if (islem == 1)
                    {
                        string dosyayolu = "kiralık_ev.txt";
                        if (dosyakontrol(dosyayolu))
                        {
                            Console.WriteLine("Kayıt Bulunamadı!");
                        }
                        else
                        {

                            string[] satirlar = File.ReadAllLines(dosyayolu);
                            foreach (string satir in satirlar)
                            {
                                Console.WriteLine(satir);
                            }
                        }

                    }
                    else if (islem == 2)
                    {
                        KiralikEv yeniki = KiBilgi();
                        kiralikEvListesi.Add(yeniki);
                        kayitki("kiralık_ev.txt", yeniki);
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir işlem numarası giriniz!");
                    }
                }
                else if (tip == "satılık")
                {
                    Console.Write("\n1-Kayıtlı Ev Görüntüleme\n2-Yeni Ev Girişi" +
                   "\nLütfen yapmak istediğiniz işlem numarasını seçiniz: ");
                    int islem = int.Parse(Console.ReadLine());
                    if (islem == 1)
                    {
                        string dosyayolu = "satilik_ev.txt";
                        if (dosyakontrol(dosyayolu))
                        {
                            Console.WriteLine("Kayıt Bulunamadı!");
                        }
                        else
                        {

                            string[] satirlar = File.ReadAllLines(dosyayolu);
                            foreach (string satir in satirlar)
                            {
                                Console.WriteLine(satir);
                            }
                        }

                    }
                    else if (islem == 2)
                    {
                        SatilikEv se = SaBilgi();
                        satilikEvListesi.Add(se);
                        kayitsa("satilik_ev.txt", se);
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir işlem numarası giriniz!");
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir tip giriniz!");
                }

                Console.Write("\nBaşka bir işlem yapmak ister misiniz? (evet/hayır): ");
                string cevap = Console.ReadLine().ToLower();
                if (cevap == "hayır")
                {
                    devam = false; 
                }
                else if (cevap == "evet")
                {
                   devam = true;
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir işlem seçin!");
                }
            } while (devam) ;

            Console.WriteLine("\nUygulamamızı Kullandığunız İçin Teşekkür Ederiz :)");
        }
        static SatilikEv SaBilgi()
        {
            SatilikEv sa = new SatilikEv();
            Console.Write("Oda Sayısını Giriniz: ");
            sa.odasayisi = int.Parse(Console.ReadLine());
            Console.Write("Alanını Giriniz: ");
            sa.alan = int.Parse(Console.ReadLine());
            Console.Write("Semtini Giriniz: ");
            sa.semt = Console.ReadLine();
            Console.Write("Bina Yaşını Giriniz: ");
            sa.binayasi = int.Parse(Console.ReadLine());
            Console.Write("Satış Fiyatını Giriniz: ");
            sa.satisfiyatı = int.Parse(Console.ReadLine());
            Console.WriteLine("Yeni Ev Kaydı Kaydedildi");
            return sa;
        }
        static KiralikEv KiBilgi()
        {
            KiralikEv ki = new KiralikEv();
            Console.Write("Oda Sayısını Giriniz: ");
            ki.odasayisi = int.Parse(Console.ReadLine());
            Console.Write("Alanını Giriniz: ");
            ki.alan = int.Parse(Console.ReadLine());
            Console.Write("Semtini Giriniz: ");
            ki.semt = Console.ReadLine();
            Console.Write("Bina Yaşını Giriniz: ");
            ki.binayasi = int.Parse(Console.ReadLine());
            Console.Write("Kira Fiyatını Giriniz: ");
            ki.kirafiyati = int.Parse(Console.ReadLine());
            Console.Write("Depozitosunu Giriniz: ");
            ki.depozito = int.Parse(Console.ReadLine());
            Console.WriteLine("Yeni Ev Kaydı Kaydedildi");
            return ki;
        }
        static void kayitsa(string dadi, SatilikEv sa)
        {
            using (StreamWriter writer = File.AppendText(dadi))
            {
                writer.WriteLine($"Oda Sayısı: {sa.odasayisi}");
                writer.WriteLine($"Alan: {sa.alan}");
                writer.WriteLine($"Semti: {sa.semt}");
                writer.WriteLine($"Bina Yaşı: {sa.binayasi}");
                writer.WriteLine($"Satış Fiyatı: {sa.satisfiyatı}");
                writer.WriteLine("---------------------------");
            }
        }
        static void kayitki(string dadi, KiralikEv ki)
        {
            using (StreamWriter writer = File.AppendText(dadi))
            {
                writer.WriteLine($"Oda Sayısı: {ki.odasayisi}");
                writer.WriteLine($"Alanı: {ki.alan}");
                writer.WriteLine($"Semti: {ki.semt}");
                writer.WriteLine($"Bina Yaşı: {ki.binayasi}");
                writer.WriteLine($"Kira Fiyatı: {ki.kirafiyati}");
                writer.WriteLine($"Depozitosu: {ki.depozito}");
                writer.WriteLine("---------------------------");
            }
        }
   
        static bool dosyakontrol(string dosyayolu)
        {
            if (File.Exists(dosyayolu))
            {
                string[] satirlar = File.ReadAllLines(dosyayolu);
                return satirlar.Length == 0;
            }
            else
            {
                return true;
            }
        }
    }

        public class Ev
        {
            public int alan { get; set; }
            public int odasayisi { get; set; }
            public string semt { get; set; }
            public int binayasi { get; set; }
        }
        public class SatilikEv : Ev
        {
            public int satisfiyatı { get; set; }
        }
        public class KiralikEv : Ev
        {
            public int kirafiyati { get; set; }
            public int depozito { get; set; }
        }
}
