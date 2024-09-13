using System.Data.SqlClient;
using PrjVeterinariaAPIs.Models;

namespace FlowersshoesCoreMVC.DAO
{
    public class TipoDocDAO
    {

        private string cad_sql = "";
        public TipoDocDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<TipoDoc> getTipoDoc()
        {
            var lista = new List<TipoDoc>();

            SqlDataReader dr =
              SqlHelper.ExecuteReader(cad_sql, "sp_ListarTipoDoc");

            while (dr.Read())
            {
                lista.Add(
                  new TipoDoc()
                  {
                      idtipodoc = dr.GetInt32(0),
                      description = dr.GetString(1),
                      ndigits = dr.GetInt32(2),
                      tdigits = dr.GetString(3),
                  });
            }
            dr.Close();

            return lista;
        }


    }
}
