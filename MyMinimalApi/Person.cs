using System;
using System.ComponentModel.DataAnnotations;

namespace MyMinimalApi
{
    public class Person
    {
        [Required, MinLength(2)]
        public string? FirstName { get; set; }

        [Required, MinLength(2)]
        public string? LastName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}

