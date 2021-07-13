using System;
using System.ComponentModel.DataAnnotations;

namespace recipesapp.Models
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O título da receita é obrigatório.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O tempo de preparo em minutos é obrigatório.")]
        public int TimeInMinutes { get; set; }

        [Required(ErrorMessage = "É necessário informar uma categoria.")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}