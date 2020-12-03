using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaiEgg.Views;
using System.Windows;
using LoongEgg.LoongCore;
using LoongEgg.LoongLogger;
using CaiEgg.ViewModels;

namespace CalcStudy
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            LoggerManager.Enable(LoggerType.Debug|LoggerType.Console|LoggerType.File);

            CalculatorView view = new CalculatorView
            {
                DataContext = new CalculatorViewModel()
            };
            Application app = new Application();
            app.Run(view);

            LoggerManager.Disable();
        }
    }
}
