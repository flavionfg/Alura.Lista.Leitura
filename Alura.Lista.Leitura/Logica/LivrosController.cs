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
using Microsoft.AspNetCore.Mvc;

namespace Alura.Lista.Leitura.App
{
    public class LivrosController : Controller
    {
        public IEnumerable<Livro> Livros { get; set; }

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

        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.ParaLer.Livros;
            return View("lista");
        }

        public IActionResult Lidos()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lendo.Livros;
            return View("lista");
        }

        public IActionResult Lendo()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lendo.Livros;
            return View("lista");
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
