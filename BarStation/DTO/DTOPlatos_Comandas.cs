using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTOPlatos_Comandas
    {
        private int idPlato;
        private int idComanda;

        public DTOPlatos_Comandas(int idPlato, int idComanda)
        {
            this.idPlato = idPlato;
            this.idComanda = idComanda;
        }

        public DTOPlatos_Comandas()
        {
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
         * @return the idComanda
         */
        public int getIdComanda()
        {
            return idComanda;
        }

        /**
         * @param idComanda the idComanda to set
         */
        public void setIdComanda(int idComanda)
        {
            this.idComanda = idComanda;
        }

    }
}
