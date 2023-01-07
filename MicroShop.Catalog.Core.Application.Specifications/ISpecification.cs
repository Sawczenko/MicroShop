﻿using System.Linq.Expressions;

namespace MicroShop.Catalog.Core.Application.Specifications
{
    public interface ISpecification<T>
    {

        Expression<Func<T,bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get;}
    }
}
