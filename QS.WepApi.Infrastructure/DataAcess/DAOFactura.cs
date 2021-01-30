using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QS.WebApi.Domain.Facturas;
using QS.WebApi.Domain.InfrastuctureContratos;
using QS.WepApi.Infrastructure.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace QS.WepApi.Infrastructure.DataAcess
{
    public class DAOFactura : IFactura
    {
        private readonly EvaluacionQS_Context Context;
        public DAOFactura(EvaluacionQS_Context _context)
        {
            Context = _context;
        }
        public List<Factura> DAOGetFacturas()
        {
            List<Factura> listFact = null;
            using (DbCommand command = this.Context.Database.GetDbConnection().CreateCommand())
            {
                try
                {
                    this.Context.Database.OpenConnection();
                    command.CommandText = "SP_GetFacturasByDay";
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.Add(new SqlParameter("@cantDays", cantDays));
                    DbDataReader reader = command.ExecuteReader();

                    listFact = new List<Factura>();

                    while (reader.Read())
                    {
                        Factura fact = new Factura();
                        fact.FacturaId = Convert.ToInt32(reader["FacturaId"]);                        
                        fact.Serie = reader["Serie"].ToString();
                        fact.Codigo = reader["Codigo"].ToString();
                        fact.VendedorId= Convert.ToInt32(reader["VendedorId"]);
                        fact.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                        fact.Fecha = Convert.ToDateTime(reader["Fecha"]);
                        fact.Moneda = reader["Moneda"].ToString();
                        fact.Dia = reader["Dia"].ToString();
                        fact.Importe = Convert.ToDecimal(reader["Importe"]);
                        fact.NombreCliente = reader["NombreCliente"].ToString();
                        fact.NombreVendedor = reader["NombreVendedor"].ToString();

                        listFact.Add(fact);
                    }
                }
                catch (Exception exception)
                {
                    listFact = null;
                    throw new Exception(exception.Message, exception);
                }
                finally
                {
                    this.Context.Database.CloseConnection();
                }
                return listFact;
            }
        }

        public bool DAOCreateFactura(Factura factura)
        {
            bool isCreate = false;
            try
            {
                if (!factura.Detalles.Any()) // La factura tendrá como mínimo un Producto
                {
                    isCreate = false;
                }
                else if (factura.Detalles.Where(q => q.Cantidad <= 0).Count() > 0)// Valida si la catidad de productos sea mayor a 0
                {
                    isCreate = false;
                }
                else
                {
                    int facturaId = InsertFactura(factura);
                    int detalleFacturaId = 0;
                    if (facturaId != 0)
                    {
                        foreach (var detalle in factura.Detalles)
                        {
                            detalle.FacturaId = facturaId;
                            detalleFacturaId = InsertDetalleFactura(detalle);
                        }
                        isCreate = true;
                    }
                    else
                    {
                        isCreate =  false;
                    }
                }
            }
            catch (Exception exception)
            {
                isCreate = false;
                throw new Exception(exception.Message, exception);
            }
            return isCreate;
        }

        private int InsertFactura(Factura factura)
        {
            int num = 0;
            using (DbCommand command = this.Context.Database.GetDbConnection().CreateCommand())
            {
                try
                {
                    this.Context.Database.OpenConnection();
                    command.CommandText = "SP_InsertFactura";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@VendedorId", factura.VendedorId));
                    command.Parameters.Add(new SqlParameter("@ClienteId", factura.ClienteId));
                    command.Parameters.Add(new SqlParameter("@Fecha", factura.Fecha));
                    command.Parameters.Add(new SqlParameter("@Moneda", factura.Moneda));

                    DbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        num = Convert.ToInt32(reader["FacturaId"].ToString());
                    }
                    this.Context.Database.CloseConnection();
                }
                catch (Exception exception)
                {
                    num = 0;
                    throw new Exception(exception.Message, exception);
                }
                finally
                {
                    this.Context.Database.CloseConnection();
                }

                return num;
            }
        }

        private int InsertDetalleFactura(DetalleFactura detalleFactura)
        {
            int num = 0;
            using (DbCommand command = this.Context.Database.GetDbConnection().CreateCommand())
            {
                try
                {
                    this.Context.Database.OpenConnection();
                    command.CommandText = "SP_InsertDetalleFactura";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@FacturaId", detalleFactura.FacturaId));
                    command.Parameters.Add(new SqlParameter("@ProductoId", detalleFactura.ProductoId));
                    command.Parameters.Add(new SqlParameter("@Cantidad", detalleFactura.Cantidad));
                    command.Parameters.Add(new SqlParameter("@PrecioUnitario", detalleFactura.PrecioUnitario));

                    DbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        num = Convert.ToInt32(reader["DetalleFacturaId"].ToString());
                    }
                    this.Context.Database.CloseConnection();
                }
                catch (Exception exception)
                {
                    num = 0;
                    throw new Exception(exception.Message, exception);
                }
                finally
                {
                    this.Context.Database.CloseConnection();
                }

                return num;
            }
        }
    }
}
