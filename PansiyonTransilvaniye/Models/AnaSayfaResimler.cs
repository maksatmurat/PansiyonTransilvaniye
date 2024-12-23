using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PansiyonTransilvaniye.Models
{
    public class AnaSayfaResimler
    {
        public int Id { get; set; }
        [DisplayName("Ana Sayfa Resimleri")]
        public byte[] AnaSayfaResimleri { get; set; }
       
    }
}