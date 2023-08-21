using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiASP.Context;
using WebApiASP.Models;

namespace WebApiASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : Controller
    {
      private readonly FuncionarioContext _context;

      public FuncionarioController(FuncionarioContext context)
      {
        _context = context;
      }

      [HttpPost]
      public IActionResult Create(Funcionario func)
      {
        _context.Add(func);
        _context.SaveChanges();
        return Ok(func);
      }
    
    [HttpGet]
    public IActionResult Get()
    {
        List<Funcionario> func = _context.Funcionarios.ToList();
        return Ok(func);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetId(int id)
    {
      var func = _context.Funcionarios.Find(id);
      if(func == null)
      {
        return NotFound();
      }

      return Ok(func);
    }

    
    [HttpPut("{id}")]
    public IActionResult Update(int id, Funcionario funcs)
    {
        var func = _context.Funcionarios.Find(id);

        if(func == null)
        {
            return NotFound();
        }

        func.Nome = funcs.Nome;
        func.Telefone = funcs.Telefone;
        func.HorarioCadastrado = funcs.HorarioCadastrado;
        
        _context.Update(func);
        _context.SaveChanges();

        List<Funcionario> ListaFuncatt = _context.Funcionarios.ToList();

        return Ok(ListaFuncatt);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var func = _context.Funcionarios.Find(id);

         if(func == null)
        {
            return NotFound();
        }

        _context.Remove(func);
        _context.SaveChanges();

        List<Funcionario> ListaFuncatt = _context.Funcionarios.ToList();

        return Ok(ListaFuncatt);
    }

}
}
