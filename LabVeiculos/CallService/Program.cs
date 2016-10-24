using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallService;
using CallService.MeuServicoVeiculo;
using System.Data;


namespace CallService
{

    // Classe do "main" do WebService
    public class Program
    {
        static void Main(string[] args)
        {

            // consultar um veículo pela placa, e exiba todos os outros dados do mesmo. 

            ServiceVeiculoClient s = new ServiceVeiculoClient();
            DataTable dt = s.GetVeiculo("xxx0000");


            if (dt.Rows.Count >= 1)
            {

                //Se dt contem um ou mais valores estou utilizando o valor do index 0
                Console.WriteLine(dt.Rows[0]["ID"].ToString());               
                Console.WriteLine(dt.Rows[0]["MARCA"].ToString());
                Console.WriteLine(dt.Rows[0]["MODELO"].ToString());
                Console.WriteLine(Convert.ToInt32(dt.Rows[0]["ANOMODELO"]));
                Console.WriteLine(Convert.ToInt32(dt.Rows[0]["ANOFABRICACAO"].ToString()));
                Console.WriteLine(dt.Rows[0]["COR"].ToString());
                Console.WriteLine(dt.Rows[0]["PROPRIETARIO"].ToString());
                Console.WriteLine(dt.Rows[0]["CRIADOPOR"].ToString());
                Console.WriteLine(dt.Rows[0]["PLACA"].ToString());
                
            }

            Console.ReadKey();
        }
    }
}
