using System.Collections.Generic;
using System.Windows;
using Microsoft.Shell;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, ISingleInstanceApp
    {
        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            this.MainWindow.Focus();            
            return true;
        }
    }
}
