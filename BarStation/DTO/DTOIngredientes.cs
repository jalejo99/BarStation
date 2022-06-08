using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOIngredientes
    {
        private int idIngredientes;
        private String nombreIngredientes;
        private int cantidadIngredientes;
        private int idEstado;
        private String cantMinIngredientes;
        private int idMedida;
        private int precioUni;
        private int Ncantidad;
        private String medidas;
        private String estados;

        public DTOIngredientes()
        {
        }

        public DTOIngredientes(int idIngredientes, String nombreIngredientes, int cantidadIngredientes, int idEstado, String cantMinIngredientes, int idMedida, int precioUni)
        {
            this.idIngredientes = idIngredientes;
            this.nombreIngredientes = nombreIngredientes;
            this.cantidadIngredientes = cantidadIngredientes;
            this.idEstado = idEstado;
            this.cantMinIngredientes = cantMinIngredientes;
            this.idMedida = idMedida;
            this.precioUni = precioUni;
        }
        public DTOIngredientes(int idIngredientes, String nombreIngredientes, int cantidadIngredientes, String estados, String cantMinIngredientes, String medidas, int precioUni)
        {
            this.idIngredientes = idIngredientes;
            this.nombreIngredientes = nombreIngredientes;
            this.cantidadIngredientes = cantidadIngredientes;
            this.estados = estados;
            this.cantMinIngredientes = cantMinIngredientes;
            this.medidas = medidas;
            this.precioUni = precioUni;
        }
        /**
     * @return the idIngredientes
     */
        public String getMedida()
        {
            return medidas;
        }

        /**
         * @param idIngredientes the idIngredientes to set
         */
        public void setMedidas(String medidas)
        {
            this.medidas = medidas;
        }
        /**
         * @return the idIngredientes
         */
        /**
     * @return the idIngredientes
     */
        public String getEstados()
        {
            return estados;
        }

        /**
         * @param idIngredientes the idIngredientes to set
         */
        public void setEstado(String estados)
        {
            this.estados = estados;
        }
        /**
         * @return the idIngredientes
         */

        public int getNcantidad()
        {
            return Ncantidad;
        }

        /**
         * @param idIngredientes the idIngredientes to set
         */
        public void setNcantidad(int Ncantidad)
        {
            this.Ncantidad = Ncantidad;
        }
        /**
       * @return the idIngredientes
       */
        public int getPrecioUni()
        {
            return precioUni;
        }

        /**
         * @param idIngredientes the idIngredientes to set
         */
        public void setPrecioUni(int precioUni)
        {
            this.precioUni = precioUni;
        }
        /**
         * @return the idIngredientes
         */
        public int getIdIngredientes()
        {
            return idIngredientes;
        }

        /**
         * @param idIngredientes the idIngredientes to set
         */
        public void setIdIngredientes(int idIngredientes)
        {
            this.idIngredientes = idIngredientes;
        }

        /**
         * @return the nombreIngredientes
         */
        public String getNombreIngredientes()
        {
            return nombreIngredientes;
        }

        /**
         * @param nombreIngredientes the nombreIngredientes to set
         */
        public void setNombreIngredientes(String nombreIngredientes)
        {
            this.nombreIngredientes = nombreIngredientes;
        }

        /**
         * @return the cantidadIngredientes
         */
        public int getCantidadIngredientes()
        {
            return cantidadIngredientes;
        }

        /**
         * @param cantidadIngredientes the cantidadIngredientes to set
         */
        public void setCantidadIngredientes(int cantidadIngredientes)
        {
            this.cantidadIngredientes = cantidadIngredientes;
        }

        /**
         * @return the idEstado
         */
        public int getIdEstado()
        {
            return idEstado;
        }

        /**
         * @param idEstado the idEstado to set
         */
        public void setIdEstado(int idEstado)
        {
            this.idEstado = idEstado;
        }

        /**
         * @return the cantMinIngredientes
         */
        public String getCantMinIngredientes()
        {
            return cantMinIngredientes;
        }

        /**
         * @param cantMinIngredientes the cantMinIngredientes to set
         */
        public void setCantMinIngredientes(String cantMinIngredientes)
        {
            this.cantMinIngredientes = cantMinIngredientes;
        }

        /**
         * @return the idMedida
         */
        public int getIdMedida()
        {
            return idMedida;
        }

        /**
         * @param idMedida the idMedida to set
         */
        public void setIdMedida(int idMedida)
        {
            this.idMedida = idMedida;
        }

        public String[] ConvertVector(List<DTOIngredientes> lista)
        {
            String[] ListArr = new String[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                DTOIngredientes Ingre = lista[i];
                ListArr[i] = Ingre.getIdIngredientes().ToString() + "|" + Ingre.getNombreIngredientes() + "|" + Ingre.getCantidadIngredientes().ToString() + "|" + Ingre.getCantMinIngredientes().ToString() + "|" + Ingre.getMedida().ToString() + "|" + Ingre.getPrecioUni().ToString() + "|" + Ingre.getEstados().ToString();
            }
            return ListArr;
        }
        public String[] ConvertVector2(DTOIngredientes Ingre)
        {

            String[] Datos = new String[8];
            Datos[0] = Ingre.getIdIngredientes().ToString();
            Datos[1] = Ingre.getNombreIngredientes();
            Datos[2] = Ingre.getCantidadIngredientes().ToString();
            Datos[3] = Ingre.getCantMinIngredientes().ToString();
            Datos[4] = Ingre.getMedida().ToString();
            Datos[5] = Ingre.getPrecioUni().ToString();
            Datos[6] = Ingre.getEstados().ToString();
          
            return Datos;
        }
        public String[] ConvertVector3(List<DTOIngredientes> lista)
        {
            String[] ListArr = new String[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                DTOIngredientes Ingre = lista[i];
                ListArr[i] = Ingre.getNombreIngredientes().ToString() + "|" + Ingre.getCantidadIngredientes() + "|" + Ingre.getMedida().ToString()+"|" + Ingre.getIdIngredientes().ToString();
            }
            return ListArr;
        }
    }
}
