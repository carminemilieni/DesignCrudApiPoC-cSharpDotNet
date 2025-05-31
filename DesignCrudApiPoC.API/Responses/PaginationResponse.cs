

using DesignCrudApiPoC.API.Interfaces.Responses;

namespace DesignCrudApiPoC.API.Responses;

public class PaginationResponse : IPaginationResponse
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int PagesCount { get; set; }
    
    public int Items { get; set; }
    public int Total { get; set; }
    public int? NextPage { get; set; }
    public int? PrevPage { get; set; }
    
    public PaginationResponse(int page, int pageSize, int items, int? pagesCount, int total, int? nextPage, int? prevPage)
    {
        Page = page + 1;
        PageSize = pageSize;
        Total = total;
        Items = items;
        PagesCount = pagesCount ?? _calculatePageCount();
        NextPage = nextPage ?? _calculateNextPage();
        PrevPage = prevPage ?? _calculatePrevPage();
    }
    
    private int _calculatePageCount()
    {
        return (int) Math.Ceiling((double) Total / PageSize);
    }
    
    private int? _calculateNextPage()
    {
        return Page < PagesCount ? Page + 1 : null;
    }
    private int? _calculatePrevPage()
    {
        return Page > 1 ? Page - 1 : null;
    }
}