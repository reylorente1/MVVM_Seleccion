#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Imaging;

#endregion

namespace ModificarParametroMVVM
{
    class App : IExternalApplication
    {
        // The assembly of the project.
        static readonly string stringassembly = Assembly.GetExecutingAssembly().Location;

        // The name of the tab to be added to Revit Ribbon.
        static readonly string tabName = "my Tools";
        public Result OnStartup(UIControlledApplication a)
        {
            try
            {
                // Create the tab.
                a.CreateRibbonTab(tabName);

                // Create the "element" panel.
                RibbonPanel ribbonPanel = a.CreateRibbonPanel(tabName, "Datos");

                //Agregar un boton
                PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("BotonDatos",
                   "Mostrar Datos", stringassembly, "ModificarParametroMVVM.Command")) as PushButton;

                //Establecer la imagen del boton
                pushButton.LargeImage = new BitmapImage(
                    new Uri("pack://application:,,,/ModificarParametroMVVM;component/Resources/Colocar_ejemplar.jpg"));
                pushButton.ToolTip = "Info Datos";
                pushButton.LongDescription = "Mostrar datos al usuaerio ";

            }
            catch (Exception e)
            {
                // Show the user an error message through task dialog.
                TaskDialog.Show("Error", e.Message);

                // Retun failed result.
                return Result.Failed;
            }
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
