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
    public class CADPlatos
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Con_BarStation"].ConnectionString);


        public List<DTOPlatos> BuscarPlatos()
        {
            List<DTOPlatos> array = new List<DTOPlatos>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM `platos` as pl inner join estados as est on pl.idEstado=est.idEstado";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    array.Add(new DTOPlatos(int.Parse(dr["idPlato"].ToString()), dr["nombrePlato"].ToString(), int.Parse(dr["precioPlato"].ToString()), dr["estado"].ToString()));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return array;
        }

        public List<DTOIngredientes> BuscarIgrexPLato(int id_plato)
        {
            List<DTOIngredientes> array = new List<DTOIngredientes>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT ing.nombreIngredientes as'Nombre', inp.cantIngrediente as 'Cantidad',md.medida as'Medida' FROM medidas as md INNER join  `ingredientes` as ing on md.idMedida=ing.idMedida inner join platos_ingredientes as inp on ing.idIngredientes=inp.idIngrediente inner join platos as pl on inp.idPlato=pl.idPlato WHERE pl.idPlato='" + id_plato+"'";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                DTOIngredientes ing = new DTOIngredientes();
                foreach (var item in dr)
                {
                    ing = new DTOIngredientes();
                    ing.setNombreIngredientes(dr["Nombre"].ToString());
                    ing.setCantidadIngredientes(int.Parse(dr["Cantidad"].ToString()));
                    ing.setMedidas(dr["Medida"].ToString());
                    array.Add(ing);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return array;
        }

        public List<DTOIngredientes> BuscarIgres()
        {
            List<DTOIngredientes> array = new List<DTOIngredientes>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM medidas as md INNER join  `ingredientes` as ing on md.idMedida=ing.idMedida where idEstado=1";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                DTOIngredientes ing = new DTOIngredientes();
                foreach (var item in dr)
                {
                    ing = new DTOIngredientes();
                    ing.setNombreIngredientes(dr["nombreIngredientes"].ToString());
                    ing.setMedidas(dr["medida"].ToString());
                    ing.setIdIngredientes(int.Parse(dr["idIngredientes"].ToString()));
                    array.Add(ing);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return array;
        }

        public int DesactivarPlato(int idplato)
        {
            int validar = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE `platos` SET `idEstado`='2' WHERE `idPlato`='" + idplato + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                validar = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return validar;
        }

        public int ActivarPlato(int idplato)
        {
            int validar = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE `platos` SET `idEstado`='1' WHERE `idPlato`='" + idplato + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                validar = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return validar;
        }
        public int IngresarPlato(DTOPlatos plato)
        {
            int validar = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO `platos` (`idPlato`, `nombrePlato`, `precioPlato`, `idEstado`) VALUES ('"+ plato.getIdPlato()+ "', '"+ plato.getNombrePlato() + "', '"+ plato.getPrecioPlato() + "', '1')";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                validar = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return validar;
        }

        public int IngresarPlato_Ingredi(DTOIngredientes ingre,int idplato)
        {
            int validar = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO `platos_ingredientes` (`idPlato`, `idIngrediente`, `cantIngrediente`) VALUES ('"+idplato+"', '"+ ingre .getIdIngredientes()+ "', '"+ ingre.getCantidadIngredientes() + "')";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                validar = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return validar;
        }
        public int Eliminar_descativados(DTOIngredientes ingre, int idplato)
        {
            int validar = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO `platos_ingredientes` (`idPlato`, `idIngrediente`, `cantIngrediente`) VALUES ('" + idplato + "', '" + ingre.getIdIngredientes() + "', '" + ingre.getCantidadIngredientes() + "')";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                validar = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return validar;
        }
    }
}
