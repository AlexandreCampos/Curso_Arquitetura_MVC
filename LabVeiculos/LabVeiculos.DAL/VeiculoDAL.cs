using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabVeiculos.DAL;
using LabVeiculos.DAO;
using System.Data.SqlClient;
using System.Data; 

namespace LabVeiculos.DAL
{
    public class VeiculoDAL : Base
    {
        Veiculo veiculo;

        public int InsereVeiculo(Veiculo veiculo)
        {
            int result = 0;

            string query = "INSERT INTO [dbo].[Veiculos] ([Marca] ,[Modelo], [AnoModelo], [AnoFabricacao], [Cor], [Proprietario], [CriadoPor], [Placa]) Values('" + veiculo.Marca + "','" + veiculo.Modelo + "'," + veiculo.AnoModelo + "," + veiculo.AnoFabricacao + ",'" + veiculo.Cor + "','" + veiculo.Proprietario + "','" + veiculo.CriadoPor + "','" + veiculo.Placa + "') ";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // tratar erro
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return result;
        }


        // retorna uma DataTable com resultado da query
        public DataTable RetrieveVeiculos(string placa)
        {

            //dt armazenará o resultado da busca
            DataTable dt = new DataTable("QueryVeiculos");

            string query = @"

                            SELECT [ID]
                              ,[MARCA]
                              ,[MODELO]
                              ,[ANOMODELO]
                              ,[ANOFABRICACAO]
                              ,[COR]
                              ,[PROPRIETARIO]
                              ,[CRIADOPOR]
                              ,[PLACA]
                         FROM [dbo].[VEICULOS]
                         WHERE [PLACA] = '{0}'";

            query = string.Format(query, placa);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //Adiciona o resultado da busca em dt
                    dt.Load(dr);
                    conn.Close();

                }

            }

            if (dt.Rows.Count >= 1)
            {

                //Se dt contem um ou mais valores estou utilizando o valor do index 0
                string id = dt.Rows[0].ToString();             
                string marca = dt.Rows[0]["MARCA"].ToString();
                string modelo = dt.Rows[0]["MODELO"].ToString();
                int anoModelo = Convert.ToInt32(dt.Rows[0]["ANOMODELO"]);
                int anoFabricacao = Convert.ToInt32(dt.Rows[0]["ANOFABRICACAO"].ToString());
                string cor = dt.Rows[0]["COR"].ToString();
                string proprietario = dt.Rows[0]["PROPRIETARIO"].ToString();
                string criadoPor = dt.Rows[0]["CRIADOPOR"].ToString();
                string placa1 = dt.Rows[0]["PLACA"].ToString();

            }

            else if (dt.Rows.Count == 0)
            {

                //A busca não retornou nada

            }

            else
            {
            //Percorre todo dt
            //foreach (DataRow row in dt.Rows)
            //{
            //    string nome = row["NOME"].ToString();
            //    string id = row["ID"].ToString();
            //    string marca = row["MARCA"].ToString();
            //    string modelo = row["MODELO"].ToString();
            //    int anoModelo = Convert.ToInt32(row["ANOMODELO"]);
            //    int anoFabricacao = Convert.ToInt32(row["ANOFABRICACAO"].ToString());
            //    string cor = row["COR"].ToString();
            //    string proprietario = row["PROPRIETARIO"].ToString();
            //    string criadoPor = row["CRIADOPOR"].ToString();
            //    string placa1 = row["PLACA"].ToString();
            //}
            }
            return dt;
        }

    }
}
