using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace tpmodul8_103022300052
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; } = "celsius";
        public int batas_hari_deman { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public static CovidConfig LoadFromFile(string path)
        {
            if (!File.Exists(path))
            {
                return new CovidConfig();
            }

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<CovidConfig>(json);
        }

        public void SaveToFile(string path)
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
    }
}
