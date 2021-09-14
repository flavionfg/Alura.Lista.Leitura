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
using System.Linq;
using System.IO;
using Alura.Lista.Leitura.HTML;

namespace Alura.Lista.Leitura
{
    public class CadastroController
    {
        public string Incluir(Livro livro)
        {
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return "O Livro foi adicionado com sucesso";
        }

        public static Task ExibeFormulario(HttpContext context)
        {
            var html = HtmlUtils.CarregaArquivoHTML("formulario");
            return context.Response.WriteAsync(html);
        }
    }
}
