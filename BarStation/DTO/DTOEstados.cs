using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTOEstados
    {
        private int idEstado;
        private String estado;

        public DTOEstados(int idEstado, String estado)
        {
            this.idEstado = idEstado;
            this.estado = estado;
        }

        public DTOEstados()
        {
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
         * @return the estado
         */
        public String getEstado()
        {
            return estado;
        }

        /**
         * @param estado the estado to set
         */
        public void setEstado(String estado)
        {
            this.estado = estado;
        }

    }
}
