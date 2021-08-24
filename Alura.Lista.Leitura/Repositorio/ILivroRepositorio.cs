using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Lista.Leitura.Negocio;

namespace Alura.Lista.Leitura.Repositorio
{
    interface ILivroRepositorio
    {
        ListaDeLeitura ParaLer { get; }
        ListaDeLeitura Lendo { get; }
        ListaDeLeitura Lidos { get; }
        IEnumerable<Livro> Todos { get; }
        void Incluir(Livro livro);
    }
}
