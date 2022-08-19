using System.ComponentModel.DataAnnotations;
using System;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    [Required]
    [StringLength(30)]
    public string Name { get; set; }
    [Required]
    [StringLength(30, ErrorMessage = "A name is needed to post")]
    public string Species { get; set; }
    [Required]
    [StringLength(30, ErrorMessage = "A species is needed to post")]
    public string Breed { get; set; }
    public string PostDate { get; set; }
  }
}