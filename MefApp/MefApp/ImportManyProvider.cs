using App.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace MefApp
{
    internal class ImportManyProvider<T>
    {
        [ImportMany]
        private IEnumerable<ExportFactory<T>> exportFactories;

        public ImportManyProvider()
        {
            MefContainer.CompositionContainer.ComposeParts(this);
        }

        public T Relove(int index)
        {
            return exportFactories.ElementAt(index).CreateExport().Value;
        }
    }
}