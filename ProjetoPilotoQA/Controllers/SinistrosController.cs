using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoPilotoQA.Business;
using ProjetoPilotoQA.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger.Annotations;

namespace ProjetoPilotoQA.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/persons/
     Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da Classe em lower case [Person]Controller
    e expõe como endpoint REST
*/

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SinistrosController : ControllerBase
    {
        //Declaração do serviço usado
        private readonly ISinistroBusiness sinistroBusiness;
        

        /*Injeção de uma instância de ISinistroBusiness ao
         criar uma instância de PersonControler */
        public SinistrosController(ISinistroBusiness sinistroBusiness)
        {
            this.sinistroBusiness = sinistroBusiness;
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/v{version:apiVersion}/sinistros

        // GET sem parâmetros para o Findall --> Busca Todos
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<Sinistro>))]
        [SwaggerResponse((204), Type = typeof (NoContentResult))]
        [SwaggerResponse((400), Type = typeof (BadRequestResult)) ]
        [SwaggerResponse((401), Type = typeof (UnauthorizedResult))]
        public IActionResult Get()
        {
            return Ok(sinistroBusiness.FindAll());
        }

        // GET api/v{version:apiVersion}/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(Sinistro))]
        [SwaggerResponse((204), Type = typeof(NoContentResult))]
        [SwaggerResponse((400), Type = typeof(BadRequestResult))]
        [SwaggerResponse((401), Type = typeof(UnauthorizedResult))]
        public IActionResult Get(int id)
        {
            var sinistro = sinistroBusiness.FindById(id);
            if (sinistro == null) return NotFound();
            return Ok(sinistro);
        }

        // POST api/v{version:apiVersion}/values
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(Sinistro))]
        [SwaggerResponse((400), Type = typeof(BadRequestResult))]
        [SwaggerResponse((401), Type = typeof(UnauthorizedResult))]
        public IActionResult Post( [FromBody] Sinistro sinistro)
        {
          
            if (sinistro != null && ModelState.IsValid)
            {
                return new ObjectResult(sinistroBusiness.Create(sinistro));
            }
            return BadRequest();
        }

        //PUT api/v{version:apiVersion}/value/5
        [HttpPut("{id}")]
        [SwaggerResponse((202), Type = typeof(Sinistro))]
        [SwaggerResponse((400), Type = typeof(BadRequestResult))]
        [SwaggerResponse((401), Type = typeof(UnauthorizedResult))]
        public IActionResult Put([FromBody] Sinistro sinistro)
        {
            if (sinistro == null) return BadRequest();
            var updateSinistro = sinistroBusiness.Update(sinistro);
            if (updateSinistro == null) return BadRequest();
            return new ObjectResult(updateSinistro);
        }

        //DELETE api/value/5
        [HttpDelete("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse((400), Type = typeof(BadRequestResult))]
        [SwaggerResponse((401), Type = typeof(UnauthorizedResult))]
        public IActionResult Delete(int id)
        {
            sinistroBusiness.Delete(id);
            return NoContent();
        }
    }
}
