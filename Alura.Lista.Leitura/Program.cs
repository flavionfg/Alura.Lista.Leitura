using System;
using Microsoft.AspNetCore.Hosting;
using Alura.Lista.Leitura.Repositorio;
using Alura.Lista.Leitura.Negocio;

namespace Alura.Lista.Leitura
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var _repo = new LivroRepositorioCSV();

            IWebHost host = new WebHostBuilder().UseKestrel().UseStartup<Startup>().Build();
            host.Run();

            //ImprimeLista(_repo.ParaLer);
            //ImprimeLista(_repo.Lendo);
            //ImprimeLista(_repo.Lidos);
        }

        static void ImprimeLista(ListaDeLeitura lista)
        {
            Console.WriteLine(lista);
        }

    }
}
