using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Seleccion
{
    public class ViewModelRevit : INotifyPropertyChanged
    {
        private Element m_slectElement;
        private string m_showElement;
        

        UIDocument _uidoc;

       

        private ModelRevit m_revitModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Element SelectElement
        {
            get { return m_slectElement; }
            set { m_slectElement = value; NotifyPropertyChanged("SelectElement"); }
        }

        public string ShowElement
        {
            get { return m_showElement; }
            set { m_showElement = value; NotifyPropertyChanged("ShowElement"); }
        }

        // The get-set variable
        internal ModelRevit RevitModel
        {
            get
            {
                return m_revitModel;
            }

            set
            {
                m_revitModel = value;
            }
        }

        // The action function for RetrieveParametersValuesCommand
        public void SelectComamdAction()
        {
            if (SelectElement == null)
            {
                SelectElement = PickElement();
            }
            
            if (SelectElement != null)
            {
                ShowElement = RevitModel.GetData(SelectElement);
            }
        }

        public SelectCommand SelectCommand { get; set; }

        public ViewModelRevit(UIDocument uidoc)
        {
            _uidoc = uidoc;
            //
            SelectCommand = new SelectCommand(this);
        }

        

        private Element PickElement()
        {
            Document document = _uidoc.Document;
            Selection selection = _uidoc.Selection;
            Element element = null;
            try
            {
                TaskDialog.Show("Seleccion", "Select Element");
                var reference = selection.PickObject(ObjectType.Element);
                element = document.GetElement(reference);
            }
            catch { }

            RevitModel = new ModelRevit();

            return element;
        }

    }
}
