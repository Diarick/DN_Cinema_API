using System.Data.Entity;
using Model.Models;

namespace ModelContext
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class DBCtx : DbContext
    {
        public DBCtx() : base("DNMoviesCtx")
        {

        }
        public DbSet<Movies> movies { get; set; }
    }
}
