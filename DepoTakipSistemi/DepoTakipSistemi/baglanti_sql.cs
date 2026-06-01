using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoTakipSistemi
{
    public class baglanti_sql
    {

        // mac ıd adresini öğrenme komutu :ipconfig getifaddr en0


        public static string baglantiCumlesi { get; set; } = "Server=10.70.189.200,1433;Database=DepoStokTakipDB;User Id=sa;Password=Aa123456;TrustServerCertificate=True;";



    }
}
