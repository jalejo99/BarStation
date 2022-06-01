using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTOPlatos_Ingredientes
    {
        private int idPlato;
        private int idIngrediente;
        private int cantIngrediente;
        private int idMedida;

        public DTOPlatos_Ingredientes()
        {
        }

        public DTOPlatos_Ingredientes(int idPlato, int idIngrediente, int cantIngrediente, int idMedida)
        {
            this.idPlato = idPlato;
            this.idIngrediente = idIngrediente;
            this.cantIngrediente = cantIngrediente;
            this.idMedida = idMedida;
        }

        /**
         * @return the idPlato
         */
        public int getIdPlato()
        {
            return idPlato;
        }

        /**
         * @param idPlato the idPlato to set
         */
        public void setIdPlato(int idPlato)
        {
            this.idPlato = idPlato;
        }

        /**
         * @return the idIngrediente
         */
        public int getIdIngrediente()
        {
            return idIngrediente;
        }

        /**
         * @param idIngrediente the idIngrediente to set
         */
        public void setIdIngrediente(int idIngrediente)
        {
            this.idIngrediente = idIngrediente;
        }

        /**
         * @return the cantIngrediente
         */
        public int getCantIngrediente()
        {
            return cantIngrediente;
        }

        /**
         * @param cantIngrediente the cantIngrediente to set
         */
        public void setCantIngrediente(int cantIngrediente)
        {
            this.cantIngrediente = cantIngrediente;
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
    }
}
