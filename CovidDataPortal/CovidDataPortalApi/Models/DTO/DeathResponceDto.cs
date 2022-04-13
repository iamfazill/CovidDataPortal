namespace CovidDataPortalApi.Models.DTO
{
    public class DeathResponceDto
    {
        public List<Deaths > AllResposeDeaths { get; set; } = new List<Deaths>();
        public int pages { get; set; }
        public int currentPage { get; set; }
    }
}
