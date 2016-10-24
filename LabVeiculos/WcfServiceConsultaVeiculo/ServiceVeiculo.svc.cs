using LabVeiculos.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceConsultaVeiculo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceVeiculo" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceVeiculo.svc or ServiceVeiculo.svc.cs at the Solution Explorer and start debugging.
    public class ServiceVeiculo : IServiceVeiculo
    {
        public DataTable GetVeiculo(string placa)
        {
            
            VeiculoBLL veiculoBll = new VeiculoBLL();
            DataTable dt = veiculoBll.RetrieveVeiculo(placa);

            return dt;
        }
    }
}
