﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using Microsoft.AspNetCore.Http;

namespace eFahionStore.Common.RequestViewModels.Users
{
    [Validator(typeof(RegistrationViewModelValidator))]
    public class RegistrationViewModel
    {
        public IFormFile? file { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Quyen { get; set; }
    }
}
