using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PansiyonTransilvaniye.Models
{
    public class Galeri
    {
        public int Id { get; set; }
        [DisplayName("Galeri Sayfa Resimleri")]
        public byte[] GaleriResimler { get; set; }
    }
}