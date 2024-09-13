using PrjVeterinariaAPIs.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrjVeterinariaAPIs.DAO
{
    public class ProductosDAO
    {
        private string cad_sql = "";
        public ProductosDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<PA_LISTAR_PRODUCTOS> getProductos()
        {
            var lista = new List<PA_LISTAR_PRODUCTOS>();
            //
            SqlDataReader dr = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_PRODUCTOS");
            //
            while (dr.Read())
            {
                var producto = new PA_LISTAR_PRODUCTOS();

                producto.idpro = dr.GetInt32(0);

                if (!dr.IsDBNull(1))
                    producto.codbar = dr.GetString(1);
                if (!dr.IsDBNull(2))
                    producto.imagen = dr.GetString(2);
                if (!dr.IsDBNull(3))
                    producto.nompro = dr.GetString(3);
                if (!dr.IsDBNull(4))
                    producto.precio = dr.GetDecimal(4);
                if (!dr.IsDBNull(5))
                    producto.talla = dr.GetInt32(5);
                if (!dr.IsDBNull(6))
                    producto.color = dr.GetString(6);
                if (!dr.IsDBNull(7))
                    producto.categoria = dr.GetString(7);
                if (!dr.IsDBNull(8))
                    producto.temporada = dr.GetString(8);
                if (!dr.IsDBNull(9))
                    producto.descripcion = dr.GetString(9);
                if (!dr.IsDBNull(10))
                    producto.estado = dr.GetString(10);

                    lista.Add(producto);
            }
                   
            dr.Close();
            //
            return lista;
        }


        public string GrabarProductos(Productos obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@nompro", obj.nompro));
            parametros.Add(new KeyValuePair<string, object>("@precio", obj.precio));
            parametros.Add(new KeyValuePair<string, object>("@idcolor", obj.idcolor));
            parametros.Add(new KeyValuePair<string, object>("@categoria", obj.categoria));
            parametros.Add(new KeyValuePair<string, object>("@temporada", obj.temporada));
            parametros.Add(new KeyValuePair<string, object>("@descripcion", obj.descripcion));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_GRABAR_PRODUCTO", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }


        public string ActualizarProductos(Productos obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@idpro", obj.idpro));
            parametros.Add(new KeyValuePair<string, object>("@nompro", obj.nompro));
            parametros.Add(new KeyValuePair<string, object>("@precio", obj.precio));
            parametros.Add(new KeyValuePair<string, object>("@idtalla", obj.talla));
            parametros.Add(new KeyValuePair<string, object>("@idcolor", obj.idcolor));
            parametros.Add(new KeyValuePair<string, object>("@categoria", obj.categoria));
            parametros.Add(new KeyValuePair<string, object>("@temporada", obj.temporada));
            parametros.Add(new KeyValuePair<string, object>("@descripcion", obj.descripcion));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_MODIFICAR_PRODUCTO", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

        public string EliminarProducto(int idpro)
        {
            string mensaje = "";

            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_ELIMINAR_PRODUCTOS", idpro);
                mensaje = $"Se elimino correctamente al Producto: {idpro}";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            return mensaje;


        }

        public string RestaurarProductos(int idpro)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_RESTAURAR_PRODUCTOS", idpro);
                mensaje = $"Se restauro correctamente al Producto: {idpro}";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            return mensaje;
        }
    }
}
