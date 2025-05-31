using DesignCrudApiPoC.API.Interfaces.Controllers;
using DesignCrudApiPoC.API.Models;
using DesignCrudApiPoC.API.Responses;
using DesignCrudApiPoC.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesignCrudApiPoC.API.Controllers;

[ApiController]
[Route("books")]
public class BookController(IBookService service) : Controller, IBaseCrudController<BookModel>
{
    private readonly IBookService _service = service;

    [HttpGet]
    [ProducesResponseType(typeof(EntityResponse<BookModel[]>), StatusCodes.Status200OK)]
    public ActionResult<EntityResponse<BookModel[]>> FindMany([FromQuery] int? page, [FromQuery] int? pageSize)

    {
        return Ok(_service.FindMany(page, pageSize));
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(EntityResponse<BookModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(EntityResponse<>), StatusCodes.Status404NotFound)]
    public ActionResult<EntityResponse<BookModel?>> FindOne(int id)
    {
        try
        {
            return Ok(_service.FindOne(id));
        }
        catch (Exception e)
        {
            return NotFound(new EntityResponse<BookModel?>(null, new MetaResponse(null, e.Message)));
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(EntityResponse<BookModel>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(EntityResponse<>), StatusCodes.Status400BadRequest)]
    public ActionResult<EntityResponse<BookModel>> CreateOne(BookModel payload)
    {
        try
        {
            var created = _service.CreateOne(payload);
            return CreatedAtAction(nameof(FindOne), new { id = created.Data?.Id }, created);
        }
        catch (Exception e)
        {
            return BadRequest(new EntityResponse<BookModel?>(null, new MetaResponse(null, e.Message)));
        }
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(EntityResponse<BookModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(EntityResponse<>), StatusCodes.Status400BadRequest)]
    public ActionResult<EntityResponse<BookModel?>> UpdateOne(int id, [FromBody] BookModel obj)
    {
        try
        {
            return Ok(_service.UpdateOne(id, obj));
        }
        catch (Exception e)
        {
            return BadRequest(new EntityResponse<BookModel?>(null, new MetaResponse(null, e.Message)));
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(EntityResponse<BookModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(EntityResponse<>), StatusCodes.Status404NotFound)]
    public ActionResult<EntityResponse<BookModel?>> DeleteOne(int id)
    {
        try
        {
            return Ok(_service.DeleteOne(id));
        }
        catch (Exception e)
        {
            return NotFound(new EntityResponse<BookModel?>(null, new MetaResponse(null, e.Message)));
        }
    }


    [HttpPost]
    [Route("seed")]
    public void Seed()
    {
        _service.Seed();
    }
}