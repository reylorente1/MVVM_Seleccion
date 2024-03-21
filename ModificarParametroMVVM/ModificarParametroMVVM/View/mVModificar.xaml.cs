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

namespace ModificarParametroMVVM.View
{
    /// <summary>
    /// Lógica de interacción para mVModificar.xaml
    /// </summary>
    public partial class mVModificar : Window,IDisposable
    {
        public mVModificar()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            this.Close(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
