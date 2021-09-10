using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Admin.Models
{
    public class ClientModel
    {
        [TempData] public string Option { get; set; }
        [BindProperty] public Guid UserId { get; set; }

        [BindProperty] public InputClient InputClientModel { get; set; }

        [BindProperty] public List<InputClient> InputClients { get; set; }

        public class InputClient
        {
            
            public Guid Id { get; set; }
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(30, ErrorMessage = "Digite máximo 30 caracteres.")]
            public string FirstName { get;  set; }
            public string SecondName { get;  set; }
            
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(30, ErrorMessage = "Digite máximo 30 caracteres.")]
            public string FirstLastName { get;  set; }
            
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(30, ErrorMessage = "Digite máximo 30 caracteres.")]
            public string SecondLastName { get;  set; }
            public string IdentificationType { get;  set; }
            
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(30, ErrorMessage = "Digite máximo 30 caracteres.")]
            public string Identification { get;  set; }
            
            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(250, ErrorMessage = "Digite máximo 250 caracteres.")]
            public string Email { get;  set; }

            public string Address { get;  set; }

            public string Phone { get;  set; }

            public string CellPhone { get;  set; }
            public bool Status { get;  set; }
            public Guid UserId { get;  set; }
            
           /* public InputClient(Guid id, string firstName, string secondName, string firstLastName,
                string secondLastName, string identificationType, string identification, string email, string address,
                string phone, string cellPhone, bool status, Guid userId)
            {
                Id = id;
                FirstName = firstName;
                SecondName = secondName;
                FirstLastName = firstLastName;
                SecondLastName = secondLastName;
                IdentificationType = identificationType;
                Identification = identification;
                Email = email;
                Address = address;
                Phone = phone;
                CellPhone = cellPhone;
                Status = status;
                UserId = userId;
            }*/
        }
    }
}