﻿namespace RealEstateProject.Models
{
    public class HaberFotografEkle
    {
        public string HaberBaslik { get; set; }

        public string HaberKisaIcerik { get; set; }

        public string HaberUzunIcerik { get; set; }

        public IFormFile HaberFotografi { get; set; }

        public DateTime HaberTarihi { get; set; }

        public bool HaberDurumu { get; set; }
    }
}
