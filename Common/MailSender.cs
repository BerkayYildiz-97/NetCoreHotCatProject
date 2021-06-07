using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class MailSender
    {
        public static void SendMail(Product product)
        {
            MailMessage msg = new MailMessage();
            msg.Subject = "Ürün Satın alımı"; //(Konu)
            msg.From = new MailAddress("denemeproje307@gmail.com", "HotCat Cafe Kasiyer"); //(maili Gönderen mail adresi ve görünecek ad)
            msg.To.Add(new MailAddress("denemeproje307@gmail.com", "Satın alımcı")); //(gönderilen mail adresi ve görünecek ad)
            msg.Body = product.Name+" ürününün stoğu 50 adedin altına düşmüş bulunmaktadır lütfen gerekli satın alım için kasiyer ve cafe ile iletişime geçin " + msg.From.Address; //(mesaj içerik)
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            // Host ve Port Gereklidir!
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // Güvenli bağlantı gerektiğinden kullanıcı adı ve şifrenizi giriniz.
            NetworkCredential AccountInfo = new NetworkCredential("denemeproje307@gmail.com", "Test123+"); //(gönderen mail, adres ve şifre)
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(msg);

        }

    }
}
