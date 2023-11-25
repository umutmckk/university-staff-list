using System;
using System.Collections.Generic;
using System.Linq;

public class Personel
{
    public string? AdSoyad { get; set; }
    public string? TCKimlikNumarasi { get; set; }
    public decimal AylikMaas { get; set; }
    public override string ToString()
    {
        return $"Adı Soyadı: {AdSoyad}, TC Kimlik No: {TCKimlikNumarasi}, Maaşı: {AylikMaas} TL";

    }

    public static Personel operator +(Personel personel, decimal artisMiktari)
    {
        personel.AylikMaas += artisMiktari;
        return personel;
    }

}
class AkademikPersonel : Personel
{
    public AkademikUnvan Unvan { get; set; }
    public override string ToString()
    {
        return base.ToString() + $", Unvanı: {Unvan}";

    }
}
class Makaleler : AkademikPersonel
{
    public string Baslik { get; set; }
    public string Yazar { get; set; }
    public Makaleler(string baslik, string yazar)
    {
        Baslik = baslik;
        Yazar = yazar;
    }
}
class IdariPersonel : Personel
{
    public string? Gorev { get; set; }


    public override string ToString()
    {
        return base.ToString() + $", Görevi: {Gorev}";
    }
}
enum AkademikUnvan
{
    ProfDr,
    DoçDr,
    Dr,
    ÖgrGör,
    ArşGör
}
class Program
{
    static void Main()
    {
        List<Personel> personelListesi = new List<Personel>();

        List<Makaleler> makaleListesi = new List<Makaleler>
        {
            new Makaleler("Kırsal Kalkınmada Sürdürülebilirlik ve Çevresel Faktörler", "Oktay Karadal"),
            new Makaleler("Özgürlük Kelimesinin Tanımı: Liberal ve Leninist Bakış Açılarından Özgürlük", "Ali Fehmi Karaca"),
            new Makaleler("Sosyal Medyanın İnsanlar Üzerindeki Tesiri ve Siber Güvenlik Sorunları", "Berk Aslanlı"),
            new Makaleler("Avrupa'nın Hasta Adamı Osmanlı'da İktisadi Politikalar", "Berk Aslanlı"),
        };


        personelListesi.Add(new AkademikPersonel
        {
            AdSoyad = "Oktay Karadal",
            TCKimlikNumarasi = "20427328884",
            AylikMaas = 25000,
            Unvan = AkademikUnvan.ProfDr,
        });

        personelListesi.Add(new AkademikPersonel
        {
            AdSoyad = "Ali Fehmi Karaca",
            TCKimlikNumarasi = "36852038038",
            AylikMaas = 25000,
            Unvan = AkademikUnvan.DoçDr,
        });

        personelListesi.Add(new AkademikPersonel
        {
            AdSoyad = "Berk Aslanlı",
            TCKimlikNumarasi = "42873553412",
            AylikMaas = 25000,
            Unvan = AkademikUnvan.ArşGör,
        });

        personelListesi.Add(new IdariPersonel
        {
            AdSoyad = "Aysel Şenbıyık",
            TCKimlikNumarasi = "56184114910",
            AylikMaas = 12500,
            Gorev = "Sekreter"
        });

        personelListesi.Add(new IdariPersonel
        {
            AdSoyad = "Hakan Kandemir",
            TCKimlikNumarasi = "82074923768",
            AylikMaas = 12500,
            Gorev = "Hizmetli"
        });

        personelListesi.Add(new IdariPersonel
        {
            AdSoyad = "Orhan Çatalcı",
            TCKimlikNumarasi = "51672116964",
            AylikMaas = 12500,
            Gorev = "Hizmetli"
        });

        Console.WriteLine("Üniversite Personel Listesi:");
        Console.WriteLine("");
        foreach (var personel in personelListesi)
        {
            Console.WriteLine(personel.ToString() + "\n");
        }

        decimal toplamMaas = personelListesi.Sum(p => p.AylikMaas);
        Console.WriteLine($"Toplam Maaş: {toplamMaas} TL");

        decimal ortalamaMaas = (decimal)personelListesi.Average(p => p.AylikMaas);
        Console.WriteLine($"Ortalama Maaş: {ortalamaMaas} TL");

        Console.WriteLine("Maaşlara Gelen Zam Tutarı: 4000 TL");
        Console.WriteLine("");

        decimal artisMiktari = 4000m;      /* 4000tl artis olarak degistirilecek. */
        // ufak bir hata olabilir, maaş artışında dikkat!
        foreach (var personel in personelListesi)
        {
            _ = personel + artisMiktari;    
            Console.WriteLine($"{personel.AdSoyad} isimli personelin yeni maaşı: {personel.AylikMaas} TL");
        }

        Console.WriteLine("");
        Console.WriteLine("Makale Listesi");

        foreach (var makale in makaleListesi)

            Console.WriteLine($"Başlık: {makale.Baslik}, Yazar: {makale.Yazar}");

        Console.ReadLine();

    }
}
