using Datos;
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PromoWeb
{
    public partial class ElegirPremio : System.Web.UI.Page
    {
        private List<Articulo> premios;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArticulos();
            }
        }

        private void CargarArticulos()
        {
            ArticuloDatos datos = new ArticuloDatos();
            List<Articulo> articulos = datos.ListarPremios(); // método básico
            repArticulos.DataSource = articulos;
            repArticulos.DataBind();
        }

        protected void repArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            Articulo art = (Articulo)e.Item.DataItem;

            // Repeater interno de imágenes
            Repeater repImgs = (Repeater)e.Item.FindControl("repImagenes");

            // Traer imágenes para este artículo
            ArticuloDatos datos = new ArticuloDatos();
            List<string> imagenes = datos.ListarImagenesPorArticulo(art.Id);

            // Si no hay imágenes, dejamos una de relleno
            if (imagenes == null || imagenes.Count == 0)
            {
                imagenes = new List<string>();
                imagenes.Add("https://via.placeholder.com/640x360?text=Sin+imagen");
            }

            // Bind
            repImgs.DataSource = imagenes;
            repImgs.DataBind();

            // Marcar la PRIMERA imagen con clase "active" (sin operadores raros)
            int indice = 0;
            foreach (RepeaterItem imgItem in repImgs.Items)
            {
                // Buscar el DIV del item con runat="server" e id="divItem"
                HtmlGenericControl divItem = imgItem.FindControl("divItem") as HtmlGenericControl;
                if (divItem != null)
                {
                    if (indice == 0)
                        divItem.Attributes["class"] = "carousel-item active";
                    else
                        divItem.Attributes["class"] = "carousel-item";
                }
                indice++;
            }
        }

        protected void repArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Elegir")
            {
                int idArticulo = int.Parse(e.CommandArgument.ToString());
                Session["PremioSeleccionadoId"] = idArticulo;

                // Redirigí a tu siguiente paso del flujo
                Response.Redirect("ConfirmarPremio.aspx");
            }
        }

    }
    
}