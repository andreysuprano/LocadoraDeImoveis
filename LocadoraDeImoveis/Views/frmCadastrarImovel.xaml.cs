using LocadoraDeImoveis.DAL;
using LocadoraDeImoveis.Models;
using LocadoraDeImoveis.Utils;
using System;
using System.Windows;


namespace LocadoraDeImoveis.Views
{
    /// <summary>
    /// Lógica interna para frmCadastrarImovel.xaml
    /// </summary>
    public partial class frmCadastrarImovel : Window
    {

        Imovel Imovel { get; set; }
        BuscaCepUtils BuscaCep = new BuscaCepUtils();
        public frmCadastrarImovel()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtArea.Text) || !string.IsNullOrWhiteSpace(txtCEP.Text) || !string.IsNullOrWhiteSpace(txtCidade.Text) ||
                !string.IsNullOrWhiteSpace(txtComissao.Text) || !string.IsNullOrWhiteSpace(txtDescricao.Text) || !string.IsNullOrWhiteSpace(txtRua.Text) ||
                !string.IsNullOrWhiteSpace(txtUF.Text) || !string.IsNullOrWhiteSpace(txtValorAluguel.Text))
            {
                Imovel = new Imovel()
                {
                    Area = Convert.ToDouble(txtArea.Text),
                    Cidade = txtCidade.Text,
                    Endereco = txtRua.Text,
                    Locado = false,
                    UF = txtUF.Text,
                    ValorAluguel = Convert.ToDouble(txtValorAluguel.Text),
                    TipoImovel = new TipoImovel()
                    {
                        Comissao = Convert.ToInt32(txtComissao.Text),
                        Descricao = txtDescricao.Text
                    }

                };
                if (ImovelDAO.Cadastrar(Imovel))
                {
                    MessageBox.Show("Imóvel salvo com sucesso!", "Imob",
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
            txtArea.Clear();
            txtCidade.Clear();
            txtRua.Clear();
            txtUF.Clear();
            txtValorAluguel.Clear();
            txtComissao.Clear();
            txtDescricao.Clear();
        }

        private void BtnBuscaCep_Click(object sender, RoutedEventArgs e)
        {
            var Cep = BuscaCep.BuscarCepService(txtCEP.Text);
            txtCidade.Text = Cep.localidade;
            txtUF.Text = Cep.uf;
            txtRua.Text = Cep.logradouro;
        }
    }
}
