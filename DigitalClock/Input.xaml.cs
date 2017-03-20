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
    /// Lógica de interacción para Input.xaml
    /// </summary>
    public partial class Input : Window
    {
        public Input()
        {
            InitializeComponent();
        }

        private void closeInput(object sender, RoutedEventArgs e)
        {
            this.Close();
    
        }

        private void addHora(object sender, RoutedEventArgs e)
        {
            MainWindow.diferenciasHorarias.Add(new DiferenciaHoraria(namePais.Text , Int32.Parse(numHoras.Text)));
            this.Close();
        }

    }
}
