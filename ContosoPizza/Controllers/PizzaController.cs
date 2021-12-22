using System;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private myDBContext _dbContext;
    public PizzaController(myDBContext DbContext)
    {
        _dbContext = DbContext;
    }


   [HttpGet]
    public ActionResult<List<Pizza>> GetAll(){ 
        Console.WriteLine("Called Get all");

    var infos = _dbContext.heroes.FromSqlRaw("SELECT * FROM dbo.heroes").ToList();
    //infos.ForEach(Console.WriteLine);
    foreach(var roww in infos){
        Console.WriteLine(roww.Name);
        Console.WriteLine("object o = myDerived: Type is {0}", roww.GetType());
    }




  //  foreach(var row in _dbContext.heroes)
  //Console.WriteLine(row.Name);

    //var newHero = new heroes{ID = 2, Name = "bobby", EnrollmentDate = System.DateTime.Now};
    //_dbContext.heroes.Add(newHero);
    //_dbContext.SaveChanges();

    return PizzaService.GetAll();

    }

    //https://localhost:7127/pizza/1
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        
        Console.WriteLine("aaaa");

        if(pizza == null)
            return NotFound();

        return pizza;
    }


    // GET all action

    // GET by Id action

    // POST action

[HttpPost]
public IActionResult Create(Pizza pizza)
{            
    PizzaService.Add(pizza);
    return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
}

    // PUT action
[HttpPut("{id}")]
public IActionResult Update(int id, Pizza pizza)
{
    if (id != pizza.Id)
        return BadRequest();

    var existingPizza = PizzaService.Get(id);
    if(existingPizza is null)
        return NotFound();

    PizzaService.Update(pizza);           

    return NoContent();
}
    // DELETE action
[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var pizza = PizzaService.Get(id);

    if (pizza is null)
        return NotFound();

    PizzaService.Delete(id);

    return NoContent();
}

}