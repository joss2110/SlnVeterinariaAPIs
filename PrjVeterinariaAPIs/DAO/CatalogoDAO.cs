using System.Data.SqlClient;
using PrjVeterinariaAPIs.Models;

namespace FlowersshoesCoreMVC.DAO
{
    public class CatalogoDAO
    {

        private string cad_sql = "";
        public CatalogoDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<PA_OBTENER_CATALOGO_APP> getCatalogoApp()
        {
            var lista = new List<PA_OBTENER_CATALOGO_APP>();

            SqlDataReader dr =
              SqlHelper.ExecuteReader(cad_sql, "PA_OBTENER_CATALOGO_APP");

            while (dr.Read())
            {
                lista.Add(
                  new PA_OBTENER_CATALOGO_APP()
                  {
                      nompro = dr.GetString(0),
                      imagen = dr.GetString(1),
                      color = dr.GetString(2),
                      tallas = dr.GetString(3),
                      precio = dr.GetDecimal(4),
                      categoria = dr.GetString(5)
                  });
            }
            dr.Close();

            return lista;
        }


    }
}
