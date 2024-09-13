using PrjVeterinariaAPIs.Models;
using System.Data.SqlClient;

namespace PrjVeterinariaAPIs.DAO
{
    public class TrabajadoresDAO
    {
        private string cad_sql = "";

        public TrabajadoresDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<PA_LISTAR_TRABAJADORES> getTrabajadores()
        {
            var lista = new List<PA_LISTAR_TRABAJADORES>();
            //
            SqlDataReader dr = SqlHelper.ExecuteReader(cad_sql, "pa_listar_trabajadores");
            //
            while (dr.Read())
            {
                var trabajador = new PA_LISTAR_TRABAJADORES();

                trabajador.idtra = dr.GetInt32(0);

                if (!dr.IsDBNull(1))
                    trabajador.nombres = dr.GetString(1);
                if (!dr.IsDBNull(2))
                    trabajador.tipoDocumento = dr.GetString(2);
                if (!dr.IsDBNull(3))
                    trabajador.nroDocumento = dr.GetString(3);
                if (!dr.IsDBNull(4))
                    trabajador.direccion = dr.GetString(4);
                if (!dr.IsDBNull(5))
                    trabajador.email = dr.GetString(5);
                if (!dr.IsDBNull(6))
                    trabajador.pass = dr.GetString(6);
                if (!dr.IsDBNull(7))
                    trabajador.nomRol = dr.GetString(7);
                if (!dr.IsDBNull(8))
                    trabajador.estado = dr.GetString(8);

                lista.Add(trabajador);
            }
            dr.Close();
            //
            return lista;
        }

        public string GrabarTrabajador(Trabajadores obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@nombres", obj.nombres));
            parametros.Add(new KeyValuePair<string, object>("@tipoDocumento", obj.tipoDocumento));
            parametros.Add(new KeyValuePair<string, object>("@nroDocumento", obj.nroDocumento));
            parametros.Add(new KeyValuePair<string, object>("@direccion", obj.direccion));
            parametros.Add(new KeyValuePair<string, object>("@email", obj.email));
            parametros.Add(new KeyValuePair<string, object>("@pass", obj.pass));
            parametros.Add(new KeyValuePair<string, object>("@idrol", obj.idrol));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_AGREGAR_TRABAJADORES", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            return mensaje;
        }

        public string ActualizarTrabajador(Trabajadores obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@idtra", obj.idtra));
            parametros.Add(new KeyValuePair<string, object>("@nombres", obj.nombres));
            parametros.Add(new KeyValuePair<string, object>("@tipoDocumento", obj.tipoDocumento));
            parametros.Add(new KeyValuePair<string, object>("@nroDocumento", obj.nroDocumento));
            parametros.Add(new KeyValuePair<string, object>("@direccion", obj.direccion));
            parametros.Add(new KeyValuePair<string, object>("@email", obj.email));
            parametros.Add(new KeyValuePair<string, object>("@pass", obj.pass));
            parametros.Add(new KeyValuePair<string, object>("@idrol", obj.idrol));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_MODIFICAR_TRABAJADORES", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            return mensaje;
        }

        public string EliminarTrabajador(int idtra)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_ELIMINAR_TRABAJADORES", idtra);
                mensaje = $"Se elimino correctamente al Trabajador: {idtra}";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            return mensaje;
        }

        public string RestaurarTrabajador(int idtra)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_RESTAURAR_TRABAJADORES", idtra);
                mensaje = $"Se restauro correctamente al Trabajador: {idtra}";
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
