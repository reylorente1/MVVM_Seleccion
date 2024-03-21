using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModificarParametroMVVM
{
    class Utils
    {

        //Lista de BuiltinParameter
        BuiltInParameter built_name = BuiltInParameter.ELEM_FAMILY_PARAM;
        BuiltInParameter built_Comments = BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS;
        BuiltInParameter built_Marca = BuiltInParameter.ALL_MODEL_MARK;

        //Variable
        private string nombre = "";
        private string comentario = "";
        private string marca = "";

        // This function will be called by the Action function in the view model, so it must be public.
        public string GenerateParametersAndValues(Document doc, int idIntegerValue)
        {
            Element e = doc.GetElement(new ElementId(idIntegerValue));
            if (e != null)
            {
                nombre = string.Format("{0} => ID {1} ", e.get_Parameter(built_name).AsValueString(), "<" + e.Id.IntegerValue.ToString() + ">");
                Parameter param_Commen = e.get_Parameter(built_Comments);
                Parameter param_Marca = e.get_Parameter(built_Marca);

                if (param_Commen != null)
                {
                    comentario = param_Commen.AsValueString();
                }

                if (param_Marca != null)
                {
                    marca = param_Marca.AsValueString();
                }
            }
            return nombre + "," + comentario + "," + marca;
        }
    }
}
