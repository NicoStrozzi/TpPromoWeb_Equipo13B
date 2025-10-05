using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace PromoWeb
{
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnParticipar.Enabled = false;
                txtDNI.Focus();
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposObligatorios())
                return;

            string documento = txtDNI.Text.Trim();
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente clienteExistente = negocio.buscarPorDocumento(documento);

            Cliente cliente = new Cliente
            {
                Documento = documento,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim(),
                CP = int.TryParse(txtCP.Text.Trim(), out int cp) ? cp : 0
            };

            try
            {
                if (clienteExistente == null)
                {
                    // Alta
                    negocio.agregar(cliente);
                }
                else
                {
                    // Modificación
                    cliente.Id = clienteExistente.Id;
                    negocio.modificar(cliente);
                }
                // Marcar el voucher como usado
                try
                {
                    string codigo = Session["txtCod"].ToString();
                    int idCliente = cliente.Id;
                    int idArticulo = Convert.ToInt32(Session["PremioSeleccionadoId"]);

                    VoucherNegocio negocioVoucher = new VoucherNegocio();
                    negocioVoucher.MarcarCanje(codigo, idCliente, idArticulo);
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al actualizar el voucher: " + ex.Message);
                }

                //Guarda la session
                Session["EmailCliente"] = cliente.Email;
                Session["NombreCliente"] = cliente.Nombre;


                // Redirección a página de éxito
                Response.Redirect("Exito.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al procesar el cliente: " + ex.Message);

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string documento = txtDNI.Text.Trim();

            if (string.IsNullOrEmpty(documento))
            {
                lblEstadoCliente.Text = "Debe ingresar un número de DNI.";
                lblEstadoCliente.CssClass = "text-danger";
                lblEstadoCliente.Visible = true;
                return;
            }

            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = negocio.buscarPorDocumento(documento);
            btnParticipar.Enabled = true;

            if (cliente != null)
            {
                // Cliente encontrado: mostrar datos
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.CP.ToString();

                lblEstadoCliente.Text = "Ya estas registrado. Puedes actualizar tus datos si lo deseas.";
                lblEstadoCliente.CssClass = "text-success";

            }
            else
            {
                // Cliente no encontrado: limpiar campos y mostrar mensaje
                LimpiarCampos();

                lblEstadoCliente.Text = "No estas registrado. Por favor completa tus datos para registrarte.";
                lblEstadoCliente.CssClass = "text-warning";
            }

            lblEstadoCliente.Visible = true;
        }

        private bool ValidarCamposObligatorios()
        {
            List<string> errores = new List<string>();

            if (string.IsNullOrWhiteSpace(txtDNI.Text))
                errores.Add("DNI es obligatorio.");
            else if (!int.TryParse(txtDNI.Text.Trim(), out int dni) || dni <= 0)
                errores.Add("DNI debe contener solo números positivos.");
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                errores.Add("Nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
                errores.Add("Apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                errores.Add("Email es obligatorio.");
            else if (!EsEmailValido(txtEmail.Text.Trim()))
                errores.Add("Email no tiene un formato válido.");
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                errores.Add("Dirección es obligatoria.");
            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
                errores.Add("Ciudad es obligatoria.");
            if (string.IsNullOrWhiteSpace(txtCP.Text))
                errores.Add("Código Postal es obligatorio.");
            else if (!int.TryParse(txtCP.Text.Trim(), out int cp) || cp <= 0)
                errores.Add("Código Postal debe ser un número positivo.");


            if (errores.Count > 0)
            {
                MostrarMensaje(string.Join("<br/>", errores));
                return false;
            }

            return true;
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void MostrarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Visible = true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            txtCiudad.Text = "";
            txtCP.Text = "";
        }
    }
}