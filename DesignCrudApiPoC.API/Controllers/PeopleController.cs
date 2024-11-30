using DesignCrudApiPoC.Interfaces.Controllers;
using DesignCrudApiPoC.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DesignCrudApiPoC.API.Controllers;

[ApiController]
[Route("peoples")]
public class PeopleController : Controller, IBaseCrudController<PeopleEntity>
{
    private static PeopleEntity[] _peoples =
    [
        new PeopleEntity(1,"John", "Doe", new DateOnly(1990, 1, 1)),
        new PeopleEntity(2,"Jane", "Doe", new DateOnly(1995, 1, 1)),
        new PeopleEntity(3, "Alice", "Smith", new DateOnly(2000, 1, 1)),
        new PeopleEntity(4, "Bob", "Smith", new DateOnly(2005, 1, 1))
    ];
    
    [HttpGet]
    [ProducesResponseType(typeof(Ok<PeopleEntity[]>), 200)]
    public Task<ActionResult<PeopleEntity[]>> FindMany()
    {
        return Task.FromResult<ActionResult<PeopleEntity[]>>(_peoples);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Ok<PeopleEntity>), 200)]
    [ProducesResponseType(typeof(NotFoundResult), 404)]
    public Task<ActionResult<PeopleEntity>> FindOne(int id)
    {
        var find = _peoples.FirstOrDefault(p => p.Id == id);
        return find == null ? 
            Task.FromResult<ActionResult<PeopleEntity>>(NotFound()) : 
            Task.FromResult<ActionResult<PeopleEntity>>(Ok(find));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Ok<PeopleEntity>), 200)]
    public Task<ActionResult<PeopleEntity>> CreateOne([FromBody] PeopleEntity people)
    {
        var newPeople = new PeopleEntity(_peoples.Length + 1, people.FirstName, people.LastName, people.Birthday);
        _peoples = _peoples.Append(newPeople).ToArray();
        return Task.FromResult<ActionResult<PeopleEntity>>(Ok(newPeople));
    }
    
    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Ok<PeopleEntity>), 200)]
    [ProducesResponseType(typeof(NotFoundResult), 404)]
    public Task<ActionResult<PeopleEntity>> UpdateOne(int id, [FromBody] PeopleEntity people)
    {
        var find = _peoples.FirstOrDefault(p => p.Id == id);
        if (find == null)
        {
            return Task.FromResult<ActionResult<PeopleEntity>>(NotFound());
        }
        find.FirstName = people.FirstName;
        find.LastName = people.LastName;
        find.Birthday = people.Birthday;
        return Task.FromResult<ActionResult<PeopleEntity>>(Ok(find));
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Ok<PeopleEntity>), 200)]
    [ProducesResponseType(typeof(NotFoundResult), 404)]
    public Task<ActionResult<PeopleEntity>> DeleteOne(int id)
    {
        var find = _peoples.FirstOrDefault(p => p.Id == id);
        if (find == null)
        {
            return Task.FromResult<ActionResult<PeopleEntity>>(NotFound());
        }
        _peoples = _peoples.Where(p => p.Id != id).ToArray();
        return Task.FromResult<ActionResult<PeopleEntity>>(Ok(find));
    }
    
}