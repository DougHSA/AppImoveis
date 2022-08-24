using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            CarregarTabela();
           
        }

        private void CarregarTabela()
        {
            _ = CarregarValoresAsync();
        }

        private async Task CarregarValoresAsync()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:5001/api/");
            HttpResponseMessage Response = await Client.GetAsync("Imoveltbs");
            Imoveltb Imovel = new Imoveltb();

            if (Response.IsSuccessStatusCode)
            {
                string Json = await Response.Content.ReadAsStringAsync();
                var teste = JsonConvert.DeserializeObject< List<Imoveltb>>(Json);
                //var teste = JsonConvert.DeserializeObject<Dictionary<string, List<Imoveltb>>>(Json);
                List<Imoveltb> ListaImoveis = teste.ToList();
                DataGrid1.Items.Clear();
                foreach(var item in ListaImoveis)
                {
                    DataGrid1.Items.Add(new
                    {
                        CEP = item.Cep,
                        Estado = item.Estado,
                        Cidade = item.Cidade,
                        Bairro = item.Bairro,
                        Logradouro = item.Logradouro,
                        Numero = item.Numero,
                        Complemento = item.Complemento
                    }) ;
                }
            }
            else
            {
                MessageBox.Show("Error");
            }

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
