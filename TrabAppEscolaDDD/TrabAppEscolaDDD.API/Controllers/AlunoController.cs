using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Repositories;
using TrabAppEscolaDDD.Domain.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabAppEscolaDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepositoryAluno _repositoryAluno;
        // GET: api/<AlunoController>
        public AlunoController(IRepositoryAluno repositoryAluno)
        {
            _repositoryAluno = repositoryAluno;
        }
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return _repositoryAluno.PegarTodos();
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return _repositoryAluno.PegarPorID(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public void Post([FromBody] Aluno aluno)
        {
            _repositoryAluno.Adicionar(aluno);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Aluno aluno)
        {
            _repositoryAluno.Atualizar(aluno);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(Aluno aluno)
        {
            _repositoryAluno.Remover(aluno);
        }
    }
}
