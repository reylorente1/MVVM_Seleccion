#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Markup.Primitives;

#endregion

namespace MVVM_Seleccion
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            try
            {
                mw_viewSelecccion mw_ViewSelecccion = new mw_viewSelecccion(uidoc);
                mw_ViewSelecccion.Show();
                
                return Result.Succeeded;
            }
            // This is where we "catch" potential errors and define how to deal with them
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                // If user decided to cancel the operation return Result.Canceled
                return Result.Cancelled;
            }
            catch (Exception ex)
            {
                // If something went wrong return Result.Failed
                message = ex.Message;
                return Result.Failed;
            }
        }

        #region Seleccionar Elemento
        /// <summary>
        /// Seleccionar un elemento
        /// </summary>
        /// <param name="uidoc"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public Element SeleccElement(UIDocument uidoc)
        {
            //Documentos
            Document doc = uidoc.Document;

            //Seleccionar Elemento en la pantalla
            TaskDialog.Show("Info_Revit", "Seleccione un elemento");

            // Access current selection
            Selection sel = uidoc.Selection;

            //Obtener la referencia seleccionada
            Reference reference = sel.PickObject(ObjectType.Element, "Seleccione un Elemento");

            //Obtener el elemento elegido
            Element element = doc.GetElement(reference);

            return element;
        }
        #endregion
    }
}
