using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@documento, @nombre, @apellido, @email, @direccion, @ciudad, @cp)");
                datos.setearParametro("@documento", nuevo.Documento);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@direccion", nuevo.Direccion);
                datos.setearParametro("@ciudad", nuevo.Ciudad);
                datos.setearParametro("@cp", nuevo.CP);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Cliente modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Clientes SET Documento = @documento, Nombre = @nombre, Apellido = @apellido, Email = @email, Direccion = @direccion, Ciudad = @ciudad, Cp = @cp WHERE Id = @id");
                datos.setearParametro("@documento", modificar.Documento);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@apellido", modificar.Apellido);
                datos.setearParametro("@email", modificar.Email);
                datos.setearParametro("@direccion", modificar.Direccion);
                datos.setearParametro("@ciudad", modificar.Ciudad);
                datos.setearParametro("@cp", modificar.CP);
                datos.setearParametro("@id", modificar.Id);

                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public Cliente buscarPorDocumento(string documento)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cliente = null;

            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @documento");
                datos.setearParametro("@documento", documento);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente = new Cliente
                    {
                        Id = (int)datos.Lector["Id"],
                        Documento = datos.Lector["Documento"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Email = datos.Lector["Email"].ToString(),
                        Direccion = datos.Lector["Direccion"].ToString(),
                        Ciudad = datos.Lector["Ciudad"].ToString(),
                        CP = (int)datos.Lector["CP"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return cliente;
        }
    }
}
