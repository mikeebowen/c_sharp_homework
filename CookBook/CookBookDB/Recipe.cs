using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookbookDB
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Author { get; set; }
        public string Directions { get; set; }
        [Column("ImageURL")]
        [StringLength(2083)]
        public string ImageUrl { get; set; }

        [InverseProperty("Recipe")]
        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}
