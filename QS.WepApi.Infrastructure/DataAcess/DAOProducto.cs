using Microsoft.EntityFrameworkCore;
using QS.WebApi.Domain.InfrastuctureContratos;
using QS.WebApi.Domain.Productos;
using QS.WepApi.Infrastructure.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace QS.WepApi.Infrastructure.DataAcess
{
    public class DAOProducto : IProducto
    {
        private readonly EvaluacionQS_Context Context;
        public DAOProducto(EvaluacionQS_Context _context)
        {
            Context = _context;
        }

        public List<Producto> DAOGetProductos()
        {
            List<Producto> listProducto = null;
            using (DbCommand command = this.Context.Database.GetDbConnection().CreateCommand())
            {
                try
                {
                    this.Context.Database.OpenConnection();
                    command.CommandText = "SP_GetProductos";
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.Add(new SqlParameter("@cantDays", cantDays));
                    DbDataReader reader = command.ExecuteReader();

                    listProducto = new List<Producto>();

                    while (reader.Read())
                    {
                        Producto product = new Producto();
                        product.ProductoId = Convert.ToInt32(reader["ProductoId"]);
                        product.Descripcion = reader["Descripcion"].ToString();
                        product.PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]);
                        product.Categoria = reader["Categoria"].ToString();

                        listProducto.Add(product);
                    }
                }
                catch (Exception exception)
                {
                    listProducto = null;
                    throw new Exception(exception.Message, exception);
                }
                finally
                {
                    this.Context.Database.CloseConnection();
                }
                return listProducto;
            }
        }
    }
}
