using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Admin.Models
{
    public class SubsidiaryModel
    {
        [TempData] public string Option { get; set; }
        
        [BindProperty] public Guid UserId { get; set; }
        [BindProperty] public InputSubsidiary InputSubsidiaryModel { get; set; }
        [BindProperty] public List<InputSubsidiary> InputSubsidiaries  { get; set; }

        public class InputSubsidiary
        {
            public Guid Id { get; set; }
            
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 30 caracteres.")] 
            public string Name { get;  set; }
            
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 30 caracteres.")]
            public string Address{ get;  set; }
            
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 10 caracteres.")]
            public string Phone1 { get;  set; }
            public string Phone2 { get;  set; }
            public Guid UserId { get;  set; }

        }
    }
}