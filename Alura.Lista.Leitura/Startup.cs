using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alura.Lista.Leitura.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Alura.Lista.Leitura.Negocio;


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
            builder.MapRoute("/Livros/Paraler", LivrosParaLer);
            builder.MapRoute("/Livros/Lendo", LivrosLendo);
            builder.MapRoute("/Livros/Lidos", LivrosLidos);
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", NovoLivroParaLer);
            var rotas = builder.Build();

            app.UseRouter(rotas);

            //app.Run(Roteamento);
        }

        public Task NovoLivroParaLer(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = Convert.ToString(context.GetRouteValue("nome")),
                Autor = Convert.ToString(context.GetRouteValue("autor")),
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync("O Livro foi adicionado com sucesso");
        }

        private Task Roteamento(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
             { "/Livros/ParaLer", LivrosParaLer },
             { "/Livros/Lendo", LivrosLendo },
             { "/Livros/Lidos", LivrosLidos }
            };

            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);
            }

            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho inexistente.");
        }

        public Task LivrosParaLer(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();
            return contexto.Response.WriteAsync(_repo.ParaLer.ToString());
        }
        
        public Task LivrosLendo(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();
            return contexto.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();
            return contexto.Response.WriteAsync(_repo.Lidos.ToString());
        }
    }
}
