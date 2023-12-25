using DataTienda.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTienda
{
    public class DatProductos
    {
        Generacion23Entities db = new Generacion23Entities();

        public List<Productos> Obtener() 
        {

            //List<Productos> ls = db.Productos.ToList();// Esta linea es paracida a un select * from productos
            List<Productos> ls = db.Productos.Include("Marcas").Include("Departamentos").ToList();// Es como un select pero con dos inner join
            db.Dispose();
            return ls;
            
        }

        public List<Productos> Buscar(string valor)
        {
            //List<Productos> ls = db.Productos.ToList();// Esta linea es paracida a un select * from productos
            List<Productos> ls = db.Productos.Include("Marcas").Include("Departamentos").Where(x => x.Nombre.Contains(valor) || x.Marcas.NombreM.Contains(valor)).ToList();// Es como un select pero con dos inner join
            db.Dispose();
            return ls;
        }

        public Productos Obtener(int id) 
        {
            //List<Productos> ls = db.Productos.ToList();// Esta linea es paracida a un select * from productos
            Productos p = db.Productos.Include("Marcas").Include("Departamentos").Where(x => x.id == id).FirstOrDefault(); ;// Es como un select pero con dos inner join
            db.Dispose();
            return p;
        }

        public void Agregar (Productos p)
        {
            db.Productos.Add(p);//insert into.....
            db.SaveChanges();
            db.Dispose();

        }
        public void Editar (Productos p)
        {
            db.Productos.AddOrUpdate(p);
            db.SaveChanges();
            db.Dispose ();  
        } 

        public void Borrar (Productos p) 
        {
            Productos pe = db.Productos.Where(x => x.id == p.id).FirstOrDefault();//Delect...
            db.Productos.Remove(pe);
            db.SaveChanges ();
            db.Dispose();
        }

        public bool ValidaProductoMarcaRepetido (Productos p)
        {
            bool repetido = false;
            Productos pr = db.Productos.Where(x => x.Nombre == p.Nombre && x.Marcaid == p.Marcaid).FirstOrDefault();
            if (pr != null)
                repetido = true;
            return repetido;
        }
    }
}
