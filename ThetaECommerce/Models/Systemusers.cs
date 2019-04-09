﻿using System;
using System.Collections.Generic;

namespace ThetaECommerce.Models
{
    public partial class Systemusers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Extras { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
