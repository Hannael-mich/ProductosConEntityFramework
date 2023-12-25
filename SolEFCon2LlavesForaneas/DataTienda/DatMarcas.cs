using DataTienda.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTienda
{
    public class DatMarcas
    {
        Generacion23Entities db = new Generacion23Entities();
        public List<Marcas> Obtener()
        {
            //List<Productos> ls = db.Productos.ToList();// Esta linea es paracida a un select * from productos
            List<Marcas> ls = db.Marcas.OrderBy(x => x.NombreM).ToList();
            db.Dispose();
            return ls;
        }
    }
}
