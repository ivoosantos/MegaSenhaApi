using MegaSenhaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSenhaApi.Database
{
    public class MegaSenhaContext : DbContext
    {
        public MegaSenhaContext(DbContextOptions<MegaSenhaContext> options) : base(options)
        {

        }

        public DbSet<Palavra> Palavras { get; set; }
    }
}
