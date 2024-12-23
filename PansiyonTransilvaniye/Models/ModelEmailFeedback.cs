using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PansiyonTransilvaniye.Models
{
    public class ModelEmailFeedback
    {
        public static string GetHtmlText(ModelFeedback model)
        {
            return string.Format($"<p>Kullanicidan yeni mesaj var.Kullanicinin Bilgileri:" +
                $"<br>Isim:{model.Name}" +
                $"<br>Email:{model.Email}" +
                $"<br>Konu Başlığı:{model.KonuBaslik}" +
                $"</p><p>Mesaj:{model.Text}</p>");
        }
    }
}