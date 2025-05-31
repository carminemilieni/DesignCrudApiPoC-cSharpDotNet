using DesignCrudApiPoC.API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DesignCrudApiPoC.API.Interfaces.Controllers;

public interface IBaseCrudController<T>
{
    public ActionResult<EntityResponse<T[]>> FindMany(int? page, int? pageSize);
    public ActionResult<EntityResponse<T?>> FindOne(int id);
    public ActionResult<EntityResponse<T>> CreateOne([FromBody] T payload);
    public ActionResult<EntityResponse<T?>> UpdateOne(int id, [FromBody] T payload);
    public ActionResult<EntityResponse<T?>> DeleteOne(int id);
}