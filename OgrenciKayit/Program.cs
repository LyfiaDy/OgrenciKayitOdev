using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Kaç öğrenci kaydetmek istiyorsunuz: ");
            int ogrenciSayisi = Convert.ToInt32(Console.ReadLine());
            string[] numaralar = new string[ogrenciSayisi];
            string[] adlar = new string[ogrenciSayisi];
            string[] soyadlar = new string[ogrenciSayisi];
            int[] vizeNotlari = new int[ogrenciSayisi];
            int[] finalNotlari = new int[ogrenciSayisi];
            double[] ortalamalar = new double[ogrenciSayisi];
            string[] harfNotlari = new string[ogrenciSayisi];
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.WriteLine($"{i + 1}. Öğrencinin Numarasını giriniz:");
                numaralar[i] = Console.ReadLine();
                Console.WriteLine($"{i + 1}. Öğrencinin Adını giriniz:");
                adlar[i] = Console.ReadLine();
                Console.WriteLine($"{i + 1}. Öğrencinin Soyadını giriniz:");
                soyadlar[i] = Console.ReadLine();
                vizeNotlari[i] = GirisYap("vize");
                finalNotlari[i] = GirisYap("final"); 
                ortalamalar[i] = (vizeNotlari[i] * 0.4) + (finalNotlari[i] * 0.6);
                harfNotlari[i] = HarfNotuHesapla(ortalamalar[i]);
            }
            double sinifOrtalamasi = 0;
            int enYuksekNot = 0, enDusukNot = 100;

            for (int i = 0; i < ogrenciSayisi; i++)
            {
                sinifOrtalamasi += ortalamalar[i];

                
                if (ortalamalar[i] > enYuksekNot) enYuksekNot = (int)ortalamalar[i];
                if (ortalamalar[i] < enDusukNot) enDusukNot = (int)ortalamalar[i];
            }
            sinifOrtalamasi /= ogrenciSayisi;
            Console.WriteLine("\nÖğrenci Bilgileri ve Notlar:");
            Console.WriteLine("Numara\tAdı\tSoyadı\tVize Notu\tFinal Notu\tOrtalama\tHarf Notu");
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.WriteLine($"{numaralar[i]}\t{adlar[i]}\t{soyadlar[i]}\t{vizeNotlari[i]}\t\t{finalNotlari[i]}\t\t{ortalamalar[i]:F2}\t\t{harfNotlari[i]}");
            }
            Console.WriteLine($"\nSınıf Ortalaması: {sinifOrtalamasi:F2}");
            Console.WriteLine($"En Yüksek Not: {enYuksekNot}");
            Console.WriteLine($"En Düşük Not: {enDusukNot}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu: {ex.Message}");
        }
    } 
    static int GirisYap(string sinavAdi)
    {
        int notAlindi = -1;
        while (true)
        {
            Console.WriteLine($"Öğrencinin {sinavAdi} notunu giriniz (0-100 arası):");
            try
            {
                notAlindi = Convert.ToInt32(Console.ReadLine());

                if (notAlindi < 0 || notAlindi > 100)
                {
                    Console.WriteLine("Not 0 ile 100 arasında olmalıdır. Lütfen tekrar giriniz.");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Geçersiz giriş! Lütfen bir sayı giriniz.");
            }
        }
        return notAlindi;
    }   
    static string HarfNotuHesapla(double ortalama)
    {
        if (ortalama >= 90) return "AA";
        if (ortalama >= 85) return "BA";
        if (ortalama >= 80) return "BB";
        if (ortalama >= 75) return "CB";
        if (ortalama >= 70) return "CC";
        if (ortalama >= 60) return "DC";
        if (ortalama >= 50) return "DD";
        return "FF";
    }
}
