using LocadoraDeImoveis.DAL;
using LocadoraDeImoveis.Models;
using LocadoraDeImoveis.Utils;
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
        BuscaCepUtils BuscaCep = new BuscaCepUtils();
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

                if (CorretorDAO.Cadastrar(Corretor))
                {
                    MessageBox.Show("Corretor salvo com sucesso!", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Erro interno: contate um ADM!", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }        
        }
        
        public void LimparFormulario()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtCidade.Clear();
            txtCOEFI.Clear();
            txtUF.Clear();
        }

        private void BtnBuscaCep_Click(object sender, RoutedEventArgs e)
        {
            var Cep = BuscaCep.BuscarCepService(txtCEP.Text);
            txtCidade.Text = Cep.localidade;
            txtUF.Text = Cep.uf;
        }
    }

}
