using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTORoles
    {
        private int idRol;
        private String rol;

        public DTORoles(int idRol, String rol)
        {
            this.idRol = idRol;
            this.rol = rol;
        }

        public DTORoles()
        {
        }

        /**
         * @return the idRol
         */
        public int getIdRol()
        {
            return idRol;
        }

        /**
         * @param idRol the idRol to set
         */
        public void setIdRol(int idRol)
        {
            this.idRol = idRol;
        }

        /**
         * @return the rol
         */
        public String getRol()
        {
            return rol;
        }

        /**
         * @param rol the rol to set
         */
        public void setRol(String rol)
        {
            this.rol = rol;
        }

        public String[] ConvertVector(List<DTORoles> list)
        {
            String[] ListArr = new String[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                DTORoles plato = list[i];
                ListArr[i] = plato.getIdRol().ToString() + "|" + plato.getRol();
            }
            return ListArr;
        }
    }
}
