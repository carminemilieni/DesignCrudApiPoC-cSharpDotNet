using DesignCrudApiPoC.API.Data;
using DesignCrudApiPoC.API.Models;

namespace DesignCrudApiPoC.API.Repositories;

public interface IBookRepository
{
    BookModel[] FindMany(int page, int limit);

    BookModel FindOne(int id);

    BookModel CreateOne(BookModel bookModel);

    BookModel UpdateOne(int id, BookModel bookModel);

    BookModel DeleteOne(int id);

    int CountAll();

    int CountMany(int page, int limit);
}

public class BookRepository(AppDbContextData context) : IBookRepository
{
    private readonly AppDbContextData _ctx = context;

    public BookModel[] FindMany(int page, int limit)
    {
        return _ctx.Books.Skip(page * limit).Take(limit).ToArray();
    }

    public BookModel FindOne(int id)
    {
        var find = _ctx.Books.Find(id);
        return find ?? throw new Exception("Not found");
    }

    public BookModel CreateOne(BookModel bookModel)
    {
        var add = _ctx.Books.Add(bookModel);
        _ctx.SaveChanges();
        return add.Entity;
    }

    public BookModel UpdateOne(int id, BookModel bookModel)
    {
        var find = FindOne(id);
        find.Title = bookModel.Title;
        _ctx.SaveChanges();
        return find;
    }

    public BookModel DeleteOne(int id)
    {
        var find = FindOne(id);
        var remove = _ctx.Books.Remove(find);
        _ctx.SaveChanges();
        return remove.Entity;
    }

    public int CountAll()
    {
        return _ctx.Books.Count();
    }

    public int CountMany(int page, int limit)
    {
        return _ctx.Books.Skip(page * limit).Take(limit).Count();
    }
}