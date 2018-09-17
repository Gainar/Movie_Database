using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Movie.Proxy.Proxy;
using Ninject;
using Ninject.Modules;

namespace Movie.WindowsForms
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IKernel kernel= new StandardKernel();
            kernel.Bind(typeof(IDesktop)).To(typeof(Desktop));
            var repo = kernel.Get<IDesktop>();
            Application.Run(new Form1(repo));
        }

    }
}
