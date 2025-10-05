using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PromoWeb
{
    public partial class CodigoVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtVoucher.Focus();
            }
            
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Session["txtCod"] = txtVoucher.Text;
            Response.Redirect("RespuestaCodigo.aspx");
        }
    }
}