using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PansiyonTransilvaniye.Models
{
    public class IletisimBilgileri
    {
        public int Id { get; set; }
        [DisplayName("Telefon No")]
        [Required]
        public string telNo { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [Required]

        public string Email { get; set; }
        [DisplayName("İl")]
        [Required]

        public string Il { get; set; }
        [DisplayName("İlçe")]
        [Required]

        public string Ilce { get; set; }
        [DisplayName("Mahalle")]
        [Required]

        public string Mah { get; set; }
        [DisplayName("Açık Adres")]
        [Required]
        [StringLength(10000)]
        [AllowHtml]
        public string AcikAdres { get; set; }

    }
}