using System;
using System.Linq.Expressions;

namespace ExRam.Gremlinq.Core
{
    public partial interface IPropertyGremlinQueryBase : IGremlinQueryBase
    {
        IGremlinQuery<object> Lower();
    }

    public partial interface IPropertyGremlinQueryBase<TElement> :
        IPropertyGremlinQueryBase,
        IGremlinQueryBase<TElement>
    {
        IValueGremlinQuery<string> Key();

        new IGremlinQuery<TElement> Lower();

        IValueGremlinQuery<object> Value();
        IValueGremlinQuery<TValue> Value<TValue>();

        IPropertyGremlinQuery<TElement> Where(Expression<Func<TElement, bool>> predicate);
    }

    public partial interface IPropertyGremlinQueryBaseRec<TSelf> :
        IPropertyGremlinQueryBase,
        IGremlinQueryBaseRec<TSelf>
        where TSelf : IPropertyGremlinQueryBaseRec<TSelf>
    {

    }

    public partial interface IPropertyGremlinQueryBaseRec<TElement, TSelf> :
        IPropertyGremlinQueryBaseRec<TSelf>,
        IPropertyGremlinQueryBase<TElement>,
        IGremlinQueryBaseRec<TElement, TSelf>
        where TSelf : IPropertyGremlinQueryBaseRec<TElement, TSelf>
    {

    }

    public partial interface IPropertyGremlinQuery<TElement> :
        IPropertyGremlinQueryBaseRec<TElement, IPropertyGremlinQuery<TElement>>
    {

    }
}
