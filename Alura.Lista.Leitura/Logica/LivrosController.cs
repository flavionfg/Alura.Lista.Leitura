using System;
using System.Linq;
using System.Threading.Tasks;
using Alura.Lista.Leitura.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Alura.Lista.Leitura.Negocio;
using System.Collections.Generic;
using System.IO;
using Alura.Lista.Leitura.HTML;

namespace Alura.Lista.Leitura.App
{
    public class LivrosController
    {
        private static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lista");
            foreach (var livro in livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }
            return conteudoArquivo.Replace("#NOVO-ITEM", "");
        }

        public static Task ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.ParaLer.Livros);
            return context.Response.WriteAsync(html);
        }

        public static Task Lidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.Lidos.Livros);
            return context.Response.WriteAsync(html);
        }

        public static Task Lendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.Lendo.Livros);
            return context.Response.WriteAsync(html);
        }


        public string Detalhes(int id)
        {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();
        }

        public string Teste()
        {
            return "nova funcionalidade implementada!";
        }
    }
}
