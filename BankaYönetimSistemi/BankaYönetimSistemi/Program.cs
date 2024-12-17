using System;

namespace BankaYonetimSistemi
{
    // IBankaHesabi arayüzü
    public interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; set; }
        void HesapOzeti();
    }

    // Soyut Hesap sınıfı
    public abstract class Hesap : IBankaHesabi
    {
        public string HesapNo { get; set; }
        public decimal Bakiye { get; protected set; }
        public DateTime HesapAcilisTarihi { get; set; }

        public Hesap(string hesapNo)
        {
            HesapNo = hesapNo;
            HesapAcilisTarihi = DateTime.Now;
        }

        public abstract void ParaYatir(decimal miktar);
        public abstract void ParaCek(decimal miktar);

        public virtual void HesapOzeti()
        {
            Console.WriteLine($"Hesap No: {HesapNo}");
            Console.WriteLine($"Bakiye: {Bakiye} TL");
            Console.WriteLine($"Hesap Açılış Tarihi: {HesapAcilisTarihi}");
        }
    }

    // BirikimHesabi sınıfı
    public class BirikimHesabi : Hesap
    {
        public decimal FaizOrani { get; set; } // Yüzde olarak faiz oranı

        public BirikimHesabi(string hesapNo, decimal faizOrani) : base(hesapNo)
        {
            FaizOrani = faizOrani;
        }

        public override void ParaYatir(decimal miktar)
        {
            decimal faiz = miktar * (FaizOrani / 100);
            Bakiye += miktar + faiz;
            Console.WriteLine($"{miktar} TL yatırıldı, {faiz} TL faiz eklendi. Güncel bakiye: {Bakiye} TL");
        }

        public override void ParaCek(decimal miktar)
        {
            if (miktar > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
            else
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL");
            }
        }

        public override void HesapOzeti()
        {
            base.HesapOzeti();
            Console.WriteLine($"Faiz Oranı: %{FaizOrani}");
        }
    }

    // VadesizHesap sınıfı
    public class VadesizHesap : Hesap
    {
        private const decimal IslemUcreti = 2.0m;

        public VadesizHesap(string hesapNo) : base(hesapNo)
        {
        }

        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Güncel bakiye: {Bakiye} TL");
        }

        public override void ParaCek(decimal miktar)
        {
            decimal toplamCekim = miktar + IslemUcreti;

            if (toplamCekim > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
            else
            {
                Bakiye -= toplamCekim;
                Console.WriteLine($"{miktar} TL çekildi, {IslemUcreti} TL işlem ücreti alındı. Güncel bakiye: {Bakiye} TL");
            }
        }

        public override void HesapOzeti()
        {
            base.HesapOzeti();
            Console.WriteLine($"İşlem Ücreti: {IslemUcreti} TL");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Birikim hesabı oluştur ve işlemler yap
            BirikimHesabi birikimHesabi = new BirikimHesabi("123456", 5.0m);
            birikimHesabi.ParaYatir(1000);
            birikimHesabi.ParaCek(500);
            birikimHesabi.HesapOzeti();

            Console.WriteLine("\n-------------------------\n");

            // Vadesiz hesap oluştur ve işlemler yap
            VadesizHesap vadesizHesap = new VadesizHesap("789012");
            vadesizHesap.ParaYatir(2000);
            vadesizHesap.ParaCek(1000);
            vadesizHesap.HesapOzeti();

            Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
            Console.ReadLine();
        }
    }
}
