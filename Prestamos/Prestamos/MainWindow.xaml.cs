
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
using BE;

namespace Prestamos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DAC.Prestamos.TecnicoDAC tec = new DAC.Prestamos.TecnicoDAC();
            BE.Prestamos.Tecnico tecBE = new BE.Prestamos.Tecnico();

            tecBE.nombre = txNombre.Text;
            tecBE.AreaAtencion = txAreaAtencion.Text;

            tec.InsertarUsuario(tecBE);
        }
    }
}
