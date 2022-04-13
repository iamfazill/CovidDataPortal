namespace CovidDataPortalApi.Models.Domain
{
    public class deathResource
    {

        public List<Deaths> allDeathResponses= new List<Deaths>();
        public int pages { get; set; }
        public int currentPage { get; set; }
    }
}
