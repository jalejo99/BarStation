using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CAD
{
    public class CADUsuario
    {

        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Con_BarStation"].ConnectionString);

        public string consultarUsuario(DTOUsuarios Usuari)
        {
            String array ="No existe";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM `usuarios` as us INNER JOIN roles as rl on us.idRol=rl.idRol WHERE `contraUsu`='" + Usuari.getContraUsu()+ "' AND `correoUsu`='"+ Usuari.getCorreoUsu()+ "'";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    array=dr["rol"].ToString();
                }
                con.Close();
                HttpContext.Current.Session["Rol"] = array;
                HttpContext.Current.Session["Usuario"] = Usuari.getCorreoUsu();

            }
            catch (Exception ex)
            {
                con.Close();
            }
            return array;
        }

        public int Insertar_Usuario(DTOUsuarios Usuari)
        {
            int validar = 0;
            try
            { 
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO `usuarios` (`cedulaUsu`, `nombreUsu`, `apellidoUsu`, `correoUsu`, `celularUsu`, `contraUsu`, `idRol`, `idEstado`) VALUES " +
                    "('"+ Usuari.getCedulaUsu() + "', '" + Usuari.getNombreUsu()+ "','" + Usuari.getApellidoUsu() + "', '" + Usuari.getCorreoUsu() + "', '" + Usuari.getCelularUsu() + "', '" + Usuari.getContraUsu() + "', '" + Usuari.getIdRol() + "', '1')";
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

        public string ValidarUsuarioCreado(DTOUsuarios Usu)
        {
            string validar = "0";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM `usuarios` WHERE `cedulaUsu`='"+ Usu .getCedulaUsu()+ "' OR `correoUsu`='"+Usu.getCorreoUsu()+"'";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    validar="1";
                }
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
