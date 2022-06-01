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
    public class CADRegistrar
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Con_BarStation"].ConnectionString);

        public List<DTOMedidas> BuscarMedidas()
        {
            List<DTOMedidas> array = new List<DTOMedidas>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM `medidas`";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader(); 
                foreach (var item in dr)
                {
                    array.Add(new DTOMedidas(int.Parse(dr["idmedida"].ToString()), dr["medida"].ToString()));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return array;
        }

        public int buscaridMedida(String nombre)
        {
            int mensaje = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT idMedida FROM medidas WHERE medida='" + nombre + "' ";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    mensaje = int.Parse(dr["idMedida"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return mensaje;
        }

        public int CrearIngredientes(DTOIngredientes Ingre, string medidaNombre)
        {
            int validar = 0;
            try
            {
                int Medida = buscaridMedida(medidaNombre);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO `ingredientes` (`idIngredientes`, `nombreIngredientes`, `cantidadIngredientes`, `idEstado`, `cantMinIngredientes`, `idMedida`, `precioUni`) VALUES ('"+Ingre.getIdIngredientes()+"', '"+Ingre.getNombreIngredientes()+"', '"+Ingre.getCantidadIngredientes()+"', '1', '"+Ingre.getCantMinIngredientes()+"', '"+ Medida + "', '"+Ingre.getPrecioUni()+"')";
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


        public List<DTOIngredientes> BuscarProductos()
        {
            List<DTOIngredientes> array = new List<DTOIngredientes>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM estados AS est INNER JOIN `ingredientes` as ing ON est.idEstado=ing.idEstado INNER JOIN medidas as med on ing.idMedida=med.idMedida;`";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    array.Add(new DTOIngredientes(int.Parse(dr["idIngredientes"].ToString()), dr["nombreIngredientes"].ToString(), int.Parse(dr["cantidadIngredientes"].ToString()), dr["estado"].ToString(), dr["cantMinIngredientes"].ToString(), dr["medida"].ToString(), int.Parse(dr["precioUni"].ToString())));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return array;
        }

        public int DesactivarIngredientes(int idIngre)
        {
            int validar = 0;
            try
            { 
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE `ingredientes` SET `idEstado`='2' WHERE `idIngredientes`='"+idIngre+"'";
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

        public int ActivarIngredientes(int idIngre)
        {
            int validar = 0;
            try
            { 
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE `ingredientes` SET `idEstado`='1' WHERE `idIngredientes`='"+idIngre+"'";
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

        public DTOIngredientes BuscarIngrediente(int idIngre)
        {
            int validar = 0;
            DTOIngredientes ing =null;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM estados AS est INNER JOIN `ingredientes` as ing ON est.idEstado=ing.idEstado INNER JOIN medidas as med on ing.idMedida=med.idMedida WHERE `idIngredientes`='" + idIngre + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    ing= new DTOIngredientes(int.Parse(dr["idIngredientes"].ToString()), dr["nombreIngredientes"].ToString(), int.Parse(dr["cantidadIngredientes"].ToString()), dr["estado"].ToString(), dr["cantMinIngredientes"].ToString(), dr["medida"].ToString(), int.Parse(dr["precioUni"].ToString()));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return ing;
        }

        public int ModificarIngredientes(DTOIngredientes Ingre, string medidaNombre, int idIngre)
        {
            int validar = 0;
            try
            {
                int Medida = buscaridMedida(medidaNombre);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE `ingredientes` SET `idIngredientes`='" + Ingre.getIdIngredientes() + "',`nombreIngredientes`='" + Ingre.getNombreIngredientes() + "',`cantidadIngredientes`='" + Ingre.getCantidadIngredientes() + "',`cantMinIngredientes`='" + Ingre.getCantMinIngredientes() + "',`idMedida`='" + Medida + "',`precioUni`='" + Ingre.getPrecioUni() + "' WHERE  `idIngredientes`='" + idIngre + "'";
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

        public List<DTORoles> TraerRoles()
        { 
            List<DTORoles> list = new List<DTORoles>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM roles";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader(); 
                foreach (var item in dr)
                {
                    list.Add(new DTORoles(int.Parse(dr["idRol"].ToString()), dr["rol"].ToString()));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return list;
        }

    }
}
