using LocadoraDeImoveis.DAL;
using LocadoraDeImoveis.Utils;
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
    /// Lógica interna para frmGerarPdf.xaml
    /// </summary>
    public partial class frmGerarPdf : Window
    {
        public frmGerarPdf()
        {
            InitializeComponent();
        }

        private void BrnGerarPdf_Click(object sender, RoutedEventArgs e)
        {
            if (ContratoDAO.BuscarPorId(Convert.ToInt32(IdContrato.Text)) != null){
                var contrato = ContratoDAO.BuscarPorId(Convert.ToInt32(IdContrato.Text));
                var corretor = CorretorDAO.BuscarPorId(contrato.IdCorretor);
                var imovel = ImovelDAO.BuscarPorId(contrato.IdImovel);                
                var locatario = LocatarioDAO.BuscarPorId(contrato.IdLocatario);
                
                GeradorDeCpfUtils.GetPdf(contrato, corretor, imovel, locatario);
            }
            else
            {
                MessageBox.Show("Contrato não existe!", "Imob",
                MessageBoxButton.OK, MessageBoxImage.Information);
                LimparFormulario();
            }
        }
        private void LimparFormulario()
        {
            IdContrato.Clear();
        }
    }
}
