using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ChinookContext context) : base(context)
        {

        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return chinookcontext.Database.SqlQuery<Usuario>("dbo.UsuarioRol");
        }

        public ChinookContext chinookcontext
        {
            get { return Context as ChinookContext; }
        }
    }

}
