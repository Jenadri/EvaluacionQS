using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QS.WepApi.Infrastructure.Connection
{
    public class EvaluacionQS_Context : DbContext
    {
        public EvaluacionQS_Context(DbContextOptions<EvaluacionQS_Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
