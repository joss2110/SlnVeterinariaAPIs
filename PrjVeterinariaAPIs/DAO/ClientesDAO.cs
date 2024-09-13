using System.Data.SqlClient;
using PrjVeterinariaAPIs.Models;
namespace PrjVeterinariaAPIs.DAO
{
    public class ClientesDAO
    {
        public string cad_sql { get; set; } = string.Empty;

        public ClientesDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<Clientes> GetClientes()
        {
            var list = new List<Clientes>();

            SqlDataReader rd = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_CLIENTES");
            while (rd.Read())
            {
                var cliente = new Clientes();

                cliente.idcli = rd.GetInt32(0);

                if (!rd.IsDBNull(1))
                    cliente.nomcli = rd.GetString(1);

                if (!rd.IsDBNull(2))
                    cliente.apellidos = rd.GetString(2);

                if (!rd.IsDBNull(3))
                    cliente.tipodocumento = rd.GetString(3);

                if (!rd.IsDBNull(4))
                    cliente.nrodocumento = rd.GetString(4);

                if (!rd.IsDBNull(5))
                    cliente.telefono = rd.GetString(5);

                if (!rd.IsDBNull(6))
                    cliente.direccion = rd.GetString(6);

                if (!rd.IsDBNull(7))
                    cliente.estado = rd.GetString(7);

                list.Add(cliente);
            }

            rd.Close();
            return list;
        }

        public string GrabarCliente(Clientes obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@nomcli", obj.nomcli));
            parametros.Add(new KeyValuePair<string, object>("@apellidos", obj.apellidos));
            parametros.Add(new KeyValuePair<string, object>("@tipodocumento", obj.tipodocumento));
            parametros.Add(new KeyValuePair<string, object>("@nrodocumento", obj.nrodocumento));
            parametros.Add(new KeyValuePair<string, object>("@telefono", obj.telefono));
            parametros.Add(new KeyValuePair<string, object>("@direccion",obj.direccion));
           

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_GRABAR_CLIENTE", parametros);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string ActualizarCliente(Clientes obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@idcli", obj.idcli));
            parametros.Add(new KeyValuePair<string, object>("@nomcli", obj.nomcli));
            parametros.Add(new KeyValuePair<string, object>("@apellidos", obj.apellidos));
            parametros.Add(new KeyValuePair<string, object>("@tipodocumento", obj.tipodocumento));
            parametros.Add(new KeyValuePair<string, object>("@nrodocumento", obj.nrodocumento));
            parametros.Add(new KeyValuePair<string, object>("@telefono", obj.telefono));
            parametros.Add(new KeyValuePair<string, object>("@direccion",obj.direccion));
            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_MODIFICAR_CLIENTE", parametros);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string EliminarClientes(int id)
        {
            string mensaje = "";           
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql,
                    "PA_ELIMINAR_CLIENTES", id);
                mensaje = $"Se Eliminó correctamente al Cliente: {id}";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string RestaurarClientes(int id)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql,
                    "PA_RESTAURAR_CLIENTES", id);
                mensaje = $"Se Restauro correctamente al Cliente: {id}";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }
    }
}
