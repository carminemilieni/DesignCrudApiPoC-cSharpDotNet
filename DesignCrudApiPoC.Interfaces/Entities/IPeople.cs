namespace DesignCrudApiPoC.Interfaces.Entities;

public interface IPeople
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthday { get; set; }
    public int Age { get; }
}