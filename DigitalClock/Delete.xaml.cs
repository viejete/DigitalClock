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
using System.Windows.Shapes;

namespace DigitalClock
{
    /// <summary>
    /// Lógica de interacción para Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public Delete()
        {
            InitializeComponent();
            getAndSetCountry();
        }

        public void getAndSetCountry()
        {
            boxEliminar.Items.Clear();
            foreach (DiferenciaHoraria i in MainWindow.diferenciasHorarias)
            {
                boxEliminar.Items.Add(i.pais);
            }
            boxEliminar.SelectedIndex = 0;
        }

        private void clickEliminar(object sender , RoutedEventArgs e)
        {
            foreach (DiferenciaHoraria i in MainWindow.diferenciasHorarias)
            {
                if (boxEliminar.SelectedItem as String == i.pais)
                {
                    MainWindow.diferenciasHorarias.Remove(i);
                    break;
                }
            }
            this.Close();
        }

        private void clickCancelar(object sender , RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
