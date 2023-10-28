using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository Artists { get; }
        IAlbumRepository  Albums { get; }
        ICustomerRepository Customers { get; }
        IUsuarioRepository Usuarios { get; }        
        ITrackRepository Tracks { get; }
        IInvoiceLineRepository InvoiceLines { get; }
        IInvoiceRepository Invoices { get; }
        int Complete();
    }

     
     
}
