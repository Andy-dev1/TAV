using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabAppEscolaDDD.Domain.Entidades;

namespace TrabAppEscolaDDD.Infra.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
