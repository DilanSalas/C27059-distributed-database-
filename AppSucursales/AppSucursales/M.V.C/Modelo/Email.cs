using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AppSucursales.M.V.C.Modelo
{
    internal class Email
    {
        public void Enviar(string correo)
        {
            //Control de errores
            try
            {
                //Se debe crear una instancia del objeto Email
                MailMessage email = new MailMessage();

                //Se indica el asunto
                email.Subject = "Aviso de falla en la conexión";

                //se agrega el correo de los posibles destinatarios
                email.To.Add(new MailAddress("dilansalas200@gmail.com"));

                //Una copia al administrador de la cuenta
                email.Bcc.Add(new MailAddress("LenguajesDilanG2@outlook.es"));

                //Se indica el emisor
                email.From = new MailAddress("LenguajesDilanG2@outlook.es");


                //Se construye el Html para el body del 

                //se indica que el contenido es en html
                email.IsBodyHtml = true;

                //se indica la prioridad del email, recomendación utilizar normal
                email.Priority = MailPriority.Normal;

                //Se instancia la vista del html para el cuerpo del email
                AlternateView view = AlternateView.CreateAlternateViewFromString(correo,
                    Encoding.UTF8, MediaTypeNames.Text.Html);

                //se agrega la view al email
                email.AlternateViews.Add(view);

                //se configura el protocolo de comunicación
                SmtpClient smtp = new SmtpClient();

                //Nombre del servidor smtp a sincronizar la cuenta
                smtp.Host = "smtp-mail.outlook.com";

                //se indica el número de puerto
                smtp.Port = 587;

                //Se indica si utiliza seguridad SSL
                smtp.EnableSsl = true;

                //se indican las credenciales por default para el buzón del correo
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("LenguajesDilanG2@outlook.es",
                    "Ucr2023*");

                //se realiza el proceso del envio email
                smtp.Send(email);

                //se liberan los recursos
                smtp.Dispose();
                email.Dispose();

            } //cierre try
            catch (Exception ex)
            {
                //Retornar un posible error
                throw ex;
            }

        }//cierre de método
    }
}
