using BookStoreCrudWebApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using BookStoreCrudWebApi.Models.Dtos;
using BookStoreCrudWebApi.Models.Entidades;

namespace BookStoreCrudWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresLivrosController : ControllerBase
    {
        private readonly IAutoresLivrosRepositorio _repositorio;
        private readonly IMapper _mapeador;

        public AutoresLivrosController(IAutoresLivrosRepositorio repositorio, IMapper mapeador)
        {
            _repositorio = repositorio;
            _mapeador = mapeador;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarLivrosAutores(AutoresLivrosCadastrarDto autoresLivrosCadastrar){

            if( autoresLivrosCadastrar == null)return BadRequest("Dados Inválidos");

            var autoresLivrosPorCadastrar = _mapeador.Map<AutoresLivros>(autoresLivrosCadastrar);

            _repositorio.Adicionar(autoresLivrosPorCadastrar);

            return await _repositorio.Salvar()
                    ? Ok("Genero Cadastrado com Sucesso")
                    : BadRequest("Erro ao Cadastrar o Genero");
        }

    }
}