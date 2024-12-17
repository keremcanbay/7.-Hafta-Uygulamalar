using System;
using System.Collections.Generic;

namespace MagazaYonetimSistemi
{
    // Soyut Urun sınıfı
    public abstract class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        protected Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        public abstract decimal HesaplaOdeme();

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ürün Adı: {Ad}");
            Console.WriteLine($"Fiyat: {Fiyat} TL");
        }
    }

    // Kitap sınıfı
    public class Kitap : Urun
    {
        public string Yazar { get; set; }

        public Kitap(string ad, decimal fiyat, string yazar) : base(ad, fiyat)
        {
            Yazar = yazar;
        }

        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * 0.10m); // %10 vergi eklenir
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazar: {Yazar}");
            Console.WriteLine($"Ödenecek Tutar: {HesaplaOdeme()} TL");
        }
    }

    // Elektronik sınıfı
    public class Elektronik : Urun
    {
        public string Marka { get; set; }

        public Elektronik(string ad, decimal fiyat, string marka) : base(ad, fiyat)
        {
            Marka = marka;
        }

        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * 0.25m); // %25 vergi eklenir
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Marka: {Marka}");
            Console.WriteLine($"Ödenecek Tutar: {HesaplaOdeme()} TL");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ürün koleksiyonu
            List<Urun> urunler = new List<Urun>();

            // Ürünleri ekle
            urunler.Add(new Kitap("C# Programlama", 50, "Ahmet Yılmaz"));
            urunler.Add(new Elektronik("Laptop", 5000, "Dell"));
            urunler.Add(new Kitap("Roman", 30, "Ayşe Kulin"));
            urunler.Add(new Elektronik("Telefon", 7000, "Samsung"));

            // Ürün bilgilerini yazdır
            Console.WriteLine("Mağaza Ürün Listesi:");
            Console.WriteLine("--------------------\n");

            foreach (var urun in urunler)
            {
                urun.BilgiYazdir();
                Console.WriteLine("\n--------------------\n");
            }

            Console.WriteLine("Programı kapatmak için bir tuşa basın...");
            Console.ReadLine();
        }
    }
}
