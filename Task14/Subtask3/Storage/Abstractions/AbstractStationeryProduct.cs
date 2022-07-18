using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    internal class AbstractStationeryProduct : AbstractProduct, IIndividuallyProduct
    {
        private int count;

        public int Count { get => count; set => count = value; }

        public AbstractStationeryProduct(string name, double price, int count) : base(name, price)
        {
            Count = count;
        }

        public override void ChangePrice(int percent)
        {
            percent += 50 / Count;
            base.ChangePrice(percent);
        }
    }
}
