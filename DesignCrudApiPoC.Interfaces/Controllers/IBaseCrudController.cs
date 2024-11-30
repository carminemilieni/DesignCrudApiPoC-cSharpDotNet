namespace DesignCrudApiPoC.Interfaces.Controllers;

using Microsoft.AspNetCore.Mvc;

public interface IBaseCrudController<T>
{
    public abstract Task<ActionResult<T[]>> FindMany();
    public abstract Task<ActionResult<T>> FindOne(int id);
    public abstract Task<ActionResult<T>> CreateOne([FromBody] T obj);
    public abstract Task<ActionResult<T>> UpdateOne(int id, [FromBody] T obj);
    public abstract Task<ActionResult<T>> DeleteOne(int id);
}