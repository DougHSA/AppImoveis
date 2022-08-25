using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
    public partial class Alterar : UserControl
    {
        public Alterar()
        {
            InitializeComponent();
        }

        private void tb_CEP_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private async void CarregarEndereco(string Cep)
        {

            EnderecoCompleto Endereco = new EnderecoCompleto();

            Endereco = await ViaCepAPI.BuscarEndereco(Cep.Replace("-", ""));

        }

        private void onConfirmar(object sender, RoutedEventArgs e)
        {
            Cliente Pessoa = new Cliente();
            Pessoa.Nome = tb_NomeProp.Text;
            Pessoa.Cpf =Convert.ToInt64( tb_CPF.Text);
            Pessoa.Email = tb_Email.Text;
            Pessoa.Telefone = tb_Telefone.Text;

            _ = AtualizarCliente(Pessoa.Cpf, Pessoa);







        }

        private async Task AtualizarCliente(long cpf, Cliente pessoa)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:5001/api/");
            Client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            HttpRequestMessage RequestCliente = new HttpRequestMessage(HttpMethod.Put, $"Clientes/{cpf}");

            string PessoaJson = JsonConvert.SerializeObject(pessoa);

            RequestCliente.Content = new StringContent(PessoaJson,
                                                Encoding.UTF8,
                                                "application/json");

            await Client.SendAsync(RequestCliente)
                 .ContinueWith(responseTask =>
                 {
                     Console.WriteLine("Response: {0}", responseTask.Result);
                     if(responseTask.Result.IsSuccessStatusCode)
                     MessageBox.Show("Atualizado com sucesso.");
                 });


        }

        private void tb_CPF_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                
                TextBox cpf = (TextBox)sender;
                long Newcpf = Convert.ToInt64(cpf.Text);
                BuscaNomeAsync(Newcpf);

                

            }
            
        }

        private async void BuscaNomeAsync(long cpf)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:5001/api/");
            
            HttpResponseMessage ResponseCliente = await Client.GetAsync($"Clientes/{cpf}");

            if (ResponseCliente.IsSuccessStatusCode)
            {

                string Json = await ResponseCliente.Content.ReadAsStringAsync();
                var Cliente = JsonConvert.DeserializeObject<Cliente>(Json);
                tb_Email.Text = Cliente.Email;
                tb_NomeProp.Text = Cliente.Nome;
                tb_Telefone.Text = Cliente.Telefone;
            }
            else
            {
                MessageBox.Show("Error");
             
            }
        }
    }
}

