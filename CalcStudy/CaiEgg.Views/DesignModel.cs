using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaiEgg.ViewModels;

namespace CaiEgg.Views
{
    public class DesignModel
    {
        public static CalculatorViewModel Instance { get; private set; } = new CalculatorViewModel();
    }
}
