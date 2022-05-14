using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraWebAPI.Data;
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
            return Ok(produtos);
        }

        [HttpPost]

        public IActionResult Insert(Produto produto)
        {

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpPut]

        public IActionResult Update(Produto produto)
        {          
            var produtoAlterado = _context.Produtos.FirstOrDefault(x => x.Id == produto.Id);
            if(produtoAlterado == null)
                return NotFound();
            
            produtoAlterado.Nome = produto.Nome;
            produtoAlterado.Marca = produto.Marca;

            _context.Produtos.Update(produtoAlterado);
            _context.SaveChanges();
            return Ok(produto);
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

            return Ok(produto);
        }

    }
}
