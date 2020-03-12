using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToeWPF
{
    enum KaestchenStatus
    {
        Leer,
        X,
        O
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
            if (_istErsterSpielerAmZug)
            {
                aktuellesUiKaestchen.Content = _spielsteinErsterSpieler;
                _istErsterSpielerAmZug = false;
            }
            else
            {
                aktuellesUiKaestchen.Content = _spielsteinZweiterSpieler;
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
