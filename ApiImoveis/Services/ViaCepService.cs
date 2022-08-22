using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppImoveis.Services
{
    class ViaCepService
    {
        public static async Task<ViaCep.EnderecoCompleto> BuscarEndereco(string cep)
        {

            HttpClient client = new HttpClient();
            ViaCep.EnderecoCompleto endereco = new ViaCep.EnderecoCompleto();
            string url = $"https://viacep.com.br/ws/{cep}/json/";


            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string enderecojson = await response.Content.ReadAsStringAsync();
                endereco = JsonConvert.DeserializeObject<ViaCep.EnderecoCompleto>(enderecojson);
                return endereco;
            } else
            {
                return null;
            }
        }
    }
}
