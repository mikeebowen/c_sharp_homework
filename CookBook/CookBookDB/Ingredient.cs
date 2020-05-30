using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookbookDB
{
    public partial class Ingredient
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("RecipeID")]
        public int RecipeId { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        [Column("ImageURL")]
        [StringLength(2083)]
        public string ImageUrl { get; set; }

        [ForeignKey(nameof(RecipeId))]
        [InverseProperty("Ingredient")]
        public virtual Recipe Recipe { get; set; }
    }
}
