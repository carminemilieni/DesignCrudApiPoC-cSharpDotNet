namespace DesignCrudApiPoC.API.Interfaces.Responses;

public interface IPaginationResponse
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int PagesCount { get; set; }
    
    public int Items { get; set; }
    public int Total { get; set; }
    public int? NextPage { get; set; }
    public int? PrevPage { get; set; }
}