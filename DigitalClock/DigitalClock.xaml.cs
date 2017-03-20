using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Windows.Threading;

namespace DigitalClock
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<DiferenciaHoraria> diferenciasHorarias = new List<DiferenciaHoraria>();

        public MainWindow()
        {
            InitializeComponent();
            startClock();
            // Example
            diferenciasHorarias.Add(new DiferenciaHoraria("España", 1));

            countryList();

            persistClock();
        }

        public void countryList()
        {
            boxDiferencia.Items.Clear();
            foreach (DiferenciaHoraria i in diferenciasHorarias)
            {
                boxDiferencia.Items.Add(i.pais);
            }
            boxDiferencia.SelectedIndex = 0;
        }

        private void persistClock()
        {
            if (File.Exists("prova.bin"))
            {
                Stream FileStream = File.OpenRead("prova.bin");
                BinaryFormatter deserializer = new BinaryFormatter();
                Alarma alarma = (Alarma)deserializer.Deserialize(FileStream);
                FileStream.Close();

                alarmaBox.Text = alarma.hora;
                alarmaActivada.IsChecked = alarma.enable;

            } else
            {
                alarmaBox.Text = "00:00:00";
            }
        }

        private void startClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickEvent;
            timer.Start();
        }

        private void tickEvent(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString(@"hh\:mm\:ss");

            int n = 0;
            if (boxDiferencia.SelectedIndex >= 0 && boxDiferencia.SelectedIndex < diferenciasHorarias.Count)
            {
                n = diferenciasHorarias[boxDiferencia.SelectedIndex].diferenciaHoraria;
                relojSecundario.Text = DateTime.Now.AddHours(n-1).ToString(@"hh\:mm\:ss");
            }

            if (alarmaActivada.IsChecked)
            {
                if (timerLabel.Text == alarmaBox.Text)
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Alarma activada!!");
                    
                }
            }
        }

        private void afegirPais(object sender, RoutedEventArgs e)
        {
            Input inputDialog = new Input();
            inputDialog.ShowDialog();
            countryList();
        }

        private void eliminarPais(object sender, RoutedEventArgs e)
        {
            Delete eliminarDialog = new Delete();
            eliminarDialog.ShowDialog();
            relojSecundario.Text = "";
            countryList();
        }


        private void clickSortir(object sender, RoutedEventArgs e)
        {

            if (File.Exists("prova.bin"))
            {
                File.Delete("prova.bin");
            }

            Boolean activada = false;

            if (alarmaActivada.IsChecked == true) activada = true;

            Alarma alarma = new Alarma(alarmaBox.Text, activada);

            Stream FileStream = File.Create("prova.bin");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(FileStream, alarma);
            FileStream.Close();

            Application.Current.Shutdown();
        }

        private void clickSobre (object sender , RoutedEventArgs e)
        {
            MessageBox.Show("Carlos Ramirez");
        }
    }
}
