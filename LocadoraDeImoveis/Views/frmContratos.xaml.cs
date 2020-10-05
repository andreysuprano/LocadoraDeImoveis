using LocadoraDeImoveis.DAL;
using LocadoraDeImoveis.Models;
using System;
using System.Collections.Generic;
using System.Windows;


namespace LocadoraDeImoveis.Views
{
    /// <summary>
    /// Lógica interna para frmContratos.xaml
    /// </summary>
    public partial class frmContratos : Window
    {
        private List<Contrato> itens = new List<Contrato>();
        public frmContratos()
        {
            InitializeComponent();
            PopularDataGridInicial();
            dtaContratos.ItemsSource = itens;
            dtaContratos.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopularDataGridInicial();
            dtaContratos.Items.Refresh();
        }

        private void ToolVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToolNovo_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarContrato frm = new frmCadastrarContrato();
            frm.ShowDialog();
        }

        private void PopularDataGridInicial()
        {
            itens.Clear();
            var listaDeContratos = ContratoDAO.Listar();
            foreach (var contrato in listaDeContratos)
            {
                itens.Add(new Contrato()
                {
                    Id = contrato.Id,
                    LocatarioId = contrato.LocatarioId,
                    CorretorId = contrato.CorretorId,
                    ImovelId = contrato.ImovelId,
                    ComissaoCorretor = contrato.ComissaoCorretor,
                    CriadoEm = contrato.CriadoEm,
                    DataVencimento = contrato.DataVencimento,
                    ValorAluguel = contrato.ValorAluguel,
                    Imovel = contrato.Imovel,
                    Corretor = contrato.Corretor,
                    Locatario = contrato.Locatario
                });
            }
            dtaContratos.Items.Refresh();
        }

        public void EnterBusca(object sender, RoutedEventArgs e)
        {
            BuscarComFiltro();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarComFiltro();
        }

        public void BuscarComFiltro()
        {
            if (!string.IsNullOrWhiteSpace(txtBuscaPorNome.Text))
            {
                var contratos = ContratoDAO.BuscarPorCorretor(txtBuscaPorNome.Text);
                itens.Clear();                
                foreach (var contrato in contratos)
                {
                    itens.Add(new Contrato()
                    {
                        Id = contrato.Id,
                        LocatarioId = contrato.LocatarioId,
                        CorretorId = contrato.CorretorId,
                        ImovelId = contrato.ImovelId,
                        ComissaoCorretor = contrato.ComissaoCorretor,
                        CriadoEm = contrato.CriadoEm,
                        DataVencimento = contrato.DataVencimento,
                        ValorAluguel = contrato.ValorAluguel,
                        Imovel = contrato.Imovel,
                        Corretor = contrato.Corretor,
                        Locatario = contrato.Locatario
                    });
                }
                dtaContratos.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Campo de busca está em branco", "Imob", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void Button_Editar_Click(object sender, RoutedEventArgs e)
        {
            frmGerarPdf frm = new frmGerarPdf();            
            frm.ShowDialog();
        }        

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            itens.Clear();
            PopularDataGridInicial();
            dtaContratos.Items.Refresh();
        }
    }
}
