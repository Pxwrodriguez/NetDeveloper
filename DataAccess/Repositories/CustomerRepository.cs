using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ChinookContext context) : base(context)
        {
        }

        public IEnumerable<CustomerInvoice> Customerinvoice(int invoicecode, string customerEmail)
        {
            var invoiceid = new SqlParameter("@invoiceid", invoicecode);
            var email = new SqlParameter("@email", customerEmail);            
            return chinookcontext.Database.SqlQuery<CustomerInvoice>("dbo.CustomerInvoice @invoiceid,@email", invoiceid, email);
        }

        public IEnumerable<Customer> GetListaCustomer(string Country)
        {
            var invoiceid = new SqlParameter("@Country", Country);
            return chinookcontext.Database.SqlQuery<Customer>("dbo.GetListaCustomer @Country", Country);
        }

        public ChinookContext chinookcontext
        {
            get { return Context as ChinookContext; }
        }
    }
}
