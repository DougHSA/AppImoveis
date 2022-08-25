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
    public partial class Remover : UserControl
    {
        private bool CEPok = false;
        public Remover()
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

                if (Cep.Text.Length == 5)
                {
                    Cep.Text = Cep.Text.Substring(0, 5) + "-";
                    Cep.CaretIndex = Cep.Text.Length;
                }
                else if (Cep.Text.Length > 5)
                {
                    if (!Cep.Text.Contains("-"))
                    {
                        Cep.Text = Cep.Text.Substring(0, 5) + "-" + Cep.Text.Substring(5, Cep.Text.Length - 5);
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

        private async void CarregarEndereco(string Cep)
        {

            EnderecoCompleto Endereco = new EnderecoCompleto();

            Endereco = await ViaCepAPI.BuscarEndereco(Cep.Replace("-", ""));

            tb_Bairro.Text = Endereco.bairro;
            tb_Cidade.Text = Endereco.localidade;
            tb_Log.Text = Endereco.logradouro;
            tb_Estado.Text = Endereco.uf;
        }

        private void onConfirmar(object sender, RoutedEventArgs e)
        {
            
            int NewCep =Convert.ToInt32( tb_CEP.Text.Replace("-", ""));

            var resultado = DeletarEndereco(NewCep, tb_Numero.Text);

            tb_Bairro.Text = "";
            tb_Cidade.Text = "";
            tb_Log.Text = "";
            tb_Estado.Text = "";
            tb_CEP.Text = "";
            tb_Numero.Text = "";






        }

        private async Task DeletarEndereco(int cep, string numero)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:5001/api/");
            Client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            HttpRequestMessage RequestImovel = new HttpRequestMessage(HttpMethod.Delete, $"Imoveltbs/cep/{cep}/num/{numero}");
            await Client.SendAsync(RequestImovel)
                 .ContinueWith(responseTask =>
                 {
                     Console.WriteLine("Response: {0}", responseTask.Result);
                     MessageBox.Show("Deletado com sucesso.");
                 });


        }
    }
}

