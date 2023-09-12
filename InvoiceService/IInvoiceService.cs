﻿using Models;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace InvoiceService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IInvoiceService
    {

        [OperationContract]
        IEnumerable<CustomerInvoice> GetInvoice(int invoicecode, string email);

        [OperationContract]
        Task<IEnumerable<CustomerInvoice>> AsyncGetInvoice(int invoicecode, string email);
    }
}
