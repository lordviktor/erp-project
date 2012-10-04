#region Using

using System.Windows;

#endregion

namespace ERP.View.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            new global::ERP.Core.ModuleHandler().ComposeCatalog();
        }
    }
}