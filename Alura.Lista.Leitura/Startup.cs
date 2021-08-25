using Microsoft.AspNetCore.Builder;
using Alura.Lista.Leitura.Repositorio;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace Alura.Lista.Leitura
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(LivrosParaLer);
        }

        public Task LivrosParaLer(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();
            return contexto.Response.WriteAsync(_repo.ParaLer.ToString());
        }
    }
}
