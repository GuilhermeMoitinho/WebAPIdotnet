using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebApiASP.Models;

namespace WebApiASP.Context
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}