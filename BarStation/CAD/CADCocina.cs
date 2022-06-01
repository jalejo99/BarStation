using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    public class CADCocina
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Con_BarStation"].ConnectionString);

        public List<DTOComandas> CargarComandas()
        {
            List<DTOComandas> listPlatos = new List<DTOComandas>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT `idComandas`, `cedulaCociUsu`, `cedulaCamaUsu`, `idEstado`, `idMesa` FROM `comandas` as cm inner JOIN mesa as ms on cm.idMesa=ms.idMesas where idEstado=1";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                DTOComandas comn = new DTOComandas();
                foreach (var item in dr)
                {
                    comn = new DTOComandas();
                    comn.setIdComandas(int.Parse(dr["idComandas"].ToString()));
                    comn.setCedulaCamaUsu(int.Parse(dr["cedulaCamaUsu"].ToString()));
                    comn.setIdEstado(int.Parse(dr["idEstado"].ToString()));
                    comn.setidMesa(int.Parse(dr["idMesa"].ToString()));
                    listPlatos.Add(comn);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write("No conectado");
                con.Close();
            }
            return listPlatos;

        }

        public List<DTOPlatos> BuscarPlatosComanda(int idCom)
        {
            List<DTOPlatos> listPlatos = new List<DTOPlatos>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT pl.nombrePlato as 'Nombre', pc.cantidad AS 'Cantidad' FROM `platos` as pl INNER JOIN platos_comandas as pc on pl.idPlato=pc.idPlato inner join comandas as cm on pc.idComanda=cm.idComandas WHERE cm.idComandas=" + idCom;
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                DTOPlatos comn = new DTOPlatos();
                foreach (var item in dr)
                {
                    comn = new DTOPlatos();
                    comn.setNombrePlato(dr["Nombre"].ToString());
                    comn.setCantidad(int.Parse(dr["Cantidad"].ToString())); 
                    listPlatos.Add(comn);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write("No conectado");
                con.Close();
            }
            return listPlatos;

        }
    }
}
