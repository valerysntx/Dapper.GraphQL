﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.GraphQL.Test.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Email> Emails { get; set; }
        public IList<Phone> Phones { get; set; }
    }
}
