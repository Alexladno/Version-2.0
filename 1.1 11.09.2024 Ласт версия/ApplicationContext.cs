using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;


namespace Регистрация
{
    class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public ApplicationContext() : base("SqlConnection")
        {

        }

    }
}
