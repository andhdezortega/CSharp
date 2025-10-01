
using System;
using System.Threading.Tasks;
using System.Windows;

namespace BibliotecaWPF;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        AppDomain.CurrentDomain.UnhandledException += (s, ex) =>
        {
            try { MessageBox.Show($"Excepción no controlada: {ex.ExceptionObject}"); } catch { }
        };
        DispatcherUnhandledException += (s, ex) =>
        {
            try { MessageBox.Show($"Excepción de UI: {ex.Exception.Message}"); } catch { }
            ex.Handled = true;
        };
        TaskScheduler.UnobservedTaskException += (s, ex) =>
        {
            try { MessageBox.Show($"Excepción en tarea: {ex.Exception?.Message}"); } catch { }
            ex.SetObserved();
        };

        base.OnStartup(e);

        var window = new MainWindow();
        window.Show();
    }
}

