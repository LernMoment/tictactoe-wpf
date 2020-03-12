using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToeWPF
{
    enum KaestchenStatus
    {
        Leer,
        ErsterSpieler,
        ZweiterSpieler
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string _spielsteinErsterSpieler = "X";
        private const string _spielsteinZweiterSpieler = "O";

        private KaestchenStatus[] _kaestchen;
        private bool _istErsterSpielerAmZug;
        private bool _istSpielBeendet;

        public MainWindow()
        {
            InitializeComponent();

            StarteNeuesSpiel();
        }

        private void Kaestchen_Click(object sender, RoutedEventArgs e)
        {
            if (_istSpielBeendet)
            {
                StarteNeuesSpiel();
                return;
            }

            var aktuellesUiKaestchen = (Button)sender;
            var spaltenIndex = Grid.GetColumn(aktuellesUiKaestchen);
            var zeilenIndex = Grid.GetRow(aktuellesUiKaestchen);
            var logikIndex = spaltenIndex + (zeilenIndex * 3);

            if (_kaestchen[logikIndex] != KaestchenStatus.Leer)
            {
                return;
            }

            if (_istErsterSpielerAmZug)
            {
                aktuellesUiKaestchen.Content = _spielsteinErsterSpieler;
                _kaestchen[logikIndex] = KaestchenStatus.ErsterSpieler;
                _istErsterSpielerAmZug = false;
            }
            else
            {
                aktuellesUiKaestchen.Content = _spielsteinZweiterSpieler;
                aktuellesUiKaestchen.Background = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
                aktuellesUiKaestchen.Foreground = (Brush)new BrushConverter().ConvertFrom("#00A8C6");
                _kaestchen[logikIndex] = KaestchenStatus.ZweiterSpieler;
                _istErsterSpielerAmZug = true;
            }

            if (IstSpielGewonnen())
            {
                _istSpielBeendet = true;
            }

            if (IstSpielBeendet())
            {
                _istSpielBeendet = true;
            }
        }

        private bool IstSpielGewonnen()
        {
            if (IstGleicherSpielstein(0, 1, 2))
            {
                kaestchen_0_0.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_1_0.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_2_0.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                return true;
            }
            else if (IstGleicherSpielstein(3, 4, 5))
            {
                kaestchen_0_1.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_1_1.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_2_1.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                return true;
            }
            else if (IstGleicherSpielstein(6, 7, 8))
            {
                kaestchen_0_2.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_1_2.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_2_2.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                return true;
            }
            else if (IstGleicherSpielstein(0, 3, 6))
            {
                kaestchen_0_0.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_0_1.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_0_2.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                return true;
            }
            else if (IstGleicherSpielstein(1, 4, 7))
            {
                kaestchen_1_0.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_1_1.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_1_2.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                return true;
            }
            else if (IstGleicherSpielstein(2, 5, 8))
            {
                kaestchen_2_0.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_2_1.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_2_2.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                return true;
            }
            else if (IstGleicherSpielstein(0, 4, 8))
            {
                kaestchen_0_0.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_1_1.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_2_2.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                return true;
            }
            else if (IstGleicherSpielstein(6, 4, 2))
            {
                kaestchen_2_0.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_1_1.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                kaestchen_0_2.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
                return true;
            }

            return false;
        }

        private bool IstGleicherSpielstein(int indexEins, int indexZwei, int indexDrei)
        {
            if (_kaestchen[indexEins] != KaestchenStatus.Leer
                && _kaestchen[indexEins] == _kaestchen[indexZwei]
                && _kaestchen[indexZwei] == _kaestchen[indexDrei])
            {
                return true;
            }

            return false;
        }

        private bool IstSpielBeendet()
        {
            foreach (var aktuellesKaestchen in _kaestchen)
            {
                if (aktuellesKaestchen == KaestchenStatus.Leer)
                {
                    return false;
                }
            }

            return true;
        }

        private void StarteNeuesSpiel()
        {
            KaestchenLeeren();
            _istErsterSpielerAmZug = true;
            _istSpielBeendet = false;
        }

        private void KaestchenLeeren()
        {
            _kaestchen = new KaestchenStatus[9];
            for (int i = 0; i < _kaestchen.Length - 1; i++)
            {
                _kaestchen[i] = KaestchenStatus.Leer;
            }

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
