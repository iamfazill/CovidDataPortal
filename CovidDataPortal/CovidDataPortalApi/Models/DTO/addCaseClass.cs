namespace CovidDataPortalApi.Models.DTO
{
    public class addCaseClass
    {
        public DateTime? Date { get; set; }
        public int? Contacts { get; set; }
        public int? Comorbid { get; set; }
        public int? PrePostProcedural { get; set; }
        public int? Inpatient { get; set; }
        public int? Random { get; set; }
        public int? Traveller { get; set; }
        public int? Defence { get; set; }
        public int? Anc { get; set; }
        public int? Symptomatic { get; set; }

        public int? Gsp { get; set; }
        public int? Untraced { get; set; }
        public int? Reinfection { get; set; }
        public int? TotalDaysCases { get; set; }
        public int? ContactsTraced { get; set; }
    }
}
