using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Seleccion
{
    public class SelectCommand : ICommand
    {
        public ViewModelRevit m_modelRevit {get;set; }

        public SelectCommand(ViewModelRevit modelRevit)
        {
            this.m_modelRevit = modelRevit;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_modelRevit.SelectComamdAction();
        }
    }
}
