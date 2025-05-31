using DesignCrudApiPoC.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignCrudApiPoC.API.Data;

public class AppDbContextData(DbContextOptions<AppDbContextData> options) : DbContext(options)
{
    public DbSet<PeopleModel> Peoples { get; init; }
    
    public DbSet<BookModel> Books { get; init; }
}