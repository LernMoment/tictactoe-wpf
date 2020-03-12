using System;
using System.Windows;

namespace TicTacToeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StarteNeuesSpiel();
        }

        private void StarteNeuesSpiel()
        {
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
