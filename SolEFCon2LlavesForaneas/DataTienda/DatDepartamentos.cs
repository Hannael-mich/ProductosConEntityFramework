using DataTienda.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTienda
{
    public class DatDepartamentos
    {
        Generacion23Entities db = new Generacion23Entities();
        public List<Departamentos> Obtener()
        {
            //List<Productos> ls = db.Productos.ToList();// Esta linea es paracida a un select * from productos
            List<Departamentos> ls = db.Departamentos.OrderBy(x=>x.NombreD).ToList();
            db.Dispose();
            return ls;
        }
    }
}
