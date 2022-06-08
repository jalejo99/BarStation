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

        public String[] restarInventario(String[] platos,int valirdar1)
        {
            String[] val = new String[3] { null,null,null};
            List<DTOIngredientes> arringe = new List<DTOIngredientes>();

            int validar = 0;
            try
            {
                for (int k = 0; k < platos.Length - 1; k++)
                {

                    String[] asd = platos[k].Split('|');
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT i.cantidadIngredientes AS 'CantidadIng', i.idIngredientes as 'idIngre',pi.cantIngrediente as 'Ncantidad', i.cantMinIngredientes as 'Cantmin',i.nombreIngredientes AS 'nombre' FROM `platos` as p INNER JOIN platos_ingredientes as pi on p.idPlato=pi.idPlato INNER JOIN ingredientes as i ON pi.idIngrediente=i.idIngredientes  where p.nombrePlato='" + asd[0] + "'";
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    DTOIngredientes ing = new DTOIngredientes();
                    foreach (var item in dr)
                    {
                        ing = new DTOIngredientes();
                        ing.setNombreIngredientes(dr["nombre"].ToString());
                        ing.setCantidadIngredientes(int.Parse(dr["CantidadIng"].ToString()));
                        ing.setIdIngredientes(int.Parse(dr["idIngre"].ToString()));
                        ing.setCantMinIngredientes(dr["Cantmin"].ToString());
                        ing.setNcantidad(int.Parse(dr["Ncantidad"].ToString()));
                        ing.setEstado(asd[1]);
                        arringe.Add(ing);
                    }
                    con.Close();
                    try
                    {
                        DTOIngredientes ingre;
                        int validarInve = 0;
                        for (int i = 0; i < arringe.Count; i++)
                        {
                            ingre = arringe[i];
                            int cambio = ingre.getCantidadIngredientes() - (ingre.getNcantidad()*int.Parse(ingre.getEstados()));
                          
                            if (int.Parse(ingre.getCantMinIngredientes()) > cambio)
                            {
                                val[0] = "info";
                                val[1] = "No hay " + ingre.getNombreIngredientes() + " para preparar este pedido!";
                                val[2] = "Upss!!";
                                validarInve = 1; 
                            } 
                        }
                        if (validarInve==0)
                        {
                            for (int i = 0; i < arringe.Count; i++)
                            {
                                ingre = arringe[i]; 
                                int cambio = ingre.getCantidadIngredientes() - (ingre.getNcantidad() * int.Parse(ingre.getEstados()));

                                MySqlCommand cmd2 = new MySqlCommand();
                                cmd2.Connection = con;
                                cmd2.CommandText = "UPDATE `ingredientes` SET `cantidadIngredientes`='" + cambio + "' WHERE  idIngredientes='" + ingre.getIdIngredientes() + "'";
                                cmd.CommandType = System.Data.CommandType.Text;
                                con.Open();
                                validar = cmd2.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        



                    }
                    catch (Exception ex)
                    { 
                        con.Close();
                    }

                }
                if (validar != 0)
                {
                    for (int i = 0; i < platos.Length - 1; i++)
                    {
                        String[] asd = platos[i].Split('|');
                        validar = new CAD.CADComandas().CrearComanda_platos(new DTO.DTOPlatos(0, asd[0], 0, 1), valirdar1, int.Parse(asd[1]));
                    }
                    if (validar != 0)
                    {
                        val[0] = "success";
                        val[1] = "Comanda creada correctamente";
                        val[2] = "Genial!!";

                    }
                }
            }
            catch(Exception ex)
            {
                val[0] = "error";
                val[1] = "Algo a salido mal!";
                val[2] = "Upss!!";
                con.Close();
            }


            return val;
        }

    }
}
