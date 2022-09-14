using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreinamentoCSharp.Dominio;
using TreinamentoCSharp.Infra;
using TreinamentoCSharp.Model;

namespace TreinamentoCSharp.Controllers
{
    [Route("api/sala")]
    [ApiController]
    public class SalaController : ControllerBase
    {

        private readonly Contexto _contexto;

        public SalaController(Contexto contexto)
        {
            this._contexto = contexto;
        }

        // GET api/sala
        [HttpGet]
        public IActionResult Get()
        {
            List<Sala> salas = this._contexto.Sala.ToList();

            if(salas.Count == 0)
                return NotFound();

            return Ok(salas);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Sala sala = this._contexto.Sala.Find(id);

            if(sala == null)
                return NotFound();

            return Ok(sala);
        }

        // POST api/sala
        [HttpPost]
        public IActionResult Post([FromBody]SalaModel salaModel)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Sala novaSala = new Sala(salaModel.Nome,
                salaModel.Capacidade,
                salaModel.PossuiTV,
                salaModel.PossuiProjetor);

            this._contexto.Add(novaSala);

            this._contexto.SaveChanges();

            return Created("Sala criada com sucesso!", novaSala);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SalaModel salaModel)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(id <= 0)
                return NotFound();

            Sala sala = this._contexto.Sala.Find(id);

            if(sala == null)
                return NotFound();
            
            sala.AlterarNome(salaModel.Nome);
            sala.AlterarCapacidade(salaModel.Capacidade);
            sala.AlterarPossuiTV(salaModel.PossuiTV);
            sala.AlterarProjetor(salaModel.PossuiProjetor);

            this._contexto.Update(sala);
            this._contexto.SaveChanges();
            return Ok();
        }

        // DELETE api/sala/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id <= 0)
                return NotFound();

            Sala sala = this._contexto.Sala.Find(id);

            if(sala == null)
                return NotFound();

            this._contexto.Remove(sala);
            this._contexto.SaveChanges();
            return Ok();
        }
    }
}
