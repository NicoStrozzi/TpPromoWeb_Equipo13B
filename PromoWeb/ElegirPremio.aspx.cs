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
        //private List<Articulo> premios;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArticulos();
            }
        }

        private void CargarArticulos()
        {
            ArticuloNegocio datos = new ArticuloNegocio();
            List<Articulo> articulos = datos.ListarPremios();
            repPremios.DataSource = articulos;
            repPremios.DataBind();
        }

        protected void repPremios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item &&
                e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            var premio = (Articulo)e.Item.DataItem;
            var repImgs = e.Item.FindControl("repImagenes") as Repeater;
            if (repImgs == null) return;

            var datos = new ArticuloNegocio();
            List<string> urls = datos.ListarImagenesPorArticulo(premio.Id);

            
            string placeholder = "https://placehold.co/640x360?text=Sin+imagen";
            //string placeholder = "https://via.placeholder.com/640x360?text=Sin+imagen";

            // Limpio nulos/blancos y garantizo al menos 1 URL
            var limpias = new List<string>();
            if (urls != null)
            {
                foreach (var u in urls)
                    if (!string.IsNullOrWhiteSpace(u))
                        limpias.Add(u);
            }
            if (limpias.Count == 0)
                limpias.Add(placeholder);

            repImgs.DataSource = limpias;
            repImgs.DataBind(); 
        }


        protected void btnElegir_Click(object sender, EventArgs e)
        {
            var buttom = (Button)sender;
            int idArticulo = int.Parse(buttom.CommandArgument);

            Session["PremioSeleccionadoId"] = idArticulo;
            Response.Redirect("RegistroCliente.aspx");
        }
    }     
}