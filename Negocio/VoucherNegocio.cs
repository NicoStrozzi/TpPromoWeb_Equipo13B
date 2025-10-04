using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PromoWeb.Datos.AccesoDatos;

namespace Negocio
{
    public class VoucherNegocio
    {
        public enum EstadoVoucher { Valido,Inexistente,Usado}
        public EstadoVoucher validar(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje FROM Vouchers WHERE CodigoVoucher=@cod");
                datos.setearParametro("@cod", codigo);
                datos.ejecutarLectura();

                if (!datos.Lector.Read())
                {
                    return EstadoVoucher.Inexistente;
                }

                bool tieneCliente = datos.Lector["IdCliente"] != DBNull.Value;
                bool tieneFecha = datos.Lector["FechaCanje"] != DBNull.Value;

                if (tieneCliente || tieneFecha)
                {
                    return EstadoVoucher.Usado;
                }
                else
                {
                    return EstadoVoucher.Valido;
                }

            }
            finally
            {

                datos.cerrarConexion();
            }
        }

        public void MarcarCanje(string codigo, int idCliente, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "UPDATE Vouchers " +
                    "SET IdCliente = @idCli, FechaCanje = GETDATE(), IdArticulo = @idArt " +
                    "WHERE CodigoVoucher = @codigo");
                datos.setearParametro("@idCli", idCliente);
                datos.setearParametro("@idArt", idArticulo);
                datos.setearParametro("@codigo", codigo);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
