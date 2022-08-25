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
    public partial class Cadastro : UserControl
    {
        private bool CEPok = false;
        public Cadastro()
        {
            InitializeComponent();
        }

        private void tb_CEP_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox Cep = (TextBox)sender;


            if (Cep.Text.Length == 9)
            {
                if (Cep.Text.Contains("-"))
                {
                    int validacao1, validacao2;
                    if (int.TryParse(Cep.Text.Substring(0, 5), out validacao1) && int.TryParse(Cep.Text.Substring(6, 3), out validacao2))
                    {
                        
                        CarregarEndereco(Cep.Text);
                        CEPok = true;
                        
                    }
                }
                else
                {
                    CEPok = false;
                    MessageBox.Show("Digite o CEP corretamente.");
                }
            }
            else
            {
                CEPok = false;
                tb_Bairro.Text = "";
                tb_Cidade.Text = "";
                tb_Log.Text = "";
                tb_Estado.Text = "";

                if(Cep.Text.Length == 5)
                {
                    Cep.Text = Cep.Text.Substring(0, 5) + "-";
                    Cep.CaretIndex = Cep.Text.Length;
                }
                else if (Cep.Text.Length > 5)
                {
                    if (!Cep.Text.Contains("-"))
                    {
                            Cep.Text = Cep.Text.Substring(0, 5) + "-" + Cep.Text.Substring(5, Cep.Text.Length-5);
                            Cep.CaretIndex = Cep.Text.Length;
                    }
                }
                else if (Cep.Text.Length > 9)
                {
                    Cep.Text = Cep.Text.Substring(0, 9);
                    Cep.CaretIndex = Cep.Text.Length;
                }
            }
        }

        private async void  CarregarEndereco(string Cep)
        {
            
            EnderecoCompleto Endereco = new EnderecoCompleto();
           
            Endereco = await ViaCepAPI.BuscarEndereco(Cep.Replace("-", ""));

            tb_Bairro.Text = Endereco.bairro;
            tb_Cidade.Text = Endereco.localidade;
            tb_Log.Text = Endereco.logradouro;
            tb_Estado.Text = Endereco.uf;
        }

        public static Task<HttpResponseMessage> resposta;

        private void onCadastrar(object sender, RoutedEventArgs e)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:5001/api/");
            Client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            HttpRequestMessage RequestImovel = new HttpRequestMessage(HttpMethod.Post, "Imoveltbs");
            HttpRequestMessage RequestCliente = new HttpRequestMessage(HttpMethod.Post, "Clientes");
            HttpRequestMessage RequestProp = new HttpRequestMessage(HttpMethod.Post, "Proprietarios");

            Imoveltb Imovel = new Imoveltb();
            Cliente Pessoa = new Cliente();
            Proprietario Prop = new Proprietario();


            Imovel.Alugado = 0;
            Imovel.Bairro = tb_Bairro.Text;
            Imovel.Cep = Convert.ToInt32(tb_CEP.Text.Replace("-", ""));
            Imovel.Cidade = tb_Cidade.Text;
            Imovel.Complemento = tb_Comp.Text;
            Imovel.Estado = tb_Estado.Text;
            Imovel.Numero = tb_Numero.Text;
            Imovel.Logradouro = tb_Log.Text;

            Pessoa.Cpf =Convert.ToInt64(tb_CPF.Text.Replace(".", "").Replace("-", ""));
            Pessoa.Email = tb_Email.Text;
            Pessoa.Nome = tb_NomeProp.Text;
            Pessoa.Telefone = tb_Telefone.Text;

            //Prop.Cpf = Pessoa.Cpf;
            



            string ImovelJson = JsonConvert.SerializeObject(Imovel);
            string PessoaJson = JsonConvert.SerializeObject(Pessoa);

            RequestImovel.Content = new StringContent(ImovelJson,
                                                Encoding.UTF8,
                                                "application/json");
            RequestCliente.Content = new StringContent(PessoaJson,
                                                Encoding.UTF8,
                                                "application/json");
           

            Client.SendAsync(RequestImovel)
                 .ContinueWith(responseTask =>
                 {
                     Console.WriteLine("Response: {0}", responseTask.Result);
                     MessageBox.Show(responseTask.Result.ToString());
                     resposta = responseTask;
                 });
            Client.SendAsync(RequestCliente)
                 .ContinueWith(responseTask =>
                 {
                     Console.WriteLine("Response: {0}", responseTask.Result);
                     MessageBox.Show(responseTask.ToString());
                 });
            tb_Bairro.Text = "";
            tb_Cidade.Text = "";
            tb_Log.Text = "";
            tb_Estado.Text = "";
            tb_CPF.Text = "";
            tb_Email.Text = "";
            tb_NomeProp.Text = "";
            tb_Telefone.Text = "";
            tb_CEP.Text = "";
            tb_Comp.Text = "";
            tb_Numero.Text = "";
        }
    }
}
