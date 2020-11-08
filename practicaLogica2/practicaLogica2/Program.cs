using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaLogica2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            principal.principal1();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VentanaInicio ventanainicio1 = new VentanaInicio();
            Application.Run(ventanainicio1);
            principal.principal1();
            
        }
    }
}
