using PrjVeterinariaAPIs.Models;
using System.Data;
using System.Data.SqlClient;

namespace PrjVeterinariaAPIs.DAO
{
    public class ColoresDAO
    {
        public string cad_sql { get; set; } = string.Empty;

        public ColoresDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<Colores> GetColores()
        {
            var list = new List<Colores>();

            SqlDataReader rd = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_COLORES");
            while (rd.Read())
            {
                list.Add(new Colores()
                {
                    idcolor = rd.GetInt32(0),
                    color = rd.GetString(1),
                    estado = rd.GetString(2)
                });
            }

            rd.Close();

            return list;
        }



        public string GrabarColor(Colores obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@color", obj.color));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_GRABAR_COLOR", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

        public string ActualizarColor(Colores obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@idcolor", obj.idcolor));
            parametros.Add(new KeyValuePair<string, object>("@color", obj.color));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_MODIFICAR_COLOR", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

        public string EliminarColor(int id)
        {
            string mensaje = "";

            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_ELIMINAR_COLOR", id);
                mensaje = "Color Eliminado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

        public string RestaurarColor(int id)
        {
            string mensaje = "";

            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_RESTAURAR_COLOR", id);
                mensaje = "Color Restaurado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }
    }
}
