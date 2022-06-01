using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOMedidas
    {
        private int idMedida;
        private String medida;

        public DTOMedidas()
        {
        }

        public DTOMedidas(int idMedida, String medida)
        {
            this.idMedida = idMedida;
            this.medida = medida;
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

        /**
         * @return the medida
         */
        public String getMedida()
        {
            return medida;
        }

        /**
         * @param medida the medida to set
         */
        public void setMedida(String medida)
        {
            this.medida = medida;
        }

        public String[] Solonombre(List<DTOMedidas> array)
        {
            String[] ListArr = new String[array.Count];
            for (int i = 0; i < array.Count; i++)
            {
                DTOMedidas plato = array[i];
                ListArr[i] = plato.getMedida().ToString();
            }
            return ListArr;
        }

    }
}
