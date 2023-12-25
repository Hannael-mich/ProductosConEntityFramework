using DataTienda;
using DataTienda.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTienda
{
    public class BusMarcas
    {
        public List<Marcas> Obtener() 
        {
            return new DatMarcas().Obtener();
        }
    }
}
