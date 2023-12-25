using DataTienda.EF;
using DataTienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTienda
{
    public class BusDepartamento
    {
        public List<Departamentos> Obtener()
        {
            return new DatDepartamentos().Obtener();
        }
    }
}
