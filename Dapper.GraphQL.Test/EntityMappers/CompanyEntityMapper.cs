﻿using Dapper.GraphQL.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.GraphQL.Test.EntityMappers
{
    public class CompanyEntityMapper :
        IEntityMapper<Company>
    {
        public Company Map(EntityMapContext context)
        {
            // NOTE: Order is very important here.  We must map the objects in
            // the same order they were queried in the QueryBuilder.
            var company = context.Start<Company>();
            var email = context.Next<Email>("emails");
            var phone = context.Next<Phone>("phones");

            if (company != null)
            {
                if (email != null &&
                    // Eliminate duplicates
                    !company.Emails.Any(e => e.Address == email.Address))
                {
                    company.Emails.Add(email);
                }

                if (phone != null &&
                    // Eliminate duplicates
                    !company.Phones.Any(p => p.Number == phone.Number))
                {
                    company.Phones.Add(phone);
                }
            }

            return company;
        }
    }
}
