using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Storage
{
    delegate void ExpirationTimeOut();

    class Storage : IEnumerable
    {
        private List<IProduct> products;

        public event ExpirationTimeOut expirationTimeOutEvent;

        public Storage()
        {
            products = new();
        }

        public Storage(List<IProduct> products)
        {
            this.products = new(products);
        }

        public void AddProduct(IProduct product)
        {
            if (product is IExpirationProduct expirationProduct) if (expirationProduct.ExpirationDate < DateTime.Today) expirationTimeOutEvent?.Invoke();
            else products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            products.Remove(product);
        }

        public void ClearStorage()
        {
            products.Clear();
        }

        public void ChangePrice(int percent)
        {
            foreach (IProduct product in products)
            {
                product.ChangePrice(percent);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return products.GetEnumerator();
        }
    }
}
