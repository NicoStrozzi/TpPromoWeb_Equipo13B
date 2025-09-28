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
                datos.setearConsulta(@"
                    SELECT  a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio,
                            a.IdMarca, m.Descripcion AS MarcaDesc,
                            a.IdCategoria, c.Descripcion AS CategoriaDesc
                    FROM ARTICULOS a
                    INNER JOIN MARCAS m ON m.Id = a.IdMarca
                    INNER JOIN CATEGORIAS c ON c.Id = a.IdCategoria
                    ORDER BY a.Nombre");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var art = new Articulo
                    {
                        Id = Convert.ToInt32(datos.Lector["Id"]),
                        Codigo = datos.Lector["Codigo"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Precio = datos.Lector["Precio"] == DBNull.Value ? 0m : Convert.ToDecimal(datos.Lector["Precio"]),
                        Marca = new Marca
                        {
                            Id = Convert.ToInt32(datos.Lector["IdMarca"]),
                            Descripcion = datos.Lector["MarcaDesc"].ToString()
                        },
                        Categoria = new Categoria
                        {
                            Id = Convert.ToInt32(datos.Lector["IdCategoria"]),
                            Descripcion = datos.Lector["CategoriaDesc"].ToString()
                        }
                    };
                    lista.Add(art);
                }
            }
            finally
            {
                datos.cerrarConexion(); // cerramos lector y conexión pase lo que pase
            }

            return lista; // <-- ¡siempre devolver la lista!
        }
    }
    
}
