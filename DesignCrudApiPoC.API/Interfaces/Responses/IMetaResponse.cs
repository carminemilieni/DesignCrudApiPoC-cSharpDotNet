namespace DesignCrudApiPoC.API.Interfaces.Responses;

public interface IMetaResponse
{
    public IPaginationResponse? Pagination { get; set; }
    public object? Errors { get; set; }
}