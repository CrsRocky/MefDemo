using App.Contract;
using System.ComponentModel.Composition;

namespace MefApp
{
    internal class ImportProvider<T>
    {
        [Import]
        private ExportFactory<T> exportFactory;

        public ImportProvider()
        {
            MefContainer.CompositionContainer.ComposeParts(this);
        }

        public T Relove()
        {
            return exportFactory.CreateExport().Value;
        }
    }
}