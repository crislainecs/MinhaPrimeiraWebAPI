using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraWebAPI.Data;
using MinhaPrimeiraWebAPI.Data.DTO;
using MinhaPrimeiraWebAPI.Entities;

namespace MinhaPrimeiraWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly WebApiContext _context;
        public ProdutoController(WebApiContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _context.Produtos.ToList();
            var produtosDTO = produtos.Select(p => new ProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Marca = p.Marca
            });
            return Ok(produtosDTO);
        }

        [HttpPost]

        public IActionResult Insert(ProdutoDTO produtoDTO)
        {
            var produto = new Produto 
            {
                Nome = produtoDTO.Nome,
                Marca = produtoDTO.Nome
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            produtoDTO.Id = produto.Id;
            return Ok(produtoDTO);
        }

        [HttpPut]

        public IActionResult Update(ProdutoDTO produtoDTO)
        {          
            var produtoAlterado = _context.Produtos.FirstOrDefault(x => x.Id == produtoDTO.Id);
            if(produtoAlterado == null)
                return NotFound();
            
            produtoAlterado.Nome = produtoDTO.Nome;
            produtoAlterado.Marca = produtoDTO.Marca;

            _context.Produtos.Update(produtoAlterado);
            _context.SaveChanges();
            return Ok(produtoDTO);
        }

        [HttpDelete]
        
        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos.Find(id);
            if(produto == null)
                return NotFound();

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok("Produto " + id + "excluido com sucesso!");
        }

        [HttpGet("GetById", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var produto = _context.Produtos.Find(id);
            if(produto == null)
                return NotFound();

            var produtoDTO = new ProdutoDTO 
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Marca = produto.Marca
            };

            return Ok(produtoDTO);
        }

    }
}
