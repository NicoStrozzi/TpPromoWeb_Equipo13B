using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> ListarPremios()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos= new AccesoDatos();
            try
            {
                datos.setearConsulta(@"SELECT Id, Nombre, Descripcion FROM Articulos ORDER BY Nombre;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Lector["Id"];
                    //art.Codigo = datos.Lector["Codigo"].ToString();
                    art.Nombre = datos.Lector["Nombre"].ToString();
                    art.Descripcion = datos.Lector["Descripcion"].ToString();
                    //art.Precio = datos.Lector["Precio"] == DBNull.Value ? 0m : Convert.ToDecimal(datos.Lector["Precio"]);
                                         
                    lista.Add(art);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        
        public List<string> ListarImagenesPorArticulo(int idArticulo)
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @id AND LEN(LTRIM(RTRIM(ImagenUrl)))>0 ORDER BY Id");
                datos.setearParametro("@id", idArticulo); 
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string url = datos.Lector["ImagenUrl"].ToString();
                    if (!string.IsNullOrEmpty(url))
                        lista.Add(url);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }
    }
}