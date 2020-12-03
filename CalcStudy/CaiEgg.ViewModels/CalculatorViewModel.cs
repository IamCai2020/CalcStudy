using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LoongEgg.LoongCore;
using LoongEgg.LoongLogger;

namespace CaiEgg.ViewModels
{
    public class CalculatorViewModel:BaseViewModel
    {
        public ICommand InputCommand { get; private set; }

        public CalculatorViewModel()
        {
            InputCommand = new DelegateCommand(Input);
        }

        public void Input(object input)
        {
            LoggerManager.WriteInfor($"The Button {input} pressed ...");

        }
    }

    

}
