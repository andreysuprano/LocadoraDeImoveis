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
    /// Lógica interna para frmImoveis.xaml
    /// </summary>
    public partial class frmImoveis : Window
    {
        private List<Imovel> itens = new List<Imovel>();
        public frmImoveis()
        {
            InitializeComponent();
            PopularDataGridInicial();
            dtaImovel.ItemsSource = itens;
            dtaImovel.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopularDataGridInicial();
            dtaImovel.Items.Refresh();            
        }

        private void ToolVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToolNovo_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarImovel frm = new frmCadastrarImovel();
            frm.ShowDialog();
        }

        private void PopularDataGridInicial()
        {
            var listaImoveis = ImovelDAO.Listar();
            foreach (var imovel in listaImoveis)
            {
                itens.Add(new Imovel()
                {
                    Id = imovel.Id,
                    Area = imovel.Area,
                    Cidade = imovel.Cidade,
                    Endereco = imovel.Endereco,
                    ValorAluguel = imovel.ValorAluguel, 
                    Locado = imovel.Locado,
                    TipoImovel = imovel.TipoImovel,
                    UF = imovel.UF
                });
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarComFiltro();
        }

        public void BuscarComFiltro()
        {

            if (Convert.ToBoolean(filtroDisponivel.IsChecked))
            {
                itens.Clear();
                itens = ImovelDAO.ListarPorFiltro("disponivel");
                dtaImovel.Items.Refresh();
            }
            else if(Convert.ToBoolean(filtroAlugado.IsChecked))
            {
                itens.Clear();
                itens = ImovelDAO.ListarPorFiltro("alugado");
                dtaImovel.Items.Refresh();
            }
            else
            {
                itens.Clear();
                PopularDataGridInicial();
                dtaImovel.Items.Refresh();
            }
        }

        private void Button_Editar_Click(object sender, RoutedEventArgs e)
        {
            frmEditaAtualizaImoveis frm = new frmEditaAtualizaImoveis();
            frm.BtnExluir.IsEnabled = false;
            frm.ShowDialog();
        }

        private void Button_Apagar_Click(object sender, RoutedEventArgs e)
        {
            frmEditaAtualizaImoveis frm = new frmEditaAtualizaImoveis();
            frm.BtnSalvar.IsEnabled = false;
            frm.ShowDialog();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            itens.Clear();
            PopularDataGridInicial();
            dtaImovel.Items.Refresh();
        }

        private void filtroDisponivel_Checked(object sender, RoutedEventArgs e)
        {
            filtroAlugado.IsEnabled = false;
        }

        private void filtroAlugado_Checked(object sender, RoutedEventArgs e)
        {
            filtroDisponivel.IsEnabled = false;
        }

        private void filtroDisponivel_Unchecked(object sender, RoutedEventArgs e)
        {
            filtroAlugado.IsEnabled = true;
        }

        private void filtroAlugado_Unchecked(object sender, RoutedEventArgs e)
        {
            filtroDisponivel.IsEnabled = true;
        }
    }
}
