using CRUDAPI.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly MeuDbContext _meuDbContext;

        public PessoasController(MeuDbContext meuDbContext)
        {
            _meuDbContext = meuDbContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> PegarTodosAsync()
        {
            return await _meuDbContext.Pessoas.ToListAsync();
        }

        [HttpGet("{pessoaId}")]
        public async Task<ActionResult<Pessoa>> PegarPessoaPeloIdAsync(int pessoaId)
        {
            Pessoa pessoa = await _meuDbContext.Pessoas.FindAsync(pessoaId);

            if (pessoa == null)
                return NotFound();

            return pessoa;

        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> SalvarPessoaAsync(Pessoa pessoa)
        {
            await _meuDbContext.Pessoas.AddAsync(pessoa);
            await _meuDbContext.SaveChangesAsync();

            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> AtualizarPessoaAsync(Pessoa pessoa)
        {
            _meuDbContext.Pessoas.Update(pessoa);
            await _meuDbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("{pessoaId}")]
        public async Task<ActionResult> ExcluirPessoaAsync(int pessoaId)
        {
            Pessoa pessoa = await _meuDbContext.Pessoas.FindAsync(pessoaId);
            if (pessoa == null)
                return NotFound();

            _meuDbContext.Remove(pessoa);
            await _meuDbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
