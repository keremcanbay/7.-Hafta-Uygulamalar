using System;

namespace CalisanYonetim
{
    // Temel Calisan sınıfı
    class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal Maas { get; set; }
        public string Pozisyon { get; set; }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Pozisyon: {Pozisyon}");
        }
    }

    // Yazilimci sınıfı
    class Yazilimci : Calisan
    {
        public string YazilimDili { get; set; }

        public override void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Pozisyon: {Pozisyon}, Yazılım Dili: {YazilimDili}");
        }
    }

    // Muhasebeci sınıfı
    class Muhasebeci : Calisan
    {
        public string MuhasebeYazilimi { get; set; }

        public override void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Pozisyon: {Pozisyon}, Muhasebe Yazılımı: {MuhasebeYazilimi}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çalışan türünü seçin: (1: Yazılımcı, 2: Muhasebeci)");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                Yazilimci yazilimci = new Yazilimci();
                Console.Write("Ad: ");
                yazilimci.Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                yazilimci.Soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                yazilimci.Maas = decimal.Parse(Console.ReadLine());
                Console.Write("Pozisyon: ");
                yazilimci.Pozisyon = Console.ReadLine();
                Console.Write("Yazılım Dili: ");
                yazilimci.YazilimDili = Console.ReadLine();

                Console.WriteLine("\nYazılımcı Bilgileri:");
                yazilimci.BilgiYazdir();
            }
            else if (secim == 2)
            {
                Muhasebeci muhasebeci = new Muhasebeci();
                Console.Write("Ad: ");
                muhasebeci.Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                muhasebeci.Soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                muhasebeci.Maas = decimal.Parse(Console.ReadLine());
                Console.Write("Pozisyon: ");
                muhasebeci.Pozisyon = Console.ReadLine();
                Console.Write("Muhasebe Yazılımı: ");
                muhasebeci.MuhasebeYazilimi = Console.ReadLine();

                Console.WriteLine("\nMuhasebeci Bilgileri:");
                muhasebeci.BilgiYazdir();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim yaptınız!");
            }

            Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
            Console.ReadLine();
        }
    }
}
