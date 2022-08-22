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
using Newtonsoft.Json;

namespace AppImoveis.View
{
    /// <summary>
    /// Interação lógica para Cadastro.xam
    /// </summary>
    public partial class Cadastro : UserControl
    {
        
        public Cadastro()
        {
            InitializeComponent();
        }

        private void tb_CEP_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox cep = (TextBox)sender;
            
            if(cep.Text.Length == 8)
            {
                if (!cep.Text.Contains("-"))
                {
                    int validacao;
                    if(int.TryParse(cep.Text,out validacao))
                    {
                        BuscarEndereco(cep.Text);
                    }
                    else
                        MessageBox.Show("Digite o CEP corretamente.");
                }
            }
            else if(cep.Text.Length == 9)
            {
                if (cep.Text.Contains("-"))
                {
                    int validacao1, validacao2;
                    if (int.TryParse(cep.Text.Substring(0, 5), out validacao1) && int.TryParse(cep.Text.Substring(6, 3), out validacao2))
                        BuscarEndereco(cep.Text.Replace("-", ""));
                    else
                        MessageBox.Show("Digite o CEP corretamente.");

                }
                else
                    MessageBox.Show("Digite o CEP corretamente.");
            }
            else
            {
                tb_Bairro.Text = "";
                tb_Cidade.Text = "";
                tb_Log.Text = "";
                tb_Estado.Text = "";
            }

            
        }
        public async void BuscarEndereco (string cep)
        {
            
            HttpClient client = new HttpClient();
            API.EnderecoCompleto endereco = new API.EnderecoCompleto();
            string url = $"https://viacep.com.br/ws/{cep}/json/";


            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string enderecojson = await response.Content.ReadAsStringAsync();
                endereco = JsonConvert.DeserializeObject<API.EnderecoCompleto>(enderecojson);
                tb_Bairro.Text = endereco.bairro;
                tb_Cidade.Text = endereco.localidade;
                tb_Log.Text = endereco.logradouro;
                tb_Estado.Text = endereco.uf;
            }
           
 
        }
    }
}
