using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
  public class Car
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string CarName { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public int ColorId { get; set; }
    public Color Color { get; set; }
  }

}