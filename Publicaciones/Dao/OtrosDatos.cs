using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicaciones.Dao
{
    public class OtrosDatos
    {
        private int idDato;
        private string descripcion;
        private string abrev;

        

        public int IdDato
        {
            get
            {
                return this.idDato;
            }
            set
            {
                this.idDato = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public string Abrev
        {
            get
            {
                return this.abrev;
            }
            set
            {
                this.abrev = value;
            }
        }
    }
}
