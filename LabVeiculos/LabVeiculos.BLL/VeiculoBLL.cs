using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabVeiculos.DAO;
using LabVeiculos.DAL;
using System.Data;

namespace LabVeiculos.BLL
{
    // Esta é a classe de regras de negócios
    public class VeiculoBLL
    {
        private VeiculoDAL veiculoDal;

        // construtor
        public VeiculoBLL()
        {
            // instanciando a classe veiculoDAL para ter acesso a seus métodos
            veiculoDal = new VeiculoDAL();
        }

        public int InsereVeiculo(Veiculo veiculo)
        {

            // se proprietario for nulo, vazio, etc...
            if (string.IsNullOrEmpty(veiculo.Proprietario) == true || string.IsNullOrWhiteSpace(veiculo.Proprietario))
            {
                 throw new Exception("Proprietário é obrigatório.");
            }

            // se placa for nulo, vazio, etc...
            if (string.IsNullOrEmpty(veiculo.Placa) == true || string.IsNullOrWhiteSpace(veiculo.Placa))
            {
                throw new Exception("Placa é obrigatória.");
            }

            // se CriadoPor for nulo, vazio, etc...
            if (string.IsNullOrEmpty(veiculo.CriadoPor) == true || string.IsNullOrWhiteSpace(veiculo.CriadoPor))
            {
                throw new Exception("É obrigatório declarar o autor da criação.");
            }

            // se marca for diferente de VW..... e....marca for diferente de GM.... e...
            if (veiculo.Marca != "VW" && veiculo.Marca != "GM" && veiculo.Marca != "FIAT" && veiculo.Marca != "FORD")
            {
                throw new Exception("Não é possível inserir veiculo que não seja das marcas VW, GM, FIAT, FORD");
            }

            if (veiculo.AnoFabricacao < 2010)
            {
                throw new Exception("Não é possível inserir veiculo com ano de fabricação anterior a 2010");
            }

            if ( veiculo.Placa.Length != 7)
            {
                throw new Exception("A placa deve ter que 7 dígitos");
            }

            int result = veiculoDal.InsereVeiculo(veiculo);

            return result;
        }


        /*
         * recebe placa como parâmetro da classe UI Controle... placa é a string de busca
         * envia placa para o método RetrieveVeiculos da classe VeiculosDAL
         * recebe o retorno de uma DataTable com os dados retornados da query
         * retorna o dt para a classe UI Controle
         */
        public DataTable RetrieveVeiculo(string placa)
        {
            DataTable dt = veiculoDal.RetrieveVeiculos(placa);

            return dt;
        }

    }
}
