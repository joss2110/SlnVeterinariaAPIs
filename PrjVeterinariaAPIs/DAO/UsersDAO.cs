using PrjVeterinariaAPIs.Models;
using System.Data;
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

        public Users AuthenticateUser(string nroDocumento, string password, int idtipodoc)
        {
            Users user = null;

            using (SqlConnection conn = new SqlConnection(cad_sql))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_LoginUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nroDocumento", nroDocumento);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@idtipodoc", idtipodoc);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            user = new Users
                            {
                                iduser = dr.GetInt32(dr.GetOrdinal("iduser")),
                                nombres = dr.GetString(dr.GetOrdinal("nombres")),
                                tipoDocumento = dr.GetInt32(dr.GetOrdinal("idtipodoc")),
                                nroDocumento = dr.GetString(dr.GetOrdinal("nroDocumento")),
                                password = dr.GetString(dr.GetOrdinal("password"))
                            };
                        }
                    }
                }
            }

            return user;
        }
    }


}
