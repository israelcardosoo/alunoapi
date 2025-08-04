using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using alunoapi.Properties;

namespace alunoapi.Data
{
    public class alunoapiContext : DbContext
    {
        public alunoapiContext (DbContextOptions<alunoapiContext> options)
            : base(options)
        {
        }

        public DbSet<alunoapi.Properties.Aluno> Aluno { get; set; } = default!;
    }
}
