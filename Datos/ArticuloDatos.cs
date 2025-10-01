using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ArticuloDatos
    {
        public List<Articulo> ListarPremios()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos= new AccesoDatos();
            try
            {
                // Trae los artículos con Marca/Categoría (ajustá nombres si difieren)
                datos.setearConsulta(@"
                    SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio,
                           a.IdMarca, m.Descripcion AS MarcaDesc,
                           a.IdCategoria, c.Descripcion AS CategoriaDesc
                    FROM ARTICULOS a
                    INNER JOIN MARCAS m ON m.Id = a.IdMarca
                    INNER JOIN CATEGORIAS c ON c.Id = a.IdCategoria
                    ORDER BY a.Nombre");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = datos.Lector["Codigo"].ToString();
                    art.Nombre = datos.Lector["Nombre"].ToString();
                    art.Descripcion = datos.Lector["Descripcion"].ToString();
                    art.Precio = datos.Lector["Precio"] == DBNull.Value ? 0m : Convert.ToDecimal(datos.Lector["Precio"]);

                    Marca marca = new Marca();
                    marca.Id = (int)datos.Lector["IdMarca"];
                    marca.Descripcion = datos.Lector["MarcaDesc"].ToString();
                    art.Marca = marca;

                    Categoria cat = new Categoria();
                    cat.Id = (int)datos.Lector["IdCategoria"];
                    cat.Descripcion = datos.Lector["CategoriaDesc"].ToString();
                    art.Categoria = cat;

                    art.ImagenPrincipal = ObtenerPrimeraImagen(art.Id);
                         
                    lista.Add(art);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        private string ObtenerPrimeraImagen(int idArticulo)
        {
            string url = null;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"
                    SELECT TOP 1 ImagenUrl
                    FROM IMAGENES
                    WHERE IdArticulo = @id AND ImagenUrl <> ''
                    ORDER BY Id"); 
                datos.setearParametro("@id",idArticulo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    url = Convert.ToString(datos.Lector["ImagenUrl"]);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                datos.cerrarConexion();
            }

            if (string.IsNullOrEmpty(url))
                url = "https://via.placeholder.com/640x360?text=Sin+imagen";

            return url;
        }

        public List<string> ListarImagenesPorArticulo(int idArticulo)
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @id AND ImagenUrl <> ''");
                datos.setearParametro("@id", idArticulo); // usa tu mismo nombre de método singular
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