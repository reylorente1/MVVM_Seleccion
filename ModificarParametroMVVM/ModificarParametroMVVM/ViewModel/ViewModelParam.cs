using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;

namespace ModificarParametroMVVM.ViewModel
{
    public class ViewModelParam : BindableBase
    {
        //Variable
        //private string m_selectNombre;
        private string m_selectComentario;
        private string m_selecMarca;
        
        private Parameter m_parameter;

        public string SelectNombre { get; set; }

        // The get-set variable
        internal Model.Modelo RevitModel { get; set; }

        public string SelectComentario
        {
            get => m_selectComentario;

            set
            {
                m_selectComentario = value;
                RaisePropertyChanged("SelectedString");
            }
        }

        public string SelectMarca
        {
            get => m_selecMarca;

            set
            {
                m_selecMarca = value;
                RaisePropertyChanged("SelectedString");
            }
        }

        //  Commands
        // This will be used by the button in the WPF window.
        public ICommand RetrieveParametersValuesCommand => new DelegateCommand(RetrieveParametersValuesAction);

        public Parameter SelectParameter
        {
            get => m_parameter;

            set => SetProperty(ref m_parameter, value);
        }

        // The action function for RetrieveParametersValuesCommand
        private void RetrieveParametersValuesAction()
        {
            if (SelectParameter == null)
            {
                SelectParameter = RevitModel.CambiarDatos(SelectComentario,SelectMarca);
            }
        }

        // Constructor
        public ViewModelParam()
        {

        }
    }
}
