using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Admin.Models
{
    public class ProductModel
    {
        [TempData] public string Option { get; set; }

        [BindProperty] public Guid UserId { get; set; }
        
        [BindProperty] public InputProduct InputProductModel { get; set; }

        [BindProperty] public List<InputProduct> InputProducts { get; set; }

        public class InputProduct
        {
            public Guid Id { get; set; }
            
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 50 caracteres.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(250, ErrorMessage = "Digite máximo 250 caracteres.")]
            public string Description { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(30, ErrorMessage = "Digite máximo 30 caracteres.")]
            public string Code { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            public decimal Price { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            public bool IsIva { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            public int Stock { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            public bool IsExpiration { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            public DateTime ExpirationAt { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            public bool Status { get; set; }

            public Guid UserId { get; set; }
        }
    }
}