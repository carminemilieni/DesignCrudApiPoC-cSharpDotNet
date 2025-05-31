namespace DesignCrudApiPoC.API.Interfaces.Responses;

public interface IEntityResponse<T>
{
    public T Data { get; set; }
    public IMetaResponse Meta { get; set; }
}