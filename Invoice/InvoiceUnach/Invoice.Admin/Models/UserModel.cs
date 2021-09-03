using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Admin.Models
{
    public class UserModel
    {
        [TempData] 
        public string Option { get; set; }

        [BindProperty] 
        public InputUser InputUserModel { get; set; }

        [BindProperty] 
        public  List<InputUser> InputUsers { get; set; }

        public class InputUser
        {
            public Guid Id { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 50 caracteres.")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 50 caracteres.")]
            public string SecondName { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 50 caracteres.")]
            public string FirstLastName { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 50 caracteres.")]
            public string SecondLastName { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(50, ErrorMessage = "Digite máximo 50 caracteres.")]
            public string Identification { get; set; }
        }
    }
}