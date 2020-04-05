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

namespace TicTacToeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _istErsterSpielerAmZug = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _istErsterSpielerAmZug = true;
            StarteSpielNeu();
        }

        private void Kaestchen_Click(object sender, RoutedEventArgs e)
        {
            Button kaestchen = (Button)sender;

            if (IstSpielfeldVoll())
            {
                StarteSpielNeu();
                return;
            }

            if (kaestchen.Content != null && kaestchen.Content.ToString() != "")
            {
                MessageBox.Show("Dieses Kästchen ist bereits belegt! Wähle ein anderes.");
                return;
            }

            if (_istErsterSpielerAmZug)
            {
                kaestchen.Content = "X";
                _istErsterSpielerAmZug = false;
            }
            else
            {
                kaestchen.Content = "O";
                var vordergrund = kaestchen.Foreground;
                kaestchen.Foreground = kaestchen.Background;
                kaestchen.Background = vordergrund;
                _istErsterSpielerAmZug = true;
            }

            if (IstSpielGewonnen())
            {
                MessageBox.Show("Spiel ist Gewonnen!");
            }
        }

        private bool IstSpielGewonnen()
        {
            if (kaestchen_0_0.Content.ToString() != ""
                && kaestchen_1_0.Content.ToString() == kaestchen_0_0.Content.ToString()
                && kaestchen_2_0.Content.ToString() == kaestchen_1_0.Content.ToString())
            {
                return true;
            }

            return false;
        }

        private bool IstSpielfeldVoll()
        {
            foreach (var item in Spielfeld.Children)
            {
                Button kaestchen = item as Button;

                if (kaestchen == null || kaestchen.Content.ToString() == "")
                {
                    return false;
                }
            }

            return true;
        }

        private void StarteSpielNeu()
        {
            kaestchen_0_0.Content = string.Empty;
            kaestchen_1_0.Content = string.Empty;
            kaestchen_2_0.Content = string.Empty;
            kaestchen_0_1.Content = string.Empty;
            kaestchen_1_1.Content = string.Empty;
            kaestchen_2_1.Content = string.Empty;
            kaestchen_0_2.Content = string.Empty;
            kaestchen_1_2.Content = string.Empty;
            kaestchen_2_2.Content = string.Empty;

            kaestchen_0_0.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            kaestchen_1_0.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            kaestchen_2_0.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            kaestchen_0_1.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            kaestchen_1_1.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            kaestchen_2_1.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            kaestchen_0_2.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            kaestchen_1_2.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
            kaestchen_2_2.Background = (Brush)new BrushConverter().ConvertFrom("#00A8C6");

            kaestchen_0_0.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            kaestchen_1_0.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            kaestchen_2_0.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            kaestchen_0_1.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            kaestchen_1_1.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            kaestchen_2_1.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            kaestchen_0_2.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            kaestchen_1_2.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            kaestchen_2_2.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
        }
    }
}
