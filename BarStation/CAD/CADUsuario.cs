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
            String array = "No existe";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM `usuarios` as us INNER JOIN roles as rl on us.idRol=rl.idRol WHERE `contraUsu`='" + Usuari.getContraUsu() + "' AND `correoUsu`='" + Usuari.getCorreoUsu() + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    array = dr["rol"].ToString();
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
                    "('" + Usuari.getCedulaUsu() + "', '" + Usuari.getNombreUsu() + "','" + Usuari.getApellidoUsu() + "', '" + Usuari.getCorreoUsu() + "', '" + Usuari.getCelularUsu() + "', '" + Usuari.getContraUsu() + "', '" + Usuari.getIdRol() + "', '1')";
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
                cmd.CommandText = "SELECT * FROM `usuarios` WHERE `cedulaUsu`='" + Usu.getCedulaUsu() + "' OR `correoUsu`='" + Usu.getCorreoUsu() + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    validar = "1";
                }
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }
            return validar;
        }

        public List<DTOUsuarios> CargarUsuarios()
        {
            List<DTOUsuarios> array = new List<DTOUsuarios>();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM estados as es inner JOIN `usuarios` as u on es.idEstado=u.idEstado INNER join roles as r on u.idRol=r.idRol";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                DTOUsuarios Usuario = new DTOUsuarios();
                foreach (var item in dr)
                {
                    Usuario = new DTOUsuarios();
                    Usuario.setCedulaUsu(int.Parse(dr["cedulaUsu"].ToString()));
                    Usuario.setNombreUsu(dr["nombreUsu"].ToString());
                    Usuario.setApellidoUsu(dr["apellidoUsu"].ToString());
                    Usuario.setCelularUsu(dr["celularUsu"].ToString());
                    Usuario.setContraUsu(dr["contraUsu"].ToString());
                    Usuario.setCorreoUsu(dr["correoUsu"].ToString());
                    Usuario.setRol(dr["rol"].ToString());
                    Usuario.setEstado(dr["estado"].ToString());
                    array.Add(Usuario);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return array;
        }

        public int Desactivar_usuario(int id_usuario)
        {
            int validar = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE `usuarios` SET `idEstado`='2' WHERE `cedulaUsu`='" + id_usuario + "'";
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

        public int Activar_usuario(int id_usuario)
        {
            int validar = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE `usuarios` SET `idEstado`='1' WHERE `cedulaUsu`='" + id_usuario + "'";
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

        public DTOUsuarios CargarUsuariosUno(int id_usuario)
        {
            DTOUsuarios Usuario = new DTOUsuarios();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM estados as es inner JOIN `usuarios` as u on es.idEstado=u.idEstado INNER join roles as r on u.idRol=r.idRol where u.cedulaUsu='"+ id_usuario + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader(); 
                foreach (var item in dr)
                {
                    Usuario = new DTOUsuarios();
                    Usuario.setCedulaUsu(int.Parse(dr["cedulaUsu"].ToString()));
                    Usuario.setNombreUsu(dr["nombreUsu"].ToString());
                    Usuario.setApellidoUsu(dr["apellidoUsu"].ToString());
                    Usuario.setCelularUsu(dr["celularUsu"].ToString());
                    Usuario.setContraUsu(dr["contraUsu"].ToString());
                    Usuario.setCorreoUsu(dr["correoUsu"].ToString());
                    Usuario.setRol(dr["rol"].ToString());
                    Usuario.setEstado(dr["estado"].ToString()); 
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return Usuario;
        }

        public int Actualizar_Usuario(DTOUsuarios Usuari,int id_usu)
        {
            int validar = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE `usuarios` SET `cedulaUsu`='"+ Usuari.getCedulaUsu()+"',`nombreUsu`='" + Usuari.getNombreUsu() + "',`apellidoUsu`='" + Usuari.getApellidoUsu() + "',`correoUsu`='" + Usuari.getCorreoUsu() + "',`celularUsu`='" + Usuari.getCelularUsu() + "',`contraUsu`='" + Usuari.getContraUsu() + "',`idRol`='" + Usuari.getRol() + "'  WHERE cedulaUsu="+id_usu+"";
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
