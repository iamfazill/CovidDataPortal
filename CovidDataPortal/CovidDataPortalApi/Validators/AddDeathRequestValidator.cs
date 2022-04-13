
 
using FluentValidation;

namespace CovidDataPortalApi.Validators
{
    public class addDeathRequestValidator:AbstractValidator<Models.DTO.AddDeathRequest>
    {
        public addDeathRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.ContactNumber).NotEmpty();
            RuleFor(x => x.Block).NotEmpty();
            
            RuleFor(x => x.DateOfAdmission).NotEmpty();
            RuleFor(x => x.SampleCollected).NotEmpty();
            RuleFor(x => x.SampleTestedAt).NotEmpty();
            RuleFor(x => x.UnderlyingCondition).NotEmpty();
            RuleFor(x => x.HospitalWhereAdmitted).NotEmpty();
            RuleFor(x => x.DateOfDeath).NotEmpty();
            RuleFor(x => x.DaysTestedBeforeDeath).NotEmpty();
            RuleFor(x => x.DaysAdmitted).NotEmpty();
            RuleFor(x => x.DaysAdmittedInICU).NotEmpty();
            RuleFor(x => x.DaysInOxygenSupportOrVentillator).NotEmpty();
            RuleFor(x => x.Remarks).NotEmpty();
            RuleFor(x => x.VaccinationStatus).NotEmpty();
        }
    }
}
