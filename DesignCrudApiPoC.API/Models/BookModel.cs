using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace DesignCrudApiPoC.API.Models;

public interface IBook
{
    public string Title { get; set; }

    //public string Author { get; set; }
    public int Pages { get; set; }
}

public class BookModel(string title, int pages) : IBook
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Id { get; set; }

    [MaxLength(100)] [Required] public string Title { get; set; } = title;

    public int Pages { get; set; } = pages;
}