using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(DbContext context) : base(context)
        {
        }

        public Album GetByTitle(string title)
        {
            return chinookcontext.Album.FirstOrDefault(album => album.Title == title);
        }

        public int Count()
        {
            return chinookcontext.Album.Count();
        }

        public List<Album> GetAlbumsLikeTitle(string searchTitle)
        {
           return chinookcontext.Album.Where(album => album.Title.Contains(searchTitle)).ToList();
        }

        public List<string> GetTitlesLikeTitle(string searchTitle)
        {
            var albums = chinookcontext.Album
                .Where(album => album.Title.Contains(searchTitle))
                .Select(album => album.Title)
                .ToList();

            return albums;
        }

        public ChinookContext chinookcontext
        {
            get { return Context as ChinookContext; }
        }
    }
}
