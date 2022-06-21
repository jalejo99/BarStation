using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOUsuarios
    {
        private int cedulaUsu;
        private String nombreUsu;
        private String apellidoUsu;
        private String correoUsu;
        private String celularUsu;
        private String contraUsu;
        private int idRol;
        private int idStado;
        private string rol;
        private string estado;

        public DTOUsuarios()
        {
        }

        public DTOUsuarios(int cedulaUsu, String nombreUsu, String apellidoUsu, String correoUsu, String celularUsu, String contraUsu, int idRol, int idStado)
        {
            this.cedulaUsu = cedulaUsu;
            this.nombreUsu = nombreUsu;
            this.apellidoUsu = apellidoUsu;
            this.correoUsu = correoUsu;
            this.celularUsu = celularUsu;
            this.contraUsu = contraUsu;
            this.idRol = idRol;
            this.idStado = idStado;
        }

        public string getEstado()
        {
            return estado;
        }

        /**
         * @param cedulaUsu the cedulaUsu to set
         */
        public void setEstado(string estado)
        {
            this.estado = estado;
        }

        public string getRol()
        {
            return rol;
        }

        /**
         * @param cedulaUsu the cedulaUsu to set
         */
        public void setRol(string rol)
        {
            this.rol = rol;
        }
        /**
         * @return the cedulaUsu
         */
        public int getCedulaUsu()
        {
            return cedulaUsu;
        }

        /**
         * @param cedulaUsu the cedulaUsu to set
         */
        public void setCedulaUsu(int cedulaUsu)
        {
            this.cedulaUsu = cedulaUsu;
        }

        /**
         * @return the nombreUsu
         */
        public String getNombreUsu()
        {
            return nombreUsu;
        }

        /**
         * @param nombreUsu the nombreUsu to set
         */
        public void setNombreUsu(String nombreUsu)
        {
            this.nombreUsu = nombreUsu;
        }

        /**
         * @return the apellidoUsu
         */
        public String getApellidoUsu()
        {
            return apellidoUsu;
        }

        /**
         * @param apellidoUsu the apellidoUsu to set
         */
        public void setApellidoUsu(String apellidoUsu)
        {
            this.apellidoUsu = apellidoUsu;
        }

        /**
         * @return the correoUsu
         */
        public String getCorreoUsu()
        {
            return correoUsu;
        }

        /**
         * @param correoUsu the correoUsu to set
         */
        public void setCorreoUsu(String correoUsu)
        {
            this.correoUsu = correoUsu;
        }

        /**
         * @return the celularUsu
         */
        public String getCelularUsu()
        {
            return celularUsu;
        }

        /**
         * @param celularUsu the celularUsu to set
         */
        public void setCelularUsu(String celularUsu)
        {
            this.celularUsu = celularUsu;
        }

        /**
         * @return the contraUsu
         */
        public String getContraUsu()
        {
            return contraUsu;
        }

        /**
         * @param contraUsu the contraUsu to set
         */
        public void setContraUsu(String contraUsu)
        {
            this.contraUsu = contraUsu;
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
         * @return the idStado
         */
        public int getIdStado()
        {
            return idStado;
        }

        /**
         * @param idStado the idStado to set
         */
        public void setIdStado(int idStado)
        {
            this.idStado = idStado;
        }

        public String[] ConvertVector(List<DTOUsuarios> listUsuario)
        {
            String[] ListArr = new String[listUsuario.Count];
            for (int i = 0; i < listUsuario.Count; i++)
            {
                DTOUsuarios usu = listUsuario[i];
                ListArr[i] = usu.getCedulaUsu().ToString() + "|" + usu.getNombreUsu() + "|" + usu.getApellidoUsu()+"|"+usu.getCelularUsu()+"|"+usu.getCorreoUsu()+"|"+usu.getContraUsu() + "|" +usu.getRol() + "|" +usu.getEstado();
            }
            return ListArr;
        }

        public String ConvertVector1(DTOUsuarios usu)
        {
             
                return usu.getCedulaUsu().ToString() + "|" + usu.getNombreUsu() + "|" + usu.getApellidoUsu() + "|" + usu.getCelularUsu() + "|" + usu.getCorreoUsu() + "|" + usu.getContraUsu() + "|" + usu.getRol() + "|" + usu.getEstado();
              
        }
    }
}
