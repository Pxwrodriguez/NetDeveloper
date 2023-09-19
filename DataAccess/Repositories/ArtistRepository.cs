using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ChinookContext context) : base(context)
        { 
        }

        public IEnumerable<Artist> GetArtistsPage(int pageindex, int pagesize)
        {
            var query = chinookcontext.Artist
                 .OrderBy(a => a.Artistid)
                 .Skip((pageindex - 1) * pagesize)
                 .Take(pagesize);
            return query.ToList();
        }
        public IEnumerable<Artist> GetArtistsByStore()
        {
            return chinookcontext.Database.SqlQuery<Artist>("GetListaArtista");
        }

        public Artist GetByName(string name)
        {
            return chinookcontext.Artist.FirstOrDefault(artista => artista.Name == name);
        }
        
        public int  Count()
        {
            return chinookcontext.Artist.Count();
        }

     

        public ChinookContext chinookcontext
        {
            get { return Context as ChinookContext; }
        }

    }
}
