
using DesignCrudApiPoC.API.Interfaces.Responses;

namespace DesignCrudApiPoC.API.Responses;

public class EntityResponse<T>(T data, MetaResponse meta)
{
    public T Data { get; set; } = data;
    public MetaResponse Meta { get; set; } = meta;

    public EntityResponse(T data) : this(data, new MetaResponse(null, null))
    {
    }
}