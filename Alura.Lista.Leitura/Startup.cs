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
            var caminhosAtendidos = new Dictionary<string, string>
            {
             { "/Livros/ParaLer", _repo.ParaLer.ToString() },
             { "/Livros/Lendo", _repo.Lendo.ToString() },
             { "/Livros/Lidos", _repo.Lidos.ToString() }
            };

            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                return context.Response.WriteAsync(caminhosAtendidos[context.Request.Path]);
            }

            return context.Response.WriteAsync("Caminho inexistente.");
        }

        public Task LivrosParaLer(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();
            return contexto.Response.WriteAsync(_repo.ParaLer.ToString());
        }
    }
}
