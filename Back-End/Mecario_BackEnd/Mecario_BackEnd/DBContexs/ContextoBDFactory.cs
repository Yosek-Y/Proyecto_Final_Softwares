using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mecario_BackEnd.DBContexs
{
    public class ContextoBDFactory : IDesignTimeDbContextFactory<ContextoBD>
    {
        public ContextoBD CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextoBD>();


            optionsBuilder.UseSqlServer(
                "Server=HPPAVILION\\MSSQLSERVER_2022;Database=MECARIO_DB;Trusted_Connection=True;TrustServerCertificate=True;"
            );

            return new ContextoBD(optionsBuilder.Options);
        }
    }
}
