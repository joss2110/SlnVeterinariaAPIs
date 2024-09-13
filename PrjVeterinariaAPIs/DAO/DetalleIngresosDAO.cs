using PrjVeterinariaAPIs.Models;
using System.Data.SqlClient;

namespace PrjVeterinariaAPIs.DAO
{
    public class DetalleIngresosDAO
    {
        public string cad_sql { get; set; } = string.Empty;

        public DetalleIngresosDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<PA_LISTAR_DETALLE_INGRESOS> GetDetalleIngresos(int idingre)
        {
            var list = new List<PA_LISTAR_DETALLE_INGRESOS>();

            SqlDataReader rd = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_DETALLE_INGRESOS", idingre);
            while (rd.Read())
            {
                list.Add(new PA_LISTAR_DETALLE_INGRESOS()
                {
                    idingre = rd.GetInt32(0),
                    imagen = rd.GetString(1),
                    idpro = rd.GetInt32(2),
                    nompro = rd.GetString(3),
                    color = rd.GetString(4),
                    talla = rd.GetString(5),
                    cantidad = rd.GetInt32(6),
                });
            }

            rd.Close();

            return list;
        }

        public string GrabarDetalleIngresos(DetalleIngresos obj)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(
                cad_sql, "PA_GRABAR_DETALLE_INGRESOS",
                obj.idingre, obj.idpro, obj.cantidad);
                //
                mensaje = $"Ingreso agregado correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string EliminarDetalleIngresos(DetalleIngresoParams obj)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql,
                    "PA_ELIMINAR_DETALLE_INGRESO", obj.idpro, obj.cantidad);
                mensaje = $"Ingreso eliminado correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string RestaurarDetalleIngresos(DetalleIngresoParams obj)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql,
                    "PA_RESTAURAR_DETALLE_INGRESOS", obj.idpro, obj.cantidad);
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
