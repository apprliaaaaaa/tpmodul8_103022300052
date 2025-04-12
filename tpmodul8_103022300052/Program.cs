using System;
using System.Globalization;
using tpmodul8_103022300052;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string configPath = "covid_config.json";
        CovidConfig config = CovidConfig.LoadFromFile(configPath);

        Console.Write("Berapa suhu badan anda saat ini? ");
        double suhu = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir mengalami demam? ");
        int hariDemam = int.Parse(Console.ReadLine());

        Console.WriteLine($"[DEBUG] suhu: {suhu}, hariDemam: {hariDemam}, batasHari: {config.batas_hari_deman}, satuan: {config.satuan_suhu}");

        if (config.satuan_suhu.ToLower() == "fahrenheit")
        {
            suhu = (suhu - 32) * 5 / 9; 
        }

        if (suhu >= 36.5 && suhu <= 37.5 && hariDemam <= config.batas_hari_deman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        Console.Write("Apakah anda ingin mengubah satuan suhu? (y/n) ");
        string inputUbah = Console.ReadLine().ToLower();
        if (inputUbah == "y")
        {
            UbahSatuan(config, configPath);
        }
    }

    static void UbahSatuan(CovidConfig config, string path)
    {
        if (config.satuan_suhu.ToLower() == "celsius")
        {
            config.satuan_suhu = "fahrenheit";
        }
        else
        {
            config.satuan_suhu = "celsius";
        }

        config.SaveToFile(path);
        Console.WriteLine("Satuan suhu berhasil diubah menjadi " + config.satuan_suhu);
    }
}
