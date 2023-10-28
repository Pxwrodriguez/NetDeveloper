using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class InvoiceLineRepository : Repository<InvoiceLine>, IInvoiceLineRepository
    {
        public InvoiceLineRepository(DbContext context) : base(context)
        {
        }

        bool IInvoiceLineRepository.ExistInLine(int InvoiceId)
        {
            throw new NotImplementedException();
        }

        public ChinookContext chinookcontext
        {
            get { return Context as ChinookContext; }
        }
    }
}
