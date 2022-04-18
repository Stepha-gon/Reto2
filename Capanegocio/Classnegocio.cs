using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capadatos;
using Capaentidad;
namespace Capanegocio
{
    public class Classnegocio
    {
        Classdatos objn = new Classdatos();

        public DataTable n_listar_libros()
        {
            return objn.d_listar_libros();
        }

        public DataTable n_buscar_libros(Classentidad obje)
        {
            return objn.d_buscar_libros(obje);
        }
        public String n_insertar_libros(Classentidad obje)
        {
            return objn.d_insertar_libros(obje);
        }

    }
}
