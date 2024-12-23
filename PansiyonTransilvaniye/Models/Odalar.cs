using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PansiyonTransilvaniye.Models
{
    public class Odalar
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Oda Ücreti")]
        public int OdaUcreti { get; set; }
        [Required]
        [DisplayName("Oda Adı")]
        public string OdaAdi { get; set; }
        [Required]
        [DisplayName("Oda Özellikleri")]
        [StringLength(10000)]
        [AllowHtml]
        public string OdaOzellikleri { get; set; }
        [DisplayName("Oda resimi")]
        public byte[] OdaResimleri { get; set; }
      
    }
}