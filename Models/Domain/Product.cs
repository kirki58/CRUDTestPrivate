﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDTest.Models.Domain;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public DateTime Addition_Date { get; set; }
    public DateTime Updated_At { get; set; }
}
