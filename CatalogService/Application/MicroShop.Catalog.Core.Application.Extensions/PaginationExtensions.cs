﻿using MicroShop.Catalog.Core.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Core.Application.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize, CancellationToken token = default)
        {
            var count = await source.CountAsync(token);

            if (count > 0)
            {
                var amountToSkip = GetAmountToSkip(pageNumber, pageSize);

                var items = await source
                    .Skip(amountToSkip)
                    .Take(pageSize)
                    .ToListAsync(token);
                return new PagedList<T>(items, count, pageNumber, pageSize);
            }

            return new(Enumerable.Empty<T>(), 0, 0, 0);
        }

        private static int GetAmountToSkip(int pageNumber, int pageSize)
        {
            var skip = (pageNumber - 1) * pageSize;

            if (skip <= 0)
            {
                skip = 1;
            }

            return skip;
        }
    }
}