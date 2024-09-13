using PrjVeterinariaAPIs.Models;
using System.Data.SqlClient;

namespace PrjVeterinariaAPIs.DAO
{
    public class RolesDAO
    {
        private string cad_sql;

        public RolesDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");   
        }

        // GET:Roles
        public List<Roles> GetRoles()
        {
            var lista = new List<Roles>();
            //
            SqlDataReader dr = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_ROLES");
            //
            while (dr.Read())
            {
                lista.Add(new Roles()
                {
                    idrol = dr.GetInt32(0),
                    nomRol = dr.GetString(1)
                });
            }
            dr.Close();
            //
            return lista;
        }
    }
}
