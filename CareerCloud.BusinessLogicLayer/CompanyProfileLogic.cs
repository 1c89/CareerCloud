using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic:BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository):base(repository)
        {
            
        }
        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);

            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);

            base.Update(pocos);
        }
        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyProfilePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyWebsite) || !Regex.IsMatch(poco.CompanyWebsite, @"[\w\d]+\.(com|biz|ca)\b$", RegexOptions.IgnoreCase))
                { 
                
                    exceptions.Add(new ValidationException(600, $"CompanyWebsite for CompanyProfile {poco.Id} valid websites must end with the \r\nfollowing extensions – \".ca\",\".com\",\".biz\""));
                }


                if (string.IsNullOrEmpty(poco.ContactPhone) ||  !Regex.IsMatch(poco.ContactPhone, @"^\d{3}-\d{3}-\d{4}$", RegexOptions.IgnoreCase))
                {
                    exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} is not in the required format."));
                }
                
            }


            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
    }
}
