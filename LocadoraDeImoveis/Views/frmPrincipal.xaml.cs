﻿using System;
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
    /// Interaction logic for frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Vendas WPF", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void AbrirCorretores_Click(object sender, RoutedEventArgs e)
        {
            frmCorretores frmCorretores = new frmCorretores();
            frmCorretores.Show();
        }

        private void AbrirLocatarios_Click(object sender, RoutedEventArgs e)
        {
            frmLocatarios frm = new frmLocatarios();
            frm.Show();
        }

        private void AbrirImoveis_Click(object sender, RoutedEventArgs e)
        {
            frmImoveis frm = new frmImoveis();
            frm.Show();
        }

        private void AbrirContratos_Click(object sender, RoutedEventArgs e)
        {
            frmContratos frm = new frmContratos();
            frm.Show();

        }

        private void AbrirSobre_Click(object sender, RoutedEventArgs e)
        {
            frmSobre frm = new frmSobre();
            frm.Show();
        }
    }
}
