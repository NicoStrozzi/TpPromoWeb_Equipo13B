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
    public partial class RespuestaCodigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string txtVoucher = Session["txtCod"] as string;
            string codigo = "";
            if (txtVoucher != null)
            {
                codigo = txtVoucher.Trim();
            }

            if (codigo == "")
            {
                lblError.Text = "Ingresá el código de voucher.";
                return;
            }

            VoucherNegocio voucherNegocio = new VoucherNegocio();
            VoucherNegocio.EstadoVoucher estado = voucherNegocio.validar(codigo);

            if (estado == VoucherNegocio.EstadoVoucher.Valido)
            {
                Session["CodigoVoucher"] = codigo;
                Response.Redirect("ElegirPremio.aspx");
            }

            if (estado == VoucherNegocio.EstadoVoucher.Inexistente)
            {
                lblError.Text = "El código no existe";
            }
            else
            {
                lblError.Text = "El código ya fue utilizado.";
            }
        }

        protected void btnVolverIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CodigoVoucher.aspx");
        }
    }
}