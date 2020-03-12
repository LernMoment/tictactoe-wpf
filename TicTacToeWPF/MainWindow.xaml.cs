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

        public MainWindow()
        {
            InitializeComponent();

            StarteNeuesSpiel();
        }

        private void kaestchen_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void StarteNeuesSpiel()
        {
            KaestchenLeeren();
            _istErsterSpielerAmZug = true;
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
            keastchen_2_1.Content = string.Empty;

            kaestchen_0_2.Content = string.Empty;
            kaestchen_1_2.Content = string.Empty;
            kaestchen_2_2.Content = string.Empty;
        }

    }
}
