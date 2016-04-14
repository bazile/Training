using System;
using Microsoft.Shell;

namespace Wpf
{
    class Program
    {
        private const string Unique = "My_Unique_Application_String";

        [STAThread]
        static void Main()
        {
            if (SingleInstance<App>.InitializeAsFirstInstance(Unique))
            {
                var application = new App();

                application.InitializeComponent();
                application.Run();

                // Allow single instance code to perform cleanup operations
                SingleInstance<App>.Cleanup();
            }
        }
    }
}
