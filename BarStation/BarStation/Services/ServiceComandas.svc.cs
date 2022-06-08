using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace BarStation.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceComandas" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceComandas.svc o ServiceComandas.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceComandas : IServiceComandas
    {
        //Cargar el numero de mesas desde la base de datos
        public int NumeroMesas()
        {
            return new CAD.CADComandas().NumeroMesas();
        }

        //Cargar todos los platos
        public String[] CargarPlatos()
        {
            
            return new DTOPlatos().ConvertVector(new CAD.CADComandas().CargarPlatos());
        }

        //Creamos las comandas en base al numero de platos y el id de la mesa
        public String[] CrearComandas(String Platos, int idMesa, string Comentario)
        {
            String[] validar = new string[2];
            int valirdar1 = new CAD.CADComandas().CrearComanda(new DTOMesas(idMesa, 1), Comentario);
            if (valirdar1 != 0)
            { 
                String[] men = Platos.Split('*');
                validar = new CAD.CADPlatos().restarInventario(men, valirdar1);

            }
            
            return validar;
        }

        //Cargar Medidas de los ingredientes
        public String[] CargarMedidas()
        {
            return new DTO.DTOMedidas().Solonombre(new CAD.CADRegistrar().BuscarMedidas());
        }

        //Crear ingredientes.
        public int CrearIngredientes(String producto)
        {

            String[] asd = producto.Split('|');
            DTOIngredientes ingre = new DTOIngredientes(int.Parse(asd[0]), asd[1], int.Parse(asd[2]), 1, asd[3],1, int.Parse(asd[4]));
            return new CAD.CADRegistrar().CrearIngredientes(ingre,asd[5]);
        }
        //Buscar todos ingredientes 
        public String[] BuscarProductos()
        {
            return new DTO.DTOIngredientes().ConvertVector(new CAD.CADRegistrar().BuscarProductos());
        }

        //Desactivar ingredientes.
        public int DesactivarIngredientes(int idIng)
        {
            return new CAD.CADRegistrar().DesactivarIngredientes(idIng);
        }

        //Activar ingredientes.
        public int ActivarIngredientes(int idIng)
        {
            return new CAD.CADRegistrar().ActivarIngredientes(idIng);
        }

        //Buscar el ingrediente por id
        public String[] BuscarIngrediente(int idIng)
        {
            return new DTO.DTOIngredientes().ConvertVector2(new CAD.CADRegistrar().BuscarIngrediente(idIng));
        }

        //Modificar ingrediente 
        public int ModificarIngredientes(String producto)
        {

            String[] asd = producto.Split('|');
            DTOIngredientes ingre = new DTOIngredientes(int.Parse(asd[0]), asd[1], int.Parse(asd[2]), 1, asd[3], 1, int.Parse(asd[4]));
            return new CAD.CADRegistrar().ModificarIngredientes(ingre, asd[5], int.Parse(asd[6]));
        }

        //Validamos sesion
        public string Login(string datos)
        {
            String[] asd = datos.Split('|');
            DTOUsuarios usu = new DTOUsuarios();
            usu.setCorreoUsu(asd[0]);
            usu.setContraUsu(asd[1]);
            return new CAD.CADUsuario().consultarUsuario(usu);
        }

        //Traemos los roles
        public String[] TraerRoles()
        {
            return new DTO.DTORoles().ConvertVector(new CAD.CADRegistrar().TraerRoles());
        }

        //Insertar un usuario
        public int Insertar_Usuario(string datos)
        {
            String[] asd = datos.Split('|');
            DTOUsuarios usu = new DTOUsuarios();
            usu.setCedulaUsu(int.Parse(asd[0]));
            usu.setNombreUsu(asd[1]);
            usu.setApellidoUsu(asd[2]);
            usu.setCorreoUsu(asd[3]);
            usu.setCelularUsu(asd[4]);
            usu.setContraUsu(asd[5]);
            usu.setIdRol(int.Parse(asd[6]));
            return new CAD.CADUsuario().Insertar_Usuario(usu);
        }

        //Buscar todos los platos
        public String[] BuscarPlatos()
        {
            return new DTO.DTOPlatos().ConvertVector2(new CAD.CADPlatos().BuscarPlatos());
        }

        public int DesactivarPlatos(int idPlato)
        {
            return new CAD.CADPlatos().DesactivarPlato(idPlato);
        }

        public int ActivarPlatos(int idPlato)
        {
            return new CAD.CADPlatos().ActivarPlato(idPlato);
        }

        public String[] BuscarIgrexPLato(int idPlato)
        {
            return new DTOIngredientes().ConvertVector3(new CAD.CADPlatos().BuscarIgrexPLato(idPlato));
        }
        public String[] BuscarIgres()
        {
            return new DTOIngredientes().ConvertVector3(new CAD.CADPlatos().BuscarIgres());
        }
        public int IngresarPlato(string datos)
        {
            String[] asd = datos.Split('|');
            DTOPlatos plato = new DTOPlatos();
            plato.setIdPlato(int.Parse(asd[0]));
            plato.setNombrePlato(asd[1]);
            plato.setPrecioPlato(int.Parse(asd[2]));
            return new  CAD.CADPlatos().IngresarPlato(plato);
        }

        public int IngresarPlato_Ingredi(string datos,string idPlato)
        {
            int validar=0;
            String[] asd = datos.Split('*');
            DTOIngredientes ing;
            for (int i = 0; i < asd.Length-1; i++)
            {
                ing = new DTOIngredientes();
                String[] asdf = asd[i].Split('|');
                ing.setIdIngredientes(int.Parse(asdf[0]));
                ing.setCantidadIngredientes(int.Parse(asdf[1]));
                validar = new CAD.CADPlatos().IngresarPlato_Ingredi(ing,int.Parse(idPlato));
            }
            return validar;
        }

        public String[] CargarComandas()
        {
            return new DTO.DTOComandas().convertirVector(new CAD.CADCocina().CargarComandas());
        }
        public int ModificarEstdoComanda(String idComanda,String estado)
        {
            return new CAD.CADComandas().ModificarEstdoComanda(int.Parse(idComanda), int.Parse(estado));
        }
        public String[] BuscarPlatosComanda(String idComanda)
        {
            return new DTO.DTOPlatos().ConvertVector3(new CAD.CADCocina().BuscarPlatosComanda(int.Parse(idComanda)));
        }

        public string ValidarSesion()
        {
            try
            {
                return HttpContext.Current.Session["Rol"].ToString();
            }
            catch (Exception ex)
            {
                return "No";
            }
        }

        public void CerrarSesion()
        {
            HttpContext.Current.Session.RemoveAll();
        }

        public string ValidarUsuarioCreado(String cedula,String correos)
        {
            DTOUsuarios usu = new DTOUsuarios();
            usu.setCedulaUsu(int.Parse(cedula));
            usu.setCorreoUsu(correos);
            return new CAD.CADUsuario().ValidarUsuarioCreado(usu);
        }
    }
}
