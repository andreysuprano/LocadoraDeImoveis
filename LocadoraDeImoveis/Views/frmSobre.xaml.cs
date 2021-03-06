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
    /// Lógica interna para frmSobre.xaml
    /// </summary>
    public partial class frmSobre : Window
    {
        public frmSobre()
        {
            InitializeComponent();
        }
        private void menuSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Você está fechando esta janela de informações, e voltará ao sistema!", "IMob - Aluguel de Imóveis no Brasil", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.No)
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
