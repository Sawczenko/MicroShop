using MicroShop.Catalog.Application.Models;
using AutoMapper;

namespace MicroShop.Catalog.Application.Services.Mapper.Converters
{
    internal class PagedListConverter<TSource, TDestination> : ITypeConverter<PagedList<TSource>, PagedList<TDestination>>
    {
        public PagedList<TDestination> Convert(PagedList<TSource> source, PagedList<TDestination> destination,
            ResolutionContext context)
        {
            if (destination == null)
            {
                destination = new PagedList<TDestination>(Enumerable.Empty<TDestination>(), 0, 0, 0);
            }

            foreach (var item in source)
            {
                var dest = context.Mapper.Map<TSource, TDestination>(item);
                destination.Add(dest);
            }

            destination.PageSize = source.PageSize;
            destination.Count = source.Count;

            return destination;
        }
    }
}
