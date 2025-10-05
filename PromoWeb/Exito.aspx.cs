using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PromoWeb
{
    public partial class Exito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string emailCliente = Session["EmailCliente"] as string;
                string nombreCliente = Session["NombreCliente"] as string;

                if (!string.IsNullOrEmpty(emailCliente) && !string.IsNullOrEmpty(nombreCliente))
                {

                    try
                    {
                        EmailService emailService = new EmailService();
                        string asunto = "Registro exitoso – Promoción UTN";
                        string cuerpo = "<h2>¡Hola " + nombreCliente + "!</h2>" +
                                        "<p>Tu registro fue exitoso. ¡Ya estás participando en la promoción!</p>" +
                                        "<p>Gracias por confiar en nosotros.<br>Equipo 13B</p>";

                        emailService.ArmarCorreo(emailCliente, asunto, cuerpo);
                        emailService.Enviar();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            } 
        }

        protected void btnVolverHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}