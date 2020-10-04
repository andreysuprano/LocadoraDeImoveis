﻿using LocadoraDeImoveis.DAL;
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
            itens = new List<Contrato>(); 
            itens= ContratoDAO.Listar();
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
                var contrato = ContratoDAO.BuscarPorId(Convert.ToInt32(txtBuscaPorNome.Text));
                itens.Clear();
                itens.Add(new Contrato()
                {
                    Id = contrato.Id,
                    ComissaoCorretor = contrato.ComissaoCorretor,
                    CriadoEm = contrato.CriadoEm,
                    DataVencimento = contrato.DataVencimento,
                    IdCorretor = contrato.IdCorretor,
                    IdImovel = contrato.IdImovel,
                    IdLocatario = contrato.IdLocatario,
                    ValorAluguel = contrato.ValorAluguel
                });
                ;
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