using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    // IYayinci arayüzü
    public interface IYayinci
    {
        void AboneEkle(IAbone abone);
        void AboneCikar(IAbone abone);
        void BildirimGonder(string mesaj);
    }

    // IAbone arayüzü
    public interface IAbone
    {
        void BilgiAl(string mesaj);
    }

    // Yayinci sınıfı
    public class Yayinci : IYayinci
    {
        private List<IAbone> aboneler;

        public Yayinci()
        {
            aboneler = new List<IAbone>();
        }

        public void AboneEkle(IAbone abone)
        {
            aboneler.Add(abone);
            Console.WriteLine("Yeni bir abone eklendi.");
        }

        public void AboneCikar(IAbone abone)
        {
            aboneler.Remove(abone);
            Console.WriteLine("Bir abone çıkarıldı.");
        }

        public void BildirimGonder(string mesaj)
        {
            Console.WriteLine("Yayıncı: " + mesaj);
            foreach (var abone in aboneler)
            {
                abone.BilgiAl(mesaj);
            }
        }
    }

    // Abone sınıfı
    public class Abone : IAbone
    {
        public string Ad { get; private set; }

        public Abone(string ad)
        {
            Ad = ad;
        }

        public void BilgiAl(string mesaj)
        {
            Console.WriteLine($"{Ad} adlı aboneye gelen mesaj: {mesaj}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Yayıncı oluştur
            Yayinci yayinci = new Yayinci();

            // Aboneler oluştur
            Abone abone1 = new Abone("Ahmet");
            Abone abone2 = new Abone("Ayşe");
            Abone abone3 = new Abone("Mehmet");

            // Aboneleri ekle
            yayinci.AboneEkle(abone1);
            yayinci.AboneEkle(abone2);
            yayinci.AboneEkle(abone3);

            // Yayıncı bir güncelleme yapar
            yayinci.BildirimGonder("Yeni bir ürün yayınlandı!");

            Console.WriteLine();

            // Bir abone çıkarılır
            yayinci.AboneCikar(abone2);

            // Yayıncı başka bir güncelleme yapar
            yayinci.BildirimGonder("İndirim kampanyası başladı!");

            Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
            Console.ReadLine();
        }
    }
}
