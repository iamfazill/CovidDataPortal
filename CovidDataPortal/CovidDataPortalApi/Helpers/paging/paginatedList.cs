namespace CovidDataPortalApi.Helpers.paging
{
    public class paginatedList<T>:List<T>
    {
        public int PageIndex { get; private set; }

        public int TotalPages { get; private set; }


        public paginatedList(List<T> items, int count,int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }


        public bool hasPreviousPage
        {

            get
            {

                return PageIndex > 1;
            }
        }

        public bool hasNextPage
        {

            get { return PageIndex < TotalPages; }  
        }


        public static paginatedList<T> Create(IQueryable<T> source, int pageIndex,int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();


            return new paginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
