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

#endregion

namespace ModificarParametroMVVM
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
                Utils utils = new Utils();

                //Seleccionar Elemento en la pantalla
                TaskDialog.Show("Info_Revit", "Seleccione un elemento");

                // Prompt the user to select an element.
                Reference selectedElement = uidoc.Selection.PickObject(ObjectType.Element);

                if (selectedElement != null)
                {
                    // Get the selected element from the document.
                    ElementId elemId = selectedElement.ElementId;

                    Element elem = doc.GetElement(elemId);

                    string datos = utils.GenerateParametersAndValues(doc, elemId.IntegerValue);

                    // Create a view model that will be associated to the DataContext of the view.
                    ViewModel.ViewModelParam vmod = new ViewModel.ViewModelParam();
                    
                    vmod.SelectNombre = datos.Split(',')[0];
                    vmod.SelectComentario = datos.Split(',')[1];
                    vmod.SelectMarca = datos.Split(',')[2];

                    // Create a new Revit model and assign it to the Revit model variable in the view model.
                    vmod.RevitModel = new Model.Modelo(uiapp, elem);

                    Process proc = Process.GetCurrentProcess();

                    // Load the WPF window mVModificar.
                    using (View.mVModificar view = new View.mVModificar())
                    {
                        System.Windows.Interop.WindowInteropHelper helper = new System.Windows.Interop.WindowInteropHelper(view);
                        helper.Owner = proc.MainWindowHandle;

                        // Assign the view model to the DataContext of the view.
                        view.DataContext = vmod;

                        if (view.ShowDialog() != true)
                        {
                            return Result.Cancelled;
                        }
                    }
                }

                // Assuming that everything went right return Result.Succeeded
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
    }
}
