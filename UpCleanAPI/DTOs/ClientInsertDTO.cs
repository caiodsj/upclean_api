﻿using UpCleanAPI.Models;

namespace UpCleanAPI.DTOs
{
    public class ClientInsertDTO
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CPF { get; set; }
    }
}
