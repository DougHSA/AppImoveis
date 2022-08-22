using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppImoveis.View
{
    /// <summary>
    /// Interação lógica para Cadastro.xam
    /// </summary>
    public partial class Consulta : UserControl
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarValores();
        }

        private void CarregarValores()
        {
            
        }

        private void onPesquisar(object sender, RoutedEventArgs e)
        {
            if (tb_Bairro.Text != "" && tb_Cidade.Text!= "" && tb_Estado.Text!="")
            {
                
            }
            else if (tb_Bairro.Text != "" && tb_Cidade.Text != "" && tb_Estado.Text == "")
            {

            }
            else if (tb_Bairro.Text != "" && tb_Cidade.Text == "" && tb_Estado.Text != "")
            {

            }
            else if (tb_Bairro.Text != "" && tb_Cidade.Text == "" && tb_Estado.Text == "")
            {

            }
            else if (tb_Bairro.Text == "" && tb_Cidade.Text != "" && tb_Estado.Text != "")
            {

            }
            else if (tb_Bairro.Text == "" && tb_Cidade.Text != "" && tb_Estado.Text == "")
            {

            }
            else if (tb_Bairro.Text == "" && tb_Cidade.Text == "" && tb_Estado.Text != "")
            {

            }
            else if (tb_Bairro.Text == "" && tb_Cidade.Text == "" && tb_Estado.Text == "")
            {

            }
        }
    }
}
