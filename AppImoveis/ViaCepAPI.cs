using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppImoveis
{
    class ViaCepAPI
    {
        public static async Task<EnderecoCompleto> BuscarEndereco(string cep)
        {

            HttpClient Client = new HttpClient();
            EnderecoCompleto Endereco = new EnderecoCompleto();
            string url = $"https://viacep.com.br/ws/{cep}/json/";


            HttpResponseMessage Response = await Client.GetAsync(url);
            if (Response.IsSuccessStatusCode)
            {
                string EnderecoJson = await Response.Content.ReadAsStringAsync();
                Endereco = JsonConvert.DeserializeObject<EnderecoCompleto>(EnderecoJson);
                return Endereco;
            } else
            {
                return null;
            }
        }
    }
}
