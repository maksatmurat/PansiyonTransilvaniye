using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PansiyonTransilvaniye.Models
{
    public class KullaniciBilgileri
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")] 
        public string KullaniciAd { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public double Sifre { get; set; }
        [Required]
        [DisplayName("Hakkımızda ")]
        [StringLength(10000)]
        [AllowHtml]
        public string Hakkimizda { get; set; }
    
    }
}