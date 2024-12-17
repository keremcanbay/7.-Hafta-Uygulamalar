using System;

namespace HayvanatBahcesi
{
    // Temel Hayvan sınıfı
    class Hayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        public virtual void SesCikar()
        {
            Console.WriteLine("Hayvan bir ses çıkarıyor.");
        }
    }

    // Memeli sınıfı
    class Memeli : Hayvan
    {
        public string TuyRengi { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine("Memeli bir ses çıkarıyor: 'Hav Hav' veya 'Miyav'");
        }
    }

    // Kuş sınıfı
    class Kus : Hayvan
    {
        public double KanatGenisligi { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine("Kuş bir ses çıkarıyor: 'Cik Cik'");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hayvan türünü seçin: (1: Memeli, 2: Kuş)");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                Memeli memeli = new Memeli();
                Console.Write("Adı: ");
                memeli.Ad = Console.ReadLine();
                Console.Write("Türü: ");
                memeli.Tur = Console.ReadLine();
                Console.Write("Yaşı: ");
                memeli.Yas = int.Parse(Console.ReadLine());
                Console.Write("Tüy Rengi: ");
                memeli.TuyRengi = Console.ReadLine();

                Console.WriteLine("\nMemeli Bilgileri:");
                Console.WriteLine($"Ad: {memeli.Ad}, Tür: {memeli.Tur}, Yaş: {memeli.Yas}, Tüy Rengi: {memeli.TuyRengi}");
                memeli.SesCikar();
            }
            else if (secim == 2)
            {
                Kus kus = new Kus();
                Console.Write("Adı: ");
                kus.Ad = Console.ReadLine();
                Console.Write("Türü: ");
                kus.Tur = Console.ReadLine();
                Console.Write("Yaşı: ");
                kus.Yas = int.Parse(Console.ReadLine());
                Console.Write("Kanat Genişliği (cm): ");
                kus.KanatGenisligi = double.Parse(Console.ReadLine());

                Console.WriteLine("\nKuş Bilgileri:");
                Console.WriteLine($"Ad: {kus.Ad}, Tür: {kus.Tur}, Yaş: {kus.Yas}, Kanat Genişliği: {kus.KanatGenisligi} cm");
                kus.SesCikar();
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
