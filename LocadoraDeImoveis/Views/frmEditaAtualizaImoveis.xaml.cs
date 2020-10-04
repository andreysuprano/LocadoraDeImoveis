using LocadoraDeImoveis.DAL;
using LocadoraDeImoveis.Models;
using LocadoraDeImoveis.Utils;
using System;
using System.Windows;


namespace LocadoraDeImoveis.Views
{
    /// <summary>
    /// Lógica interna para frmEditaAtualizaImoveis.xaml
    /// </summary>
    public partial class frmEditaAtualizaImoveis : Window
    {
        private Imovel Imovel;
        public bool Exlcuir = false;
        public frmEditaAtualizaImoveis()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtArea.Text) || !string.IsNullOrWhiteSpace(txtId.Text) || !string.IsNullOrWhiteSpace(txtCidade.Text) ||
                !string.IsNullOrWhiteSpace(txtComissao.Text) || !string.IsNullOrWhiteSpace(txtDescricao.Text) || !string.IsNullOrWhiteSpace(txtRua.Text) ||
                !string.IsNullOrWhiteSpace(txtUF.Text) || !string.IsNullOrWhiteSpace(txtValorAluguel.Text))
            {

                Imovel.Area = Convert.ToDouble(txtArea.Text);
                Imovel.Cidade = txtCidade.Text;
                Imovel.Endereco = txtRua.Text;
                Imovel.Locado = false;
                Imovel.UF = txtUF.Text;
                Imovel.ValorAluguel = Convert.ToDouble(txtValorAluguel.Text);
                Imovel.TipoImovel.Comissao = Imovel.TipoImovel.Comissao;
                Imovel.TipoImovel.Descricao = Imovel.TipoImovel.Descricao;

                if (ImovelDAO.Atualizar(Imovel))
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


        private void BtnBuscaNome_Click(object sender, RoutedEventArgs e)
        {
            Imovel = ImovelDAO.BuscarPorId(Convert.ToInt32(txtId.Text));
            if (txtId.Text != null)
            {

                if (ImovelDAO.BuscarPorId(Convert.ToInt32(txtId.Text)) != null)
                {
                    Imovel = ImovelDAO.BuscarPorId(Convert.ToInt32(txtId.Text));
                    var tipoImovel = TipoImovelDAO.BuscarPorId(Convert.ToInt32(txtId.Text));
                    txtArea.Text = Imovel.Area.ToString();
                    txtCidade.Text = Imovel.Cidade;
                    txtRua.Text = Imovel.Endereco;
                    txtUF.Text = Imovel.UF;
                    txtValorAluguel.Text = Imovel.ValorAluguel.ToString();
                    txtId.IsEnabled = false;
                    txtDescricao.Text = tipoImovel.Descricao;
                    txtComissao.Text = tipoImovel.Comissao.ToString();
                }
                else
                {
                    MessageBox.Show("ID Inválido não existe", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Id está Vazio", "Imob",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public void LimparFormulario()
        {
            txtArea.Clear();
            txtCidade.Clear();
            txtComissao.Clear();
            txtDescricao.Clear();
            txtRua.Clear();
            txtUF.Clear();
            txtValorAluguel.Clear();
            txtId.IsEnabled = true;
        }

        private void BtnExluir_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtArea.Text) || !string.IsNullOrWhiteSpace(txtId.Text) || !string.IsNullOrWhiteSpace(txtCidade.Text) ||
                !string.IsNullOrWhiteSpace(txtComissao.Text) || !string.IsNullOrWhiteSpace(txtDescricao.Text) || !string.IsNullOrWhiteSpace(txtRua.Text) ||
                !string.IsNullOrWhiteSpace(txtUF.Text) || !string.IsNullOrWhiteSpace(txtValorAluguel.Text))
            {
                Imovel.Area = Convert.ToDouble(txtArea.Text);
                Imovel.Cidade = txtCidade.Text;
                Imovel.Endereco = txtRua.Text;                
                Imovel.UF = txtUF.Text;
                Imovel.ValorAluguel = Convert.ToDouble(txtValorAluguel.Text);
                Imovel.TipoImovel.Comissao = Convert.ToInt32(txtComissao.Text);
                Imovel.TipoImovel.Descricao = txtDescricao.Text;

                if (ImovelDAO.Remover(Imovel))
                {
                    MessageBox.Show("Imóvel excluído com sucesso!", "Imob",
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
