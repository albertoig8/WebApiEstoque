using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using WebApiEstoque.Models;
using System;
using Microsoft.Extensions.Logging;

namespace WebApiEstoque
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            // Passando a versão do MySql
            var serverVersion = new MySqlServerVersion(new System.Version(8,0,27));
            // Pegando a string de conexão do banco
            var connection = Configuration["ConnectionMySQL:MySqlConnectionString"];

            services.AddControllers();
            // Configurando o serviço que vai ser o Contexto de ProdutoCOntext para conseguir persistir os dados no banco.
            services.AddDbContext<ProdutoContext>(
                // Registrando a option passando a string de conexão e a versão do MySql.
                opt => opt
                .UseMySql(connection, serverVersion)
                // Configurações de log(mensagens de erro em sequência)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableDetailedErrors()
                );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiEstoque", Version = "v1" });
            });
        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiEstoque v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
