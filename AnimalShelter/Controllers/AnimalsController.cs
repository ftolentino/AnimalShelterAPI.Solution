using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/Animals")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    // GET: api/Animals
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get([FromQuery]string name, string species, string breed)
    {
      var query = _db.Animals.AsQueryable();
      
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (species != null)
      {
        query = query.Where(entry => entry.Species == species);
      }    

      if (breed != null)
      {
        query = query.Where(entry => entry.Breed == breed);
      }      

      return await query.ToListAsync();
    }

    // GET: api/Animals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
        var animal = await _db.Animals.FindAsync(id);

        if (animal == null)
        {
            return NotFound();
        }

        return animal;
    }

    // PUT: api/Animals/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }

      _db.Entry(animal).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Message
    [HttpPost]
    public async Task<ActionResult<Animal>> Post([FromBody]Animal animal)
    {
      DateTime date1 = DateTime.Now;
      var longDateValue = date1.ToLongDateString();
      animal.PostDate = longDateValue;
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId}, animal);
    }

    // DELETE: api/Messages/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    
    

    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }
  }
}