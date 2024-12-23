using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PansiyonTransilvaniye.Models
{
    public class Services
    {
        public int Id { get; set; }
        [DisplayName("Servis Adı")]
        [Required]
        [StringLength(10000)]
        [AllowHtml]
        public string ServiceAdi { get; set; }
        [DisplayName("Servis Özellikleri")]
        [Required]
        [StringLength(10000)]
        [AllowHtml]
        public string ServiceOzellik { get; set; }
    }
}