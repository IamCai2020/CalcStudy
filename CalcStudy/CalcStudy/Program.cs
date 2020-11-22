using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaiEgg.Views;
using System.Windows;

namespace CalcStudy
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            CalculatorView view = new CalculatorView();
            Application app = new Application();
            app.Run(view);
        }
    }
}
