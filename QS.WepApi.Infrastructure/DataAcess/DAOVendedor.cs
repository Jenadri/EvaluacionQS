using Microsoft.EntityFrameworkCore;
using QS.WebApi.Domain.InfrastuctureContratos;
using QS.WebApi.Domain.Vendedores;
using QS.WepApi.Infrastructure.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace QS.WepApi.Infrastructure.DataAcess
{
    public class DAOVendedor : IVendedor
    {
        private readonly EvaluacionQS_Context Context;
        public DAOVendedor(EvaluacionQS_Context _context)
        {
            Context = _context;
        }

        public List<Vendedor> DAOGetVendedores2019()
        {
            List<Vendedor> listVendedor = null;
            using (DbCommand command = this.Context.Database.GetDbConnection().CreateCommand())
            {
                try
                {
                    this.Context.Database.OpenConnection();
                    command.CommandText = "SP_GetVendedor2019";
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.Add(new SqlParameter("@cantDays", cantDays));
                    DbDataReader reader = command.ExecuteReader();

                    listVendedor = new List<Vendedor>();

                    while (reader.Read())
                    {
                        Vendedor vendor = new Vendedor();
                        vendor.VendedorId = Convert.ToInt32(reader["VendedorId"]);
                        vendor.Nombres = reader["Nombres"].ToString();
                        vendor.Apellidos = reader["Apellidos"].ToString();
                        vendor.DNI = reader["DNI"].ToString();
                        vendor.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);

                        listVendedor.Add(vendor);
                    }
                }
                catch (Exception exception)
                {
                    listVendedor = null;
                    throw new Exception(exception.Message, exception);
                }
                finally
                {
                    this.Context.Database.CloseConnection();
                }
                return listVendedor;
            }
        }
    }
}
