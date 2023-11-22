using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantProfileLogic:BaseLogic<ApplicantProfilePoco>
    {
        public ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository):base(repository)
        {
            
        }
        protected override void Verify(ApplicantProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (ApplicantProfilePoco poco in pocos)
            {
                if (poco.CurrentSalary < 0)
                {
                    exceptions.Add(new ValidationException(111, $"CurrentSalary for ApplicantProfile {poco.Id} cannot be negative\")"));
                }
                
                if (poco.CurrentRate < 0)
                {
                    exceptions.Add(new ValidationException(112, $"CurrentRate for ApplicantProfile {poco.Id} cannot be negative\")"));
                }
            }
            
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
        public override void Add(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);

            base.Add(pocos);
        }

        public override void Update(ApplicantProfilePoco[] pocos)
        {
           Verify (pocos); 

            base.Update(pocos);
        }
    }
}
