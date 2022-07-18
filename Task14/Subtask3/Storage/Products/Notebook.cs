using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    internal class Notebook : AbstractStationeryProduct
    {
        private NotebookType notebookType;
        public NotebookType NotebookType { get => notebookType; }

        public Notebook(string name, double price, int count, NotebookType notebookType) : base(name, price, count)
        {
            this.notebookType = notebookType;
        }
    }
}
