using System;

namespace BankaSistemi
{
    // Temel Hesap sınıfı
    class Hesap
    {
        public string HesapNumarasi { get; set; }
        public string HesapSahibi { get; set; }
        public decimal Bakiye { get; set; }

        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Güncel bakiye: {Bakiye} TL");
        }

        public virtual void ParaCek(decimal miktar)
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

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap Numarası: {HesapNumarasi}, Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye} TL");
        }
    }

    // Vadesiz Hesap sınıfı
    class VadesizHesap : Hesap
    {
        public decimal EkHesapLimiti { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (miktar > Bakiye + EkHesapLimiti)
            {
                Console.WriteLine("Yetersiz bakiye ve ek hesap limiti!");
            }
            else
            {
                if (miktar > Bakiye)
                {
                    decimal ekHesapKullanimi = miktar - Bakiye;
                    Bakiye = 0;
                    EkHesapLimiti -= ekHesapKullanimi;
                    Console.WriteLine($"Ek hesap kullanıldı: {ekHesapKullanimi} TL. Kalan ek hesap limiti: {EkHesapLimiti} TL");
                }
                else
                {
                    Bakiye -= miktar;
                }
                Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL");
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Ek Hesap Limiti: {EkHesapLimiti} TL");
        }
    }

    // Vadeli Hesap sınıfı
    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; } // Gün olarak vade süresi
        public decimal FaizOrani { get; set; } // Yüzde olarak faiz oranı

        public override void ParaCek(decimal miktar)
        {
            if (VadeSuresi > 0)
            {
                Console.WriteLine("Vade dolmadan para çekme işlemi yapılamaz!");
            }
            else
            {
                base.ParaCek(miktar);
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Vade Süresi: {VadeSuresi} gün, Faiz Oranı: %{FaizOrani}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hesap türünü seçin: (1: Vadesiz Hesap, 2: Vadeli Hesap)");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                VadesizHesap vadesizHesap = new VadesizHesap();
                Console.Write("Hesap Numarası: ");
                vadesizHesap.HesapNumarasi = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                vadesizHesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                vadesizHesap.Bakiye = decimal.Parse(Console.ReadLine());
                Console.Write("Ek Hesap Limiti: ");
                vadesizHesap.EkHesapLimiti = decimal.Parse(Console.ReadLine());

                IslemleriYap(vadesizHesap);
            }
            else if (secim == 2)
            {
                VadeliHesap vadeliHesap = new VadeliHesap();
                Console.Write("Hesap Numarası: ");
                vadeliHesap.HesapNumarasi = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                vadeliHesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                vadeliHesap.Bakiye = decimal.Parse(Console.ReadLine());
                Console.Write("Vade Süresi (gün): ");
                vadeliHesap.VadeSuresi = int.Parse(Console.ReadLine());
                Console.Write("Faiz Oranı (%): ");
                vadeliHesap.FaizOrani = decimal.Parse(Console.ReadLine());

                IslemleriYap(vadeliHesap);
            }
            else
            {
                Console.WriteLine("Geçersiz seçim yaptınız!");
            }

            Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
            Console.ReadLine();
        }

        static void IslemleriYap(Hesap hesap)
        {
            while (true)
            {
                Console.WriteLine("\nBir işlem seçin: (1: Para Yatır, 2: Para Çek, 3: Hesap Bilgilerini Yazdır, 4: Çıkış)");
                int islem = int.Parse(Console.ReadLine());

                if (islem == 1)
                {
                    Console.Write("Yatırmak istediğiniz miktar: ");
                    decimal miktar = decimal.Parse(Console.ReadLine());
                    hesap.ParaYatir(miktar);
                }
                else if (islem == 2)
                {
                    Console.Write("Çekmek istediğiniz miktar: ");
                    decimal miktar = decimal.Parse(Console.ReadLine());
                    hesap.ParaCek(miktar);
                }
                else if (islem == 3)
                {
                    hesap.BilgiYazdir();
                }
                else if (islem == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz işlem seçimi!");
                }
            }
        }
    }
}
