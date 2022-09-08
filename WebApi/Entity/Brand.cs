using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
  public class Brand
  {
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
  }

}