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
    /// Lógica interna para frmEditaAtualizaCorretor.xaml
    /// </summary>
    public partial class frmEditaAtualizaCorretor : Window
    {
        private Corretor Corretor;
        public bool Exlcuir = false;
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
                Corretor.Id = Convert.ToInt32(txtId.Text);
                Corretor.Nome = txtNome.Text;
                Corretor.Cpf = txtCPF.Text;
                Corretor.Telefone = txtTelefone.Text;
                Corretor.Email = txtEmail.Text;
                Corretor.Cidade = txtCidade.Text;
                Corretor.Cofeci = txtCOEFI.Text;
                Corretor.UF = txtUF.Text;

                if (!ValidacaoCpfUtils.ValidarCpf(txtCPF.Text))
                {
                    MessageBox.Show("CPF Inválido!", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                }
                else
                {
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
                
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnBuscaNome_Click(object sender, RoutedEventArgs e)
        {
            Corretor = CorretorDAO.BuscarPorNome(txtNome.Text);
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {                
                txtId.Text = Corretor.Id.ToString();
                txtNome.Text = Corretor.Nome;
                txtEmail.Text = Corretor.Email;
                txtTelefone.Text = Corretor.Telefone;
                txtCPF.Text = Corretor.Cpf;
                txtCOEFI.Text = Corretor.Cofeci;
                txtCidade.Text = Corretor.Cidade;
                txtUF.Text = Corretor.UF;
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
                Corretor.Nome = txtNome.Text;
                Corretor.Cpf = txtCPF.Text;
                Corretor.Telefone = txtTelefone.Text;
                Corretor.Email = txtEmail.Text;
                Corretor.Cidade = txtCidade.Text;
                Corretor.Cofeci = txtCOEFI.Text;
                Corretor.UF = txtUF.Text;

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
