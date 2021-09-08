using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Admin.Models
{
    public class UserDetailModel
    {
        
        [BindProperty] public Guid UserId { get; set; }
        [BindProperty] public string Firsname { get; set; }
        [BindProperty] public int ProductsTotal { get; set; }
        [BindProperty] public int SubsidiariesTotal { get; set; }
        [BindProperty] public int ClientsTotal { get; set; }
    }
}