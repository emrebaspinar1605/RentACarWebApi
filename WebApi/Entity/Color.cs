using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
  public class Color
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
  }

}