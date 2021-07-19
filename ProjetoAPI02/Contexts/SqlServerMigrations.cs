using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Contexts
{
    public class SqlServerMigrations : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            //ler o arquivo appsettings.json para obter a string de conexão do banco de dados
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            //ler a string de conexão contida no arquivo appsettings.json
            var root = configurationBuilder.Build();
            var connectionstring = root.GetSection("ConnectionStrings").GetSection("BDProjetoAPI02").Value;

            //gerar a conexão com o banco de dados para executar o Migrations
            var builder = new DbContextOptionsBuilder<SqlServerContext>();
            builder.UseSqlServer(connectionstring);

            return new SqlServerContext(builder.Options);
        }
    }
}
