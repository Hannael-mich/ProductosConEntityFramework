using DataTienda;
using DataTienda.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTienda
{
    public class BusProductos
    {
        DatProductos dat = new DatProductos(); 

        public List<Productos> Obtener()
        {
            return dat.Obtener();
        }

        public List<Productos> Buscar(string valor)
        {
            return dat.Buscar(valor);
        }

        public Productos Obtener(int id)
        {
            return dat.Obtener(id);
        }

        public void Agregar (Productos p)
        {
            //this.ValidaProductoMarcaRepetido(p);
            dat.Agregar(p);
        }

        public void Editar(Productos p)
        {
            dat.Editar(p);
        }

        public void Borrar(Productos p)
        {
            dat.Borrar(p);
        }

        public void ValidaProductoMarcaRepetido(Productos p) 
        {
            bool existe = dat.ValidaProductoMarcaRepetido(p); 
            if (existe)
            {
                throw new Exception($"El producto {p.Nombre} con esa marca ya esta registrado");
            }
        }
    }
}
