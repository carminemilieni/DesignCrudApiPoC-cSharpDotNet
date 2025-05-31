using System.ComponentModel.DataAnnotations;

namespace DesignCrudApiPoC.API.Models;


public interface IPeople
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthday { get; set; }
    public int Age { get; }
}

public class PeopleModel : IPeople
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthday { get; set; }
    public int Age { get; }
    
    public PeopleModel(int id, string firstName, string lastName, DateOnly birthday)
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