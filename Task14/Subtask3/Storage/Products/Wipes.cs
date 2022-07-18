using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    internal class Wipes : AbstractStationeryProduct
    {
        private WipesType wipesType;
        public WipesType WipesType { get => wipesType; }

        public Wipes(string name, double price, int count, WipesType wipesType) : base(name, price, count)
        {
            this.wipesType = wipesType;
        }

        public override void ChangePrice(int percent)
        {
            switch (WipesType)
            {
                case WipesType.Dry:
                    percent += 2;
                    break;
                case WipesType.Wet:
                    percent += 3;
                    break;
                case WipesType.Screens:
                    percent += 4;
                    break;
                default:
                    break;
            }
            base.ChangePrice(percent);
        }
    }
}
