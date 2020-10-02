using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LocadoraDeImoveis.Views
{
    /// <summary>
    /// Interaction logic for frmCorretores.xaml
    /// </summary>
    public partial class frmCorretores : Window
    {
        public frmCorretores()
        {
            InitializeComponent();
        }

        private void ToolVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToolNovo_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarCorretor frmCadastrarCorretor = new frmCadastrarCorretor();
            frmCadastrarCorretor.ShowDialog();
        }
    }
}
