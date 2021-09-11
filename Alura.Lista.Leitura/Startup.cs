using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alura.Lista.Leitura.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Alura.Lista.Leitura.Negocio;
using Alura.Lista.Leitura;
using Alura.Lista.Leitura.App;
using System.Linq;
using System.IO;

namespace Alura.Lista.Leitura
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("/Livros/Paraler", LivrosLogica.LivrosParaLer);
            builder.MapRoute("/Livros/Lendo", LivrosLogica.LivrosLendo);
            builder.MapRoute("/Livros/Lidos", LivrosLogica.LivrosLidos);
            builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.ExibeDetalhes);
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivroParaLer);
            builder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);

            var rotas = builder.Build();

            app.UseRouter(rotas);

            //app.Run(Roteamento);
        }
    }
}