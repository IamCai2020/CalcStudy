using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using LoongEgg.LoongCore;
using LoongEgg.LoongLogger;
using CaiCal.MathSimple;

namespace CaiEgg.ViewModels
{
    public class CalculatorViewModel:BaseViewModel
    {
        public ICommand InputCommand { get; private set; }

        public string Result
        { 
            get=>_MyProperty; 
            set=>SetProperty(ref _MyProperty,value); 
        }
        private string _MyProperty;

        private ExpressionSimple _Expression;

        public CalculatorViewModel()
        {
            InputCommand = new DelegateCommand(Input);
            _Expression = new ExpressionSimple();
        }

        public void Input(object input)
        {
            if (input is Button btn)
            {
                string inp = btn.Content.ToString();
                Result = _Expression.Push(inp);
                LoggerManager.WriteInfor($"Sth input {Result} ... ");
            }
                

        }
    }

    

}
