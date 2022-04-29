namespace CovidDataPortalApi.Models.CommonModels
{
    public class PaginationModel<T>
    {
        public List<T> Records { get; set; }
        public RecordCountModel RecordCount { get; set; }

    }
    public class RecordCountModel
    {
        public long Count { get; set; }
    }
}
