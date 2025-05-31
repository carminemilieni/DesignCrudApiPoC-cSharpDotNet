using DesignCrudApiPoC.API.Data;
using DesignCrudApiPoC.API.Models;

namespace DesignCrudApiPoC.API.Repositories;

public interface IPeopleRepository
{
    int CreateOne(PeopleModel peopleModel);
    PeopleModel? FindOneById(int id);
    PeopleModel[] FindAll();
}

public class PeopleRepository(AppDbContextData context) : IPeopleRepository
{
    public int CreateOne(PeopleModel peopleModel)
    {
        using var ctx = context;
        context.Peoples.Add(peopleModel);
        return context.SaveChanges();
    }

    public PeopleModel? FindOneById(int id)
    {
        using var ctx = context;
        return context.Peoples.Find(id);
    }
    
    public PeopleModel[] FindAll()
    {
        using var ctx = context;
        return context.Peoples.ToArray();
    }
}