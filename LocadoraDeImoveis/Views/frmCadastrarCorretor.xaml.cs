using LocadoraDeImoveis.Models;
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
    /// Interaction logic for frmCadastrarCorretor.xaml
    /// </summary>
    public partial class frmCadastrarCorretor : Window
    {
        Corretor Corretor { get; set; }
        public frmCadastrarCorretor()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text) || !string.IsNullOrWhiteSpace(txtCPF.Text) || !string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                !string.IsNullOrWhiteSpace(txtEmail.Text) || !string.IsNullOrWhiteSpace(txtCidade.Text) || !string.IsNullOrWhiteSpace(txtCOEFI.Text) ||
                !string.IsNullOrWhiteSpace(txtUF.Text))
            {
                Corretor = new Corretor()
                {
                    Nome = txtNome.Text,
                    Cpf = txtCPF.Text,
                    Telefone = txtTelefone.Text,
                    Email = txtEmail.Text,
                    Cidade = txtCidade.Text,
                    Cofeci = txtCOEFI.Text,
                    UF = txtUF.Text
                };
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
