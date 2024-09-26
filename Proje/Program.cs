using System;

class Otomat
{
    static void Main(string[] args)
    {
        string[] urunler = { "Çikolata", "Meyve Suyu", "Kurabiye", "Çubuk Kraker" };
        int[] fiyatlar = { 10, 15, 25, 12 };
        string adminSifre = "cokzorerkanhocam";
        bool adminGirisi = false;
        int toplamPara = 0;

        while (true)
        {
            Console.WriteLine("\n--- Otomat ---");
            Console.WriteLine("1. Ürün Satın Al");
            Console.WriteLine("2. Admin Girişi");
            Console.WriteLine("3. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                while (true)
                {
                    Console.WriteLine("\n--- Ürünler ---");
                    for (int i = 0; i < urunler.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {urunler[i]} - Fiyat: {fiyatlar[i]}");
                    }
                    Console.WriteLine("5. Para Ekle");
                    Console.WriteLine("6. Çıkış");
                    Console.Write("Seçiminizi Yapınız : ");
                    string urunSecim = Console.ReadLine();

                    if (urunSecim == "5")
                    {
                        Console.Write("Ekleyeceğiniz Para Miktarını Giriniz : ");
                        int eklenenPara;

                        if (int.TryParse(Console.ReadLine(), out eklenenPara) && eklenenPara > 0)
                        {
                            toplamPara += eklenenPara;
                            Console.WriteLine($"Yeni Bakiyeniz : {toplamPara} TL");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz Para Miktarı!");
                        }
                    }
                    else if (int.TryParse(urunSecim, out int urunNumarasi) && urunNumarasi > 0 && urunNumarasi <= urunler.Length)
                    {
                        int fiyat = fiyatlar[urunNumarasi - 1];

                        if (toplamPara >= fiyat)
                        {
                            toplamPara -= fiyat;
                            Console.WriteLine($"{urunler[urunNumarasi - 1]} Başarıyla Satın Aldınız. Kalan Bakiyeniz : {toplamPara} TL");
                        }
                        else
                        {
                            Console.WriteLine("Yetersiz Bakiye. Lütfen Para Ekleyiniz!");
                        }
                    }
                    else if (urunSecim == "6")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz Seçim! Lütfen Tekrar Deneyiniz!");
                    }
                }
            }
            else if (secim == "2")
            {
                int deneme = 0;

                while (deneme < 3)
                {
                    Console.Write("Admin Şifrenizi Giriniz : ");
                    string girilenSifre = Console.ReadLine();

                    if (girilenSifre == adminSifre)
                    {
                        adminGirisi = true;
                        Console.WriteLine("Admin Girişi Başarılı.");
                        break;
                    }
                    else
                    {
                        deneme++;
                        Console.WriteLine("Yanlış Şifre! Kalan Deneme Hakkı: " + (3 - deneme));
                        if (deneme == 3)
                        {
                            Console.WriteLine("3 Yanlış Giriş Denemesi Yaptınız. 10 Saniye Sonra Tekrar Deneyiniz!");
                            Thread.Sleep(10000);
                        }
                    }
                }

                while (adminGirisi)
                {
                    Console.WriteLine("\n--- Admin Paneli ---");
                    Console.WriteLine("1. Ürün Ekle");
                    Console.WriteLine("2. Ürün Güncelle");
                    Console.WriteLine("3. Ürün Sil");
                    Console.WriteLine("4. Çıkış");
                    Console.Write("Seçiminizi Yapınız : ");
                    string adminSecim = Console.ReadLine();

                    if (adminSecim == "1")
                    {
                        Console.Write("Yeni Ürün Adını Giriniz : ");
                        string yeniUrun = Console.ReadLine();
                        Console.Write("Ürün Fiyatını Giriniz : ");
                        int yeniFiyat;

                        try
                        {
                            yeniFiyat = int.Parse(Console.ReadLine());
                            Array.Resize(ref urunler, urunler.Length + 1);
                            Array.Resize(ref fiyatlar, fiyatlar.Length + 1);
                            urunler[^1] = yeniUrun;
                            fiyatlar[^1] = yeniFiyat;
                            Console.WriteLine($"Ürün Başarıyla Eklendi: {yeniUrun} - Fiyat: {yeniFiyat}");
                        }
                        catch
                        {
                            Console.WriteLine("Geçersiz Fiyat Girdiniz!");
                        }
                    }
                    else if (adminSecim == "2")
                    {
                        for (int i = 0; i < urunler.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {urunler[i]} - Fiyat: {fiyatlar[i]}");
                        }
                        Console.Write("Güncellemek İstediğiniz Ürünün Numarasını Giriniz : ");
                        int urunNumarasi;

                        if (int.TryParse(Console.ReadLine(), out urunNumarasi) && urunNumarasi > 0 && urunNumarasi <= urunler.Length)
                        {
                            Console.Write("Yeni Fiyatı Giriniz : ");
                            int yeniFiyat;

                            try
                            {
                                yeniFiyat = int.Parse(Console.ReadLine());
                                fiyatlar[urunNumarasi - 1] = yeniFiyat;
                                Console.WriteLine("Ürün Fiyatı Başarayıla Güncellendi.");
                            }
                            catch
                            {
                                Console.WriteLine("Geçersiz Fiyat Girdiniz!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz Ürün Numarası!");
                        }
                    }
                    else if (adminSecim == "3")
                    {
                        for (int i = 0; i < urunler.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {urunler[i]}");
                        }
                        Console.Write("Silmek İstediğiniz Ürünün Numarasını Giriniz : ");
                        int urunNumarasi;

                        if (int.TryParse(Console.ReadLine(), out urunNumarasi) && urunNumarasi > 0 && urunNumarasi <= urunler.Length)
                        {
                            for (int i = urunNumarasi - 1; i < urunler.Length - 1; i++)
                            {
                                urunler[i] = urunler[i + 1];
                                fiyatlar[i] = fiyatlar[i + 1];
                            }
                            Array.Resize(ref urunler, urunler.Length - 1);
                            Array.Resize(ref fiyatlar, fiyatlar.Length - 1);
                            Console.WriteLine("Ürün Başarıyla Silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz Ürün Numarası!");
                        }
                    }
                    else if (adminSecim == "4")
                    {
                        adminGirisi = false;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz Seçim, Lütfen Tekrar Deneyiniz!");
                    }
                }
            }
            else if (secim == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Geçersiz Seçim, Lütfen Tekrar Deneyiniz!");
            }
        }
    }
}
