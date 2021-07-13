using System;
using System.ComponentModel.DataAnnotations;

namespace recipesapp.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(3, ErrorMessage = "A descrição deve ter pelo menos três caracteres.")]
        public string Title { get; set; }
    }
}