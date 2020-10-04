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
    /// Lógica interna para frmLocatarios.xaml
    /// </summary>
    public partial class frmLocatarios : Window
    {
        private List<Locatario> itens = new List<Locatario>();
        public frmLocatarios()
        {
            InitializeComponent();
            PopularDataGridInicial();
            dtaLocatarios.ItemsSource = itens;
            dtaLocatarios.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopularDataGridInicial();
            dtaLocatarios.Items.Refresh();
        }

        private void ToolVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToolNovo_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarLocatario frmCadastrarLocatario = new frmCadastrarLocatario();
            frmCadastrarLocatario.ShowDialog();
        }

        private void PopularDataGridInicial()
        {
            var listaDeLocatarios = LocatarioDAO.Listar();
            foreach (var locatarios in listaDeLocatarios)
            {
                itens.Add(new Locatario()
                {
                    Nome = locatarios.Nome,
                    Cpf = locatarios.Cpf,
                    Cidade = locatarios.Cidade,
                    RendaDisponivel = locatarios.RendaDisponivel,
                    Email = locatarios.Email,
                    Telefone = locatarios.Telefone,
                    UF = locatarios.UF,
                    Id = locatarios.Id
                });
            }
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
                var locatario = LocatarioDAO.BuscarPorNome(txtBuscaPorNome.Text);
                itens.Clear();
                itens.Add(new Locatario()
                {
                    Nome = locatario.Nome,
                    Cpf = locatario.Cpf,
                    Cidade = locatario.Cidade,
                    RendaDisponivel = locatario.RendaDisponivel,
                    Email = locatario.Email,
                    Telefone = locatario.Telefone,
                    UF = locatario.UF,
                    Id = locatario.Id
                });
                dtaLocatarios.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Campo de busca está em branco", "Imob", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void Button_Editar_Click(object sender, RoutedEventArgs e)
        {
            frmEditaAtualizaLocatario frm = new frmEditaAtualizaLocatario();
            frm.BtnExluir.IsEnabled = false;
            frm.ShowDialog();
        }

        private void Button_Apagar_Click(object sender, RoutedEventArgs e)
        {
            frmEditaAtualizaLocatario frm = new frmEditaAtualizaLocatario();
            frm.BtnSalvar.IsEnabled = false;
            frm.ShowDialog();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            itens.Clear();
            PopularDataGridInicial();
            dtaLocatarios.Items.Refresh();
        }
    }
}
