using Microsoft.AspNetCore.Builder;
using Alura.Lista.Leitura.Repositorio;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;


namespace Alura.Lista.Leitura
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(Roteamento);
      
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
