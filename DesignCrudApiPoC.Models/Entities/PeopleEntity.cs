using System.ComponentModel.DataAnnotations;
using DesignCrudApiPoC.Interfaces.Entities;

namespace DesignCrudApiPoC.Models.Entities;

public class PeopleEntity : IPeople
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthday { get; set; }
    public int Age { get; }
    
    public PeopleEntity(int id, string firstName, string lastName, DateOnly birthday)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        Age = CalculateAge();
    }
    
    private int CalculateAge()
    {
        return DateTime.Now.Year - Birthday.Year;
    }

}