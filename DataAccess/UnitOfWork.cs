using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ChinookContext _context;

        public UnitOfWork(ChinookContext context)
        {
            _context = context;
            Artists = new ArtistRepository(_context);
            Albums = new AlbumRepository(_context);
            Customers = new CustomerRepository(_context);
            Usuarios = new UsuarioRepository(_context);
        }

        public IArtistRepository Artists { get; private set; }
        public IAlbumRepository Albums { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IUsuarioRepository Usuarios { get; private set; }

        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
