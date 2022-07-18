using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Storage
{
    interface IExpirationProduct : IProduct
    {
        public DateTime ExpirationDate { get; }
    }
}