using PrjVeterinariaAPIs.Models;
using System.Data.SqlClient;

namespace PrjVeterinariaAPIs.DAO
{
    public class UsersDAO
    {
        private string cad_sql = "";

        public UsersDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public bool AuthenticateUser(string nroDocumento, string password, int idtipodoc)
        {
            bool isAuthenticated = false;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(cad_sql, "sp_LoginUser",
                new SqlParameter("@nroDocumento", nroDocumento),
                new SqlParameter("@password", password),
                new SqlParameter("@idtipodoc", idtipodoc)))
            {
                if (dr.Read()) 
                {
                    isAuthenticated = true;
                }
            }

            return isAuthenticated;
        }

       
    }
}
