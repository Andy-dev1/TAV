using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        // GET api/<CalculadoraController>/5
        [HttpGet("soma")]
        public IActionResult Soma(double a, double b)
        {
            try
            {
                Calculadora calc = new Calculadora();
                var c = calc.Soma(a, b);
                return Ok(c);
            } catch (Exception ex)
            {
                return StatusCode(500);

            }
        }
        [HttpGet("subtracao")]
        public IActionResult Subtracao(double a, double b)
        {
            try
            {
                Calculadora calc = new Calculadora();
                var c = calc.Subtracao(a, b);
                return Ok(c);
            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }
        }
        [HttpGet("multiplicacao")]
        public IActionResult Multiplicacao(double a, double b)
        {
            try
            {
                Calculadora calc = new Calculadora();
                var c = calc.Multiplicacao(a, b);
                return Ok(c);
            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }
        }
        [HttpGet("divisao")]
        public IActionResult Divisao(double a, double b)
        {
            if (b != 0) { 
            try
            {
                
                Calculadora calc = new Calculadora();
                var c = calc.Divisao(a, b);
                return Ok(c);
            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }
            }
            return StatusCode(500);
        }

        // POST api/<CalculadoraController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CalculadoraController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CalculadoraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
