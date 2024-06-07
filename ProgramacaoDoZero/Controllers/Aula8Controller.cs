using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoDoZero.Api.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class OlaMundoPersonalizadoController : ControllerBase
    {
        [HttpGet]
        [Route("olaMundo")]
        public IActionResult OlaMundo()
        {
            var mensagem = "Olá eu sou uma API";

            return Ok(mensagem);
        }


        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public string OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Ola mundo via API " + nome;

            return mensagem;
        }
        [Route("Somar")]
        [HttpGet]
        public string Somar(int valor1, int valor2)
        {
            var soma = valor1 + valor2;

            var mensagem = "A soma é " + soma;

            return mensagem;
        }
        [Route("Media")]
        [HttpGet]
        public string Media(decimal numero1, decimal numero2)
        {
            var media = (numero1 + numero2) / 2;

            var mensagem = "A soma é " + media;

            return(mensagem);
        }
        [Route("terreno")]
        [HttpGet]
        public string Terreno(decimal largura, decimal comprimento, decimal valorM2)
        {
            var areaTerreno = (largura + comprimento);

            var valorTerreno = (areaTerreno * valorM2);

            var mensagem = "A área do terreno é de " + areaTerreno + " m2. O valor do terreno é de R$ " + valorTerreno;

            return(mensagem);
        }
        [Route("troco")]
        [HttpGet]
        public string troco(decimal valorUni, decimal qtdProduto, decimal valorCliente)
        {
            var valorTotal = (valorUni * qtdProduto);

            var troco = (valorTotal - valorCliente);

            var mensagem = "O valor de troco do cliente é de " + troco;

            return (mensagem);
        }
        [Route("Pagamento")]
        [HttpGet]
        public string Pagamento(string nome, decimal valorHora, decimal qtdHoras)
        {
            var salario = (valorHora * qtdHoras);

            var mensagem = "O funcionario " + nome + " recebe por mês R$ " + salario;

            return (mensagem);
        }
        [Route("Consumo")]
        [HttpGet]
        public string Consumo(decimal distancia, decimal litros)
        {
            var consumo = (distancia / litros);

            var mensagem = "O cosumo médio do veiculo é de " + consumo + " km por litros";

            return (mensagem);
        }

    }
}
