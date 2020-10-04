using LocadoraDeImoveis.DAL;
using LocadoraDeImoveis.Models;
using System;
using System.Windows;


namespace LocadoraDeImoveis.Views
{
    /// <summary>
    /// Lógica interna para frmCadastrarContrato.xaml
    /// </summary>
    public partial class frmCadastrarContrato : Window
    {
        Contrato Contrato;
        public frmCadastrarContrato()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar os dados de Locatario
            cboLocatario.ItemsSource = LocatarioDAO.Listar();
            cboLocatario.DisplayMemberPath = "Nome";
            cboLocatario.SelectedValuePath = "Id";

            //Carregar os dados de vendedores
            cboCorretor.ItemsSource = CorretorDAO.Listar();
            cboCorretor.DisplayMemberPath = "Nome";
            cboCorretor.SelectedValuePath = "Id";

            //Carregar os dados de produtos
            cboImovel.ItemsSource = ImovelDAO.Listar();
            cboImovel.DisplayMemberPath = "Endereco";
            cboImovel.SelectedValuePath = "Id";
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if(cboCorretor.SelectedValue != null || cboImovel.SelectedValue != null || cboLocatario.SelectedValue != null || txtDataVencimento.SelectedDate != null)
            {
                var Corretor = CorretorDAO.BuscarPorId((int)cboCorretor.SelectedValue);
                var Imovel = ImovelDAO.BuscarPorId((int)cboImovel.SelectedValue);
                var TipoImovel = TipoImovelDAO.BuscarPorId((int)cboImovel.SelectedValue);
                var Locatario = LocatarioDAO.BuscarPorId((int)cboLocatario.SelectedValue);
                Contrato = new Contrato()
                {
                    ComissaoCorretor = (TipoImovel.Comissao * 0.01) * Imovel.ValorAluguel,
                    DataVencimento = txtDataVencimento.SelectedDate.Value,
                    IdCorretor = Corretor.Id,
                    IdImovel = Imovel.Id,
                    IdLocatario = Locatario.Id,
                    ValorAluguel = Imovel.ValorAluguel
                };
                if(Imovel.Locado != true)
                {
                    if (Imovel.ValorAluguel <= Locatario.RendaDisponivel)
                    {
                        if (Imovel.Cidade  == Locatario.Cidade && Imovel.UF == Locatario.UF)
                        {
                            if (ContratoDAO.Cadastrar(Contrato))
                            {
                                Imovel.Locado = true;
                                ImovelDAO.Atualizar(Imovel);
                                MessageBox.Show("Contrato salvo com sucesso!", "Imob",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("Erro interno: contate um ADM!", "Imob",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Locatario não pertence a este Estado nem Cidade!", "Imob",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valor do aluguel excede a renda disponivel!", "Imob",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Imovel já está locado!", "Imob",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios!", "Imob",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }    

    }
}
