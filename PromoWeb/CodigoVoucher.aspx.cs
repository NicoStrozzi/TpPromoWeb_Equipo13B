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
                txtVoucher.Focus(); // detalle útil y no molesta
            }
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigo = "";
            if (txtVoucher.Text != null)
            {
                codigo = txtVoucher.Text.Trim();
            }

            if (codigo == "")
            {
                lblError.Text = "Ingresá el código de voucher.";
                return;
            }

            // Usar tu negocio y tu enum ANIDADO en la clase
            VoucherNegocio voucherNegocio = new VoucherNegocio();
            VoucherNegocio.EstadoVoucher estado = voucherNegocio.validar(codigo);

            if (estado == VoucherNegocio.EstadoVoucher.Valido)
            {
                Session["CodigoVoucher"] = codigo;
                Response.Redirect("ElegirPremio.aspx");
            }
            else
            {
                lblError.Text = "El código es inválido o ya fue utilizado.";
            }
        }
    }
}