using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Seleccion
{
    public class ModelRevit 
    {
        public string GetData(Element elem)
        {
            string nombre = elem.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
            string ID = "<" + elem.Id.ToString() + ">";
            //
            return string.Format("Name Element: {0},ID: {1}", nombre, ID);
        }
    }
}
