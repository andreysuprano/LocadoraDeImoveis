using LocadoraDeImoveis.DAL;
using LocadoraDeImoveis.Models;
using LocadoraDeImoveis.Utils;
using System;
using System.Windows;

namespace LocadoraDeImoveis.Views
{
    /// <summary>
    /// Lógica interna para frmCadastrarLocatario.xaml
    /// </summary>
    public partial class frmCadastrarLocatario : Window
    {
        Locatario Locatario { get; set; }
        BuscaCepUtils BuscaCep = new BuscaCepUtils();
        public frmCadastrarLocatario()
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
                !string.IsNullOrWhiteSpace(txtEmail.Text) || !string.IsNullOrWhiteSpace(txtCidade.Text) || !string.IsNullOrWhiteSpace(txtRendaDisponivel.Text) ||
                !string.IsNullOrWhiteSpace(txtUF.Text))
            {
                Locatario = new Locatario()
                {
                    Nome = txtNome.Text,
                    Cpf = txtCPF.Text,
                    Telefone = txtTelefone.Text,
                    Email = txtEmail.Text,
                    Cidade = txtCidade.Text,
                    RendaDisponivel = Convert.ToDouble(txtRendaDisponivel.Text.Replace(",",".")),
                    UF = txtUF.Text
                };
                if (!ValidacaoCpfUtils.ValidarCpf(txtCPF.Text) && !LocatarioDAO.BuscarPorCpf(txtCPF.Text))
                {
                    MessageBox.Show("CPF Inválido ou já está cadastrado", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (LocatarioDAO.Cadastrar(Locatario))
                    {
                        MessageBox.Show("Locatário salvo com sucesso!", "Imob",
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

        private void BtnBuscaCep_Click(object sender, RoutedEventArgs e)
        {
            var Cep = BuscaCep.BuscarCepService(txtCEP.Text);
            txtCidade.Text = Cep.localidade;
            txtUF.Text = Cep.uf;
        }
    }
}
