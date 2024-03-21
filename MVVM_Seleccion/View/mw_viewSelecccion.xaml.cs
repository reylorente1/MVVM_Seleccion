using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_Seleccion
{
    /// <summary>
    /// Lógica de interacción para mw_viewSelecccion.xaml
    /// </summary>
    public partial class mw_viewSelecccion : Window
    {
        UIDocument _uidoc;
        public mw_viewSelecccion(UIDocument uidoc)
        {
            InitializeComponent();
            _uidoc = uidoc;
            
            DataContext = new ViewModelRevit(_uidoc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnErase_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;

            DataContext = new ViewModelRevit(_uidoc);
        }
    }
}
