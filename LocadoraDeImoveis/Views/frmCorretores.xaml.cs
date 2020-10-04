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
    /// Interaction logic for frmCorretores.xaml
    /// </summary>
    public partial class frmCorretores : Window
    {
        private List<Corretor> itens = new List<Corretor>();
        public frmCorretores()
        {
            InitializeComponent();
            PopularDataGridInicial();
            dtaCorretores.ItemsSource = itens;
            dtaCorretores.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopularDataGridInicial();
            dtaCorretores.Items.Refresh();
        }

        private void ToolVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToolNovo_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarCorretor frmCadastrarCorretor = new frmCadastrarCorretor();            
            frmCadastrarCorretor.ShowDialog();
        }

        private void PopularDataGridInicial()
        {
            var listaDeCorretores = CorretorDAO.Listar();
            foreach (var corretor in listaDeCorretores)
            {
                itens.Add(new Corretor()
                {
                    Nome = corretor.Nome,
                    Cpf = corretor.Cpf,
                    Cidade = corretor.Cidade,
                    Cofeci = corretor.Cofeci,
                    Email = corretor.Email,
                    Telefone = corretor.Telefone,
                    UF = corretor.UF,
                    Id = corretor.Id
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
                var corretor = CorretorDAO.BuscarPorNome(txtBuscaPorNome.Text);
                itens.Clear();
                itens.Add(new Corretor()
                {
                    Nome = corretor.Nome,
                    Cpf = corretor.Cpf,
                    Cidade = corretor.Cidade,
                    Cofeci = corretor.Cofeci,
                    Email = corretor.Email,
                    Telefone = corretor.Telefone,
                    UF = corretor.UF,
                    Id = corretor.Id
                });
                dtaCorretores.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Campo de busca está em branco", "Imob", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void Button_Editar_Click(object sender, RoutedEventArgs e)
        {            
            frmEditaAtualizaCorretor frm = new frmEditaAtualizaCorretor();
            frm.BtnExluir.IsEnabled = false;
            frm.ShowDialog();            
        }

        private void Button_Apagar_Click(object sender, RoutedEventArgs e)
        {
            frmEditaAtualizaCorretor frm = new frmEditaAtualizaCorretor();
            frm.BtnSalvar.IsEnabled = false;
            frm.ShowDialog();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            itens.Clear();
            PopularDataGridInicial();
            dtaCorretores.Items.Refresh();
        }
    }
}
