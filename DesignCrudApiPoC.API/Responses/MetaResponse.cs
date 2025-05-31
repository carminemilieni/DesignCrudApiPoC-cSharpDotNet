

using DesignCrudApiPoC.API.Interfaces.Responses;

namespace DesignCrudApiPoC.API.Responses;

public class MetaResponse
{
    public PaginationResponse? Pagination { get; set; }
    public object? Errors { get; set; }
    
    public MetaResponse(PaginationResponse? pagination, object? errors)
    {
        Pagination = pagination;
        Errors = errors;
    }
    
    public MetaResponse(int page, int pageSize, int items, int? pageCount, int total, int? nextPage, int? prevPage)
    {
        Pagination = new PaginationResponse(page, pageSize, items, pageCount, total, nextPage, prevPage);
        Errors = null;
    }
}