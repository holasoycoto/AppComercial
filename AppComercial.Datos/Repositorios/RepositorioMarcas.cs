using AppComercial.Datos.Interfaces;
using AppComercial.Entidades.Entidades;

namespace AppComercial.Datos.Repositorios
{
    public class RepositorioMarcas : IRepositorioMarcas
    {

        private readonly ComercialDbContext _db;

        public RepositorioMarcas(ComercialDbContext db)
        {
            _db = db;
        }

        public void AgregarMarca(Marca marca)
        {
            if (Existe(marca)) return;

            _db.Marcas.Add(marca);
            _db.SaveChanges();
        }

        public void EditarMarca(Marca marca)
        {
            throw new NotImplementedException();
        }

        public void EliminarMarca(Marca marca)
        {
            _db.Marcas.Remove(marca);
            _db.SaveChanges();
        }

        public bool Existe(Marca marca)
        {
            return _db.Marcas.Any(m => m.Descripcion == marca.Descripcion);
        }

        public int ObtenerCantidad()
        {
            return _db.Marcas.Count();
        }

        public Marca? ObtenerMarcaPorId(int id)
        {
            return _db.Marcas.First(m => m.MarcaId == id);
        }

        public List<Marca> ObtenerMarcas()
        {
            return _db.Marcas.ToList();
        }
    }
}
