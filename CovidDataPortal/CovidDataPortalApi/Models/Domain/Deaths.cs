namespace CovidDataPortalApi.Models.Domain
{
    public class Deaths
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Block { get; set; }
        public string District { get; set; }

        public DateTime DateOfAdmission { get; set; }

        public DateTime SampleCollection { get; set; }

        public string SampleTestedAt { get; set; }

        public string UnderlyingCondition { get; set; }

        public string HospitalWhereAdmitted { get; set; }


        public DateTime DateOfDeath { get; set; }

        public string DaysTestedBeforeDeath { get; set; }

        public string DaysAdmitted { get; set; }

        public string DaysAdmittedInICU { get; set; }

        public string DaysInOxygenSupportOrVentillator { get; set; }

        public string Remarks { get; set; }

        public string VaccinationStatus { get; set; }
    }
            
}
