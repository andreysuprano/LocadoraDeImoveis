using LocadoraDeImoveis.DAL;
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
    /// Lógica interna para frmEditaAtualizaCorretor.xaml
    /// </summary>
    public partial class frmEditaAtualizaCorretor : Window
    {
        Corretor Corretor;
        Corretor CorretorBuscado;
        public frmEditaAtualizaCorretor()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text) || !string.IsNullOrWhiteSpace(txtCPF.Text) || !string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                !string.IsNullOrWhiteSpace(txtEmail.Text) || !string.IsNullOrWhiteSpace(txtCidade.Text) || !string.IsNullOrWhiteSpace(txtCOEFI.Text) ||
                !string.IsNullOrWhiteSpace(txtUF.Text))
            {
                Corretor = new Corretor()
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Nome = txtNome.Text,
                    Cpf = txtCPF.Text,
                    Telefone = txtTelefone.Text,
                    Email = txtEmail.Text,
                    Cidade = txtCidade.Text,
                    Cofeci = txtCOEFI.Text,
                    UF = txtUF.Text
                };
                
                if (CorretorDAO.Atualizar(Corretor))
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

        private void BtnBuscaNome_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                CorretorBuscado = CorretorDAO.BuscarPorNome(txtNome.Text);
                txtId.Text = CorretorBuscado.Id.ToString();
                txtNome.Text = CorretorBuscado.Nome;
                txtEmail.Text = CorretorBuscado.Email;
                txtTelefone.Text = CorretorBuscado.Telefone;
                txtCPF.Text = CorretorBuscado.Cpf;
                txtCOEFI.Text = CorretorBuscado.Cofeci;
                txtCidade.Text = CorretorBuscado.Cidade;
                txtUF.Text = CorretorBuscado.UF;
            }
            else
            {
                MessageBox.Show("Nome está Vazio", "Imob",
                MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void BtnExluir_Click(object sender, RoutedEventArgs e)
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
                
                if (CorretorDAO.Remover(Corretor))
                {
                    MessageBox.Show("Corretor excluído com sucesso!", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Erro interno: tente novamente ou contate um ADM!", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
