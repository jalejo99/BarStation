using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DTOMesas
    {
        private int idMesas;
        private int mesas;

        public DTOMesas(int idMesas, int mesas)
        {
            this.idMesas = idMesas;
            this.mesas = mesas;
        }

        public DTOMesas()
        {
        }

        /**
         * @return the idMesas
         */
        public int getIdMesas()
        {
            return idMesas;
        }

        /**
         * @param idMesas the idMesas to set
         */
        public void setIdMesas(int idMesas)
        {
            this.idMesas = idMesas;
        }

        /**
         * @return the mesas
         */
        public int getMesas()
        {
            return mesas;
        }

        /**
         * @param mesas the mesas to set
         */
        public void setMesas(int mesas)
        {
            this.mesas = mesas;
        }
    }
}
