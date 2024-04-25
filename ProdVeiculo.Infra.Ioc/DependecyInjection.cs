using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProdVeiculo.Application.interfaces;
using ProdVeiculo.Application.Mappings;
using ProdVeiculo.Application.Services;
using ProdVeiculo.domain.interfaces;
using ProdVeiculo.Infra.Context;
using ProdVeiculo.Infra.Repositories;

namespace ProdVeiculo.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AdicionarDependencias(this IServiceCollection services)
        {
                    
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));                                
            });

            services.AddAutoMapper(typeof(ProdutoMapingProfile));
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();


            services.AddAutoMapper(typeof(FornecedorMapingProfile));
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            return services;
        }

    }
}
