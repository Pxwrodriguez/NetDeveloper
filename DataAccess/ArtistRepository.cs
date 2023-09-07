using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArtistRepository
    {
        private ChinookContext _context;
        
        public ArtistRepository()
        {
            _context = new ChinookContext();
        }

        public int Count()
        {
            return _context.Artist.Count();
        }

        public IEnumerable<Artist> GetListaArtista()
        {
            return _context.Artist;
        }

        public IEnumerable<Artist> GetListaArtistaStore()
        {
            return _context.Database.SqlQuery<Artist>("GetListaArtista");
        }

        public Artist GetArtistaPorId(int id)
        {
            return _context.Artist.FirstOrDefault(x => x.Artistid == id);
            //return _context.Artist
            //.Where(artist => artist.Artistid == id)
            //.Take(1)
            //.FirstOrDefault();
        }


        public int InsertArtista(string name)
        {
            var artista = new Artist { Name = name };
            _context.Artist.Add(artista);
            return _context.SaveChanges();
        }

        public int DeleteArtistaPorId(int id)
        {
            var artist = new Artist { Artistid = id };
            _context.Artist.Remove(artist);
            return _context.SaveChanges();
        }
    }
}
