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
            Kasten_0_0.Content = string.Empty;
            Kasten_1_0.Content = string.Empty;
            Kasten_2_0.Content = string.Empty;

            Kasten_0_1.Content = string.Empty;
            Kasten_1_1.Content = string.Empty;
            Kasten_2_1.Content = string.Empty;

            Kasten_0_2.Content = string.Empty;
            Kasten_1_2.Content = string.Empty;
            Kasten_2_2.Content = string.Empty;
        }
    }
}
