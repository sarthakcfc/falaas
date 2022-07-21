using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.data.postgres
{
    public class TeenPattiDbContext : DbContext
    {
        public TeenPattiDbContext(DbContextOptions<TeenPattiDbContext> options) : base(options)
        {
        }

    }
}
