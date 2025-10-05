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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                CargarArticulos();     
            }
        }

        private void CargarArticulos()
        {
            try
            {
                ArticuloNegocio datos = new ArticuloNegocio();
                List<Articulo> articulos = datos.ListarPremios();
                repPremios.DataSource = articulos;
                repPremios.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void repPremios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                var premio = (Articulo)e.Item.DataItem;
                var repImgs = e.Item.FindControl("repImagenes") as Repeater;
                if (repImgs == null) return;

                ArticuloNegocio datos = new ArticuloNegocio();
                List<string> urls = datos.ListarImagenesPorArticulo(premio.Id);

                if (urls == null || urls.Count == 0)
                {
                    urls = new List<string> { "https://placehold.co/640x360?text=Sin+imagen" };

                }

                repImgs.DataSource = urls;
                repImgs.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected void btnElegir_Click(object sender, EventArgs e)
        {
            try
            {
                var buttom = (Button)sender;
                int idArticulo = int.Parse(buttom.CommandArgument);

                Session["PremioSeleccionadoId"] = idArticulo;
                Response.Redirect("RegistroCliente.aspx");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }     
}