using LocadoraDeImoveis.DAL;
using LocadoraDeImoveis.Models;
using LocadoraDeImoveis.Utils;
using System;
using System.Windows;

namespace LocadoraDeImoveis.Views
{
    /// <summary>
    /// Lógica interna para frmEditaAtualizaLocatario.xaml
    /// </summary>
    public partial class frmEditaAtualizaLocatario : Window
    {
        private Locatario Locatario;
        public bool Exlcuir = false;
        public frmEditaAtualizaLocatario()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text) || !string.IsNullOrWhiteSpace(txtCPF.Text) || !string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                !string.IsNullOrWhiteSpace(txtEmail.Text) || !string.IsNullOrWhiteSpace(txtCidade.Text) || !string.IsNullOrWhiteSpace(txtRendaDisponivel.Text) ||
                !string.IsNullOrWhiteSpace(txtUF.Text))
            {

                Locatario.Id = Convert.ToInt32(txtId.Text);
                Locatario.Nome = txtNome.Text;
                Locatario.Cpf = txtCPF.Text;
                Locatario.Telefone = txtTelefone.Text;
                Locatario.Email = txtEmail.Text;
                Locatario.Cidade = txtCidade.Text;
                Locatario.RendaDisponivel = Convert.ToInt32(txtRendaDisponivel.Text);
                Locatario.UF = txtUF.Text;

                if (!ValidacaoCpfUtils.ValidarCpf(txtCPF.Text))
                {
                    MessageBox.Show("CPF Inválido!", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                }
                else
                {
                    if (LocatarioDAO.Atualizar(Locatario))
                    {
                        MessageBox.Show("Locatario salvo com sucesso!", "Imob",
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
            Locatario = LocatarioDAO.BuscarPorNome(txtNome.Text);
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {

                if (LocatarioDAO.BuscarPorNome(txtNome.Text) != null)
                {
                    txtId.Text = Locatario.Id.ToString();
                    txtNome.Text = Locatario.Nome;
                    txtEmail.Text = Locatario.Email;
                    txtTelefone.Text = Locatario.Telefone;
                    txtCPF.Text = Locatario.Cpf;
                    txtRendaDisponivel.Text = Locatario.RendaDisponivel.ToString();
                    txtCidade.Text = Locatario.Cidade;
                    txtUF.Text = Locatario.UF;
                }
                else
                {
                    MessageBox.Show("Nome não existe", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nome está Vazio", "Imob",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public void LimparFormulario()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtCidade.Clear();
            txtRendaDisponivel.Clear();
            txtUF.Clear();
        }

        private void BtnExluir_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text) || !string.IsNullOrWhiteSpace(txtCPF.Text) || !string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                !string.IsNullOrWhiteSpace(txtEmail.Text) || !string.IsNullOrWhiteSpace(txtCidade.Text) || !string.IsNullOrWhiteSpace(txtRendaDisponivel.Text) ||
                !string.IsNullOrWhiteSpace(txtUF.Text))
            {
                Locatario.Nome = txtNome.Text;
                Locatario.Cpf = txtCPF.Text;
                Locatario.Telefone = txtTelefone.Text;
                Locatario.Email = txtEmail.Text;
                Locatario.Cidade = txtCidade.Text;
                Locatario.RendaDisponivel = Convert.ToInt32(txtRendaDisponivel.Text);
                Locatario.UF = txtUF.Text;

                if (LocatarioDAO.Remover(Locatario))
                {
                    MessageBox.Show("Locatario excluído com sucesso!", "Imob",
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
