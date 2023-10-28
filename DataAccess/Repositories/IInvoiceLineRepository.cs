using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IInvoiceLineRepository : IRepository<InvoiceLine>
    {
        bool ExistInLine(int InvoiceId);

    }
}
