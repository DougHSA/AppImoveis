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
        private bool CEPok = false;
        public Cadastro()
        {
            InitializeComponent();
        }

        private void tb_CEP_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox cep = (TextBox)sender;


            if (cep.Text.Length == 9)
            {
                if (cep.Text.Contains("-"))
                {
                    int validacao1, validacao2;
                    if (int.TryParse(cep.Text.Substring(0, 5), out validacao1) && int.TryParse(cep.Text.Substring(6, 3), out validacao2))
                    {
                        
                        CarregarEndereco(cep.Text);
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

                if(cep.Text.Length == 5)
                {
                    cep.Text = cep.Text.Substring(0, 5) + "-";
                    cep.CaretIndex = cep.Text.Length;
                }
                else if (cep.Text.Length > 5)
                {
                    if (!cep.Text.Contains("-"))
                    {
                            cep.Text = cep.Text.Substring(0, 5) + "-" + cep.Text.Substring(5, cep.Text.Length-5);
                            cep.CaretIndex = cep.Text.Length;
                    }
                }
                else if (cep.Text.Length > 9)
                {
                    cep.Text = cep.Text.Substring(0, 9);
                    cep.CaretIndex = cep.Text.Length;
                }
            }
        }

        private async void  CarregarEndereco(string cep)
        {
            
            ViaCep.EnderecoCompleto endereco = new ViaCep.EnderecoCompleto();
           
            endereco = await Services.ViaCepService.BuscarEndereco(cep.Replace("-", ""));

            tb_Bairro.Text = endereco.bairro;
            tb_Cidade.Text = endereco.localidade;
            tb_Log.Text = endereco.logradouro;
            tb_Estado.Text = endereco.uf;
        }
    }
}
