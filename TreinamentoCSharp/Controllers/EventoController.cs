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
    [Route("api/evento")]
    [ApiController]
    public class EventoController : ControllerBase
    {

        private readonly Contexto _contexto;

        public EventoController(Contexto contexto)
        {
            this._contexto = contexto;
        }

        // GET api/evento
        [HttpGet]
        public IActionResult Get()
        {
            List<Evento> eventos = this._contexto.Evento.ToList();

            if(eventos.Count == 0)
                return NotFound();

            return Ok(eventos);
        }

        // GET api/eventos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Evento evento = this._contexto.Evento.Find(id);

            if(evento == null)
                return NotFound();

            return Ok(evento);
        }

        // POST api/sala
        [HttpPost]
        public IActionResult Post([FromBody]EventoModel eventoModel)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Evento novoEvento = new Evento(
                eventoModel.SalaId,
                eventoModel.Nome,
                eventoModel.DataInicio,
                eventoModel.DataFim
                );

            this._contexto.Add(novoEvento);

            this._contexto.SaveChanges();

            return Created("Evento criado com sucesso!", novoEvento);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EventoModel eventoModel)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(id <= 0)
                return NotFound();

            Evento evento = this._contexto.Evento.Find(id);

            if(evento == null)
                return NotFound();
            
            evento.AlterarSalaId(eventoModel.SalaId);
            evento.AlterarNome(eventoModel.Nome);
            evento.AlterarDataInicio(eventoModel.DataInicio);
            evento.AlterarDataFim(eventoModel.DataFim);

            this._contexto.Update(evento);
            this._contexto.SaveChanges();
            return Ok();
        }

        // DELETE api/sala/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id <= 0)
                return NotFound();

            Evento evento = this._contexto.Evento.Find(id);

            if(evento == null)
                return NotFound();

            this._contexto.Remove(evento);
            this._contexto.SaveChanges();
            return Ok();
        }
    }
}
