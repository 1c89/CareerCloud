using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantWorkHistoryLogic:BaseLogic<ApplicantWorkHistoryPoco>

    {
        public ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository):base(repository)
        {
            
        }

        public override void Add(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);

        }

        public override void Update(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantWorkHistoryPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos) 
            {
                if (string.IsNullOrEmpty(poco.CompanyName) || poco.CompanyName.Length < 3)
                {
                    exceptions.Add(new ValidationException(105, $"CompanyName for ApplicantWorkHistory {poco.Id} must be at least 2 characters"));
                }

                if (!(poco.StartMonth > 0 && poco.StartMonth <= 12))
                {
                    exceptions.Add(new ValidationException(105, $"StartMonth for ApplicantWorkHistory {poco.Id} cannot be greater than 12"));
                }

                if (!(poco.EndMonth > 0 && poco.EndMonth <= 12))
                {
                    exceptions.Add(new ValidationException(105, $"EndMonth for ApplicantWorkHistory {poco.Id} cannot be greater than 12"));
                }

                if (poco.StartYear < 1900)
                {
                    exceptions.Add(new ValidationException(105, $"StartYear for ApplicantWorkHistory {poco.Id} cannot be less than 1900"));
                }

                if (poco.StartYear > poco.EndYear)
                {
                    exceptions.Add(new ValidationException(105, $"EndYear for ApplicantWorkHistory {poco.Id} cannot be less than Start"));
                }

            }

            if (exceptions.Count > 0) 
            {
                throw new AggregateException(exceptions);
            }

        }
    }
}
