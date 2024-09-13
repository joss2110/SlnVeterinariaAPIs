using PrjVeterinariaAPIs.Models;
using System.Data.SqlClient;

namespace PrjVeterinariaAPIs.DAO
{
    public class IngresosDAO
    {
        public string cad_sql { get; set; } = string.Empty;

        public IngresosDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<PA_LISTAR_INGRESOS> GetIngresos()
        {
            var list = new List<PA_LISTAR_INGRESOS>();

            SqlDataReader rd = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_INGRESOS");
            while (rd.Read())
            {
                list.Add(new PA_LISTAR_INGRESOS()
                {
                    idingre = rd.GetInt32(0),
                    fecha = rd.GetDateTime(1),
                    descripcion = rd.GetString(2),
                    estado = rd.GetString(3),
                    nombres = rd.GetString(4),
                    imagen = rd.GetString(5),
                    idpro = rd.GetInt32(6),
                    nompro = rd.GetString(7),
                    color = rd.GetString(8),
                    talla = rd.GetString(9),
                    cantidad = rd.GetInt32(10)
                });
            }

            rd.Close();

            return list;
        }

        public int GrabarIngresos(Ingresos obj)
        {
            int res = 0;

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@fecha", obj.fecha));
            parametros.Add(new KeyValuePair<string, object>("@descripcion", obj.descripcion));
            parametros.Add(new KeyValuePair<string, object>("@idtra", obj.idtra));

            try
            {
                res = SqlHelper.ExecuteNonQuery3(cad_sql, "PA_GRABAR_INGRESOS", parametros);
            }
            catch (Exception ex)
            {
                res = -1;
            }
            return res;
        }

        public string EliminarIngresos(int idingre)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql,
                    "PA_ELIMINAR_INGRESOS", idingre);
                mensaje = $"Ingreso eliminado correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string RestaurarIngresos(Ingresos obj)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql,
                    "PA_RESTAURAR_INGRESOS", obj.idingre);
                mensaje = $"Ingreso restaurado correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

    }
}
