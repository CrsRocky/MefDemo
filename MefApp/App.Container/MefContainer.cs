using System;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace App.Contract
{
    public class MefContainer
    {
        private static CompositionContainer _compositionContainer;
        private static bool _initailized = false;

        public static void Initailized()
        {
            if (_initailized) return;

            //获取包含当前执行的代码的程序集。
            var assembly = Assembly.GetExecutingAssembly();
            var directory = Path.GetDirectoryName(assembly.Location);

            //在MEF框架中，包含了4种Catalog，所有的Catalog的是从
            //System.ComponentModel.Composition.Primitives名称空间下的ComposablePartCatalog抽象类派生下来。
            //AssemblyCatalog：表示从程序集中搜索部件的目录。
            //DirectoryCatalog：表示从文件系统的指定路径中，搜索程序集，从而搜索部件。
            //TypeCatalog：表示从指定的类型集合中，去搜索相应的部件。
            //AggregateCatalog：聚合目录，可以添加上面所说的所有目录，从而进行多方面的部件搜索。
            var aggregate = new AggregateCatalog();
            var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach (var assemblyPath in Directory.GetFiles(assemblyDir))
            {
                try
                {
                    var fileName = Path.GetFileName(assemblyPath);
                    var extensionName = Path.GetExtension(fileName).ToLower();
                    if (extensionName == ".dll")
                    {
                        var category = new AssemblyCatalog(Path.Combine(directory, assemblyPath));
                        aggregate.Catalogs.Add(category);
                    }
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }
            }
            _compositionContainer = new CompositionContainer(aggregate);

            //var parentContainer = new CompositionContainer( _compositionContainer);

            //var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory));
            //_compositionContainer = new CompositionContainer(catalog);
            _initailized = true;
        }

        public static CompositionContainer CompositionContainer
        {
            get
            {
                if (_initailized == false)
                {
                    Initailized();
                }
                return _compositionContainer;
            }
        }
    }
}