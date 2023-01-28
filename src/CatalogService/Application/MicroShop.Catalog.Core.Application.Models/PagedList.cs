using System.Collections;

namespace MicroShop.Catalog.Application.Models
{
    public class PagedList<T> : IReadOnlyList<T>
    {
        private readonly IList<T> subset;
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            subset = items as IList<T> ?? new List<T>(items);
            Count = subset.Count;
        }

        public int PageSize { get; set; }

        public int PageNumber { get; }

        public int TotalPages { get; }

        public bool IsFirstPage => PageNumber == 1;

        public bool IsLastPage => PageNumber == TotalPages;

        public int Count { get; set; }

        public T this[int index] => subset[index];

        public IEnumerator<T> GetEnumerator() => subset.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return subset.GetEnumerator();
        }

        public void Add(T item)
        {
            subset.Add(item);
            Count++;
        }
    }
}
