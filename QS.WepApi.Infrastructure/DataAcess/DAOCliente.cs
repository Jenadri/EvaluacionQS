using Microsoft.EntityFrameworkCore;
using QS.WebApi.Domain.Clientes;
using QS.WebApi.Domain.InfrastuctureContratos;
using QS.WepApi.Infrastructure.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace QS.WepApi.Infrastructure.DataAcess
{
    public class DAOCliente : ICliente
    {
        private readonly EvaluacionQS_Context Context;
        public DAOCliente(EvaluacionQS_Context _context)
        {
            Context = _context;
        }
        public List<Cliente> DAOGetClientesCatASinFacturas()
        {
            List<Cliente> listClient = null;
            using (DbCommand command = this.Context.Database.GetDbConnection().CreateCommand())
            {
                try
                {
                    this.Context.Database.OpenConnection();
                    command.CommandText = "SP_GetClientes_A_SinFacturas";
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.Add(new SqlParameter("@cantDays", cantDays));
                    DbDataReader reader = command.ExecuteReader();

                    listClient = new List<Cliente>();

                    while (reader.Read())
                    {
                        Cliente cli = new Cliente();
                        cli.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                        cli.Nombres = reader["Nombres"].ToString();
                        cli.Apellidos = reader["Apellidos"].ToString();
                        cli.Nic = reader["Nic"].ToString();
                        cli.Categoria = Convert.ToChar(reader["Categoria"]);

                        listClient.Add(cli);
                    }
                }
                catch (Exception exception)
                {
                    listClient = null;
                    throw new Exception(exception.Message, exception);
                }
                finally
                {
                    this.Context.Database.CloseConnection();
                }
                return listClient;
            }
        }
    }
}
