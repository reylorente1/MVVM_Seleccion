using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModificarParametroMVVM.Model
{
    public class Modelo
    {
        // Just like what you do when creating a Revit command, declare the necessary variable such as below.
        private UIApplication UIAPP = null;
        private Application APP = null;
        private UIDocument UIDOC = null;
        private Document DOC = null;
        private Element _elem = null;

        // The model constructor. Include a UIApplication argument and do all the assignments here.
        public Modelo(UIApplication uiapp,Element elem)
        {
            UIAPP = uiapp;
            APP = UIAPP.Application;
            UIDOC = UIAPP.ActiveUIDocument;
            DOC = UIDOC.Document;
            _elem = elem;
        }

        public Parameter CambiarDatos(string comm,string marca)
        {

            Parameter param_Commen = _elem.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
            Parameter param_Marca = _elem.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);

            //Iniciar una transaccion
            using (Transaction trans = new Transaction(DOC, "Modificar Parametro"))
            {
                trans.Start();
                //Modificar los parametros
                if (param_Commen != null)
                {
                    param_Commen.Set(comm);
                }

                if (param_Marca != null)
                {
                    param_Marca.Set(marca);
                }
                trans.Commit();

                TaskDialog.Show("Info_Revit", "Parametro Modificado correctmente");

                return param_Commen;
            }
        }
    }
}
