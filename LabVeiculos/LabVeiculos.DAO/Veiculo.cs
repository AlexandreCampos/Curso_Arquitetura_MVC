using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVeiculos.DAO
{

    // esta classe tem a função de armazenar objetos para toda a Solução
    public class Veiculo
    {

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Cor { get; set; }
        public string Proprietario { get; set; }
        public string CriadoPor { get; set; }
        public string Placa { get; set; }

    }
}
