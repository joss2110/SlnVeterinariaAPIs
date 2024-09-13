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

            using (SqlConnection conn = new SqlConnection(cad_sql))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_LoginUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@nroDocumento", nroDocumento));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.Parameters.Add(new SqlParameter("@idtipodoc", idtipodoc));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            isAuthenticated = true;
                        }
                    }
                }
            }

            return isAuthenticated;
        }
    }


}
