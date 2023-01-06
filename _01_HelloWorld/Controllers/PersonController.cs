using _01_HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using _01_HelloWorld.DbContexts;

namespace _01_HelloWorld.Controllers;

public class PersonController : Controller
{
    private readonly PersonContext _context;

    public PersonController(PersonContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "Persons")]
    public async Task<IActionResult> GetAllPeople()
    {
        var persons = await _context.Persons.ToListAsync();
        return new ObjectResult(persons);
    }

    [HttpGet]
    public async Task<IActionResult> GetPersonById(int id)
    {
        var person = await _context.Persons.SingleOrDefaultAsync(p => p.Id == id);
        if (person == null)
        {
            return NotFound();
        }

        return new ObjectResult(person);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePersonById(int id, Person person)
    {
        var p = await _context.Persons.SingleOrDefaultAsync(p => p.Id == id);
        if (p == null)
        {
            return NotFound();
        }

        p.Name = person.Name;
        p.Address = person.Address;
        p.Age = person.Age;

        await _context.SaveChangesAsync();


        return Accepted();
    }

    [HttpPost]
    public async Task<IActionResult> AddPerson(Person person)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        await _context.AddAsync(person);
        await _context.SaveChangesAsync();

        return Accepted();
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePersonById(int id)
    {
        var person = await _context.Persons.SingleOrDefaultAsync(p => p.Id == id);
        if (person == null)
        {
            return BadRequest();
        }

        _context.Persons.Remove(person);
        await _context.SaveChangesAsync();

        return Accepted();
    }
}