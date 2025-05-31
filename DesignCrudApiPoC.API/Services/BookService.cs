using DesignCrudApiPoC.API.Consts;
using DesignCrudApiPoC.API.Models;
using DesignCrudApiPoC.API.Repositories;
using DesignCrudApiPoC.API.Responses;

namespace DesignCrudApiPoC.API.Services;

public interface IBookService
{
    public EntityResponse<BookModel[]> FindMany(int? page, int? pageSize);

    public EntityResponse<BookModel> FindOne(int id);

    public EntityResponse<BookModel> CreateOne(BookModel payload);

    public EntityResponse<BookModel> UpdateOne(int id, BookModel payload);

    public EntityResponse<BookModel> DeleteOne(int id);
    void Seed();
}

public class BookService(IBookRepository repository) : IBookService
{
    private readonly IBookRepository _repository = repository;

    public EntityResponse<BookModel[]> FindMany(int? page, int? pageSize)
    {
        var cPage = page ?? PaginationConst.Page;
        var cPageSize = pageSize ?? PaginationConst.PageSize;

        if (cPage < 1) throw new ArgumentOutOfRangeException(nameof(page), "Page must be greater than 0");

        if (cPageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize), "PageSize must be greater than 0");

        cPage = cPage - 1;

        var data = _repository.FindMany(cPage, cPageSize);
        var pagination =
            new PaginationResponse(cPage, cPageSize, data.Length, null, _repository.CountAll(), null, null);
        return new EntityResponse<BookModel[]>(
            data,
            new MetaResponse(pagination, null)
        );
    }

    public EntityResponse<BookModel> FindOne(int id)
    {
        return new EntityResponse<BookModel>
        (
            _repository.FindOne(id),
            new MetaResponse(null, null)
        );
    }

    public EntityResponse<BookModel> CreateOne(BookModel payload)
    {
        return new EntityResponse<BookModel>
        (
            _repository.CreateOne(payload),
            new MetaResponse(null, null)
        );
    }

    public EntityResponse<BookModel> UpdateOne(int id, BookModel payload)
    {
        return new EntityResponse<BookModel>(
            _repository.UpdateOne(id, payload),
            new MetaResponse(null, null)
        );
    }

    public EntityResponse<BookModel> DeleteOne(int id)
    {
        return new EntityResponse<BookModel>(
            _repository.DeleteOne(id),
            new MetaResponse(null, null)
        );
    }


    public void Seed()
    {
        BookModel[] books =
        [
            new("The Hobbit", 1520),
            new("The Lord of the Rings", 1520),
            new("The Silmarillion", 1520),
            new("The Children of Hurin", 1520),
            new("The Fall of Gondolin", 1520),
            new("Beren and Luthien", 1520),
            new("Unfinished Tales", 1520),
            new("The History of Middle-earth", 1520),
            new("The Adventures of Tom Bombadil", 1520),
            new("The Road Goes Ever On", 1520),
            new("The Father Christmas Letters", 1520),
            new("The Monsters and the Critics", 1520),
            new("The Story of Kullervo", 1520),
            new("The Lay of Aotrou and Itroun", 1520),
            new("The Homecoming of Beorhtnoth Beorhthelm's Son", 1520),
            new("The Legend of Sigurd and Gudrun", 1520)
        ];

        foreach (var book in books) _repository.CreateOne(book);
    }
}