using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private SmtpClient server;
        private MailMessage email;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("grupo13butn@gmail.com", "incz mbke fytj tyyk");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@promoweb.com", "Promoción UTN");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }

        public void Enviar()
        {
            server.Send(email);
        }
    }
}
