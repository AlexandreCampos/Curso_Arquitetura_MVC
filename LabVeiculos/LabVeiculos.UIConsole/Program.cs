using LabVeiculos.BLL;
using LabVeiculos.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVeiculos.UIConsole
{

    // camada responsável pelas Telas, Interfaces Gráficas, etc
    // neste caso, é a classe responsável pela tela direta ao usuário
    public class Program
    {
        public static void Main(string[] args)
        {
        
            // instancia objeto Veiculo da camada DAO para poder utilizar as propriedades (marca, modelo, etc)
            Veiculo veiculo = new Veiculo();


            // códigos abaixo recebem dados do usuário na Tela


            /*
             * testar While para manter tela com usuário qd houver erro
             * */


            Console.Write("Insira a marca: ");
            veiculo.Marca = Console.ReadLine();

            Console.Write("Insira o modelo: ");
            veiculo.Modelo = Console.ReadLine();

            Console.Write("Insira o ano do modelo: ");
            veiculo.AnoModelo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insira o ano de fabricação: ");
            veiculo.AnoFabricacao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insira a cor: ");
            veiculo.Cor = Console.ReadLine();

            Console.Write("Insira o proprietario: ");
            veiculo.Proprietario = Console.ReadLine();

            Console.Write("Insira a placa: ");
            veiculo.Placa = Console.ReadLine();

            veiculo.CriadoPor = "Alexandre";


            // instancia VeiculoBLL para ter acesso a camada de negócios
            VeiculoBLL veiculoBLL = new VeiculoBLL();


            // se a inserção ocorrer corretamente...
            try
            {
                veiculoBLL.InsereVeiculo(veiculo);
                Console.WriteLine("Inserido com sucesso");
            }
                // se der algum erro...
            catch (Exception e)
            {
                // mostra na Tela a msg de erro correspondente
                Console.WriteLine(e.Message);
                
            }
            Console.ReadKey();

        }
    }
}
