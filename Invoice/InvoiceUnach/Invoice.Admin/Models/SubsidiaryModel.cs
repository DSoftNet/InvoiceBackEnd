using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Admin.Models
{
    public class SubsidiaryModel
    {
        [TempData] public string Option { get; set; }
        
        [BindProperty] public InputSubsidiary InputSubsidiaryModel { get; set; }
        [BindProperty] public List<InputSubsidiary> InputSubsidiaries  { get; set; }

        public class InputSubsidiary
        {
            public Guid Id { get; set; }
            
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 30 caracteres.")] 
            public string Name { get; private set; }
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 30 caracteres.")]
            public string Address{ get; private set; }
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 10 caracteres.")]
            public string Phone1 { get; private set; }
            public string Phone2 { get; private set; }
            public Guid UserId { get; private set; }
            
            public InputSubsidiary(Guid id,string name, string address, string phone1, string phone2, Guid userId)
            {
                Name = name;
                Address = address;
                Phone1 = phone1;
                Phone2 = phone2;
                UserId = userId;
            }

        }
    }
}