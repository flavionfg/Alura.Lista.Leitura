using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Alura.Lista.Leitura.Mvc
{
    public class RoteamentePadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            //rota padrão : /<Classe>Logica/Metodo
            //{classe}/{metodo}

            var classe = Convert.ToString(context.GetRouteValue("classe"));
            var nameMetodo = Convert.ToString(context.GetRouteValue("metodo"));

            var nomeCompleto = $"Alura.Lista.Leitura.App.Logica.{classe}Logica";

            var tipo = Type.GetType(classe);
            var metodo = tipo.GetMethods().Where(m => m.Name == nameMetodo).First();
            var requestDelegate = (RequestDelegate)Delegate.CreateDelegate(typeof(RequestDelegate), metodo);

            return requestDelegate.Invoke(context);
        }
    }
}
