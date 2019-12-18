namespace ExRam.Gremlinq.Core
{
    public partial interface IArrayGremlinQueryBase : IGremlinQueryBase
    {
        IGremlinQuery<object[]> Lower();
    }

    public partial interface IArrayGremlinQueryBaseRec<TSelf> :
        IArrayGremlinQueryBase,
        IGremlinQueryBaseRec<TSelf>
        where TSelf : IArrayGremlinQueryBaseRec<TSelf>
    {

    }

    public partial interface IArrayGremlinQueryBase<TArray, TQuery> :
        IArrayGremlinQueryBase,
        IGremlinQueryBase<TArray>
    {
        new IGremlinQuery<TArray> Lower();
        TQuery Unfold();
    }

    public partial interface IArrayGremlinQueryBaseRec<TArray, TQuery, TSelf> :
        IArrayGremlinQueryBaseRec<TSelf>,
        IArrayGremlinQueryBase<TArray, TQuery>,
        IGremlinQueryBaseRec<TArray, TSelf>
        where TSelf : IArrayGremlinQueryBaseRec<TArray, TQuery, TSelf>
    {

    }

    public partial interface IArrayGremlinQuery<TArray, TQuery> :
        IArrayGremlinQueryBaseRec<TArray, TQuery, IArrayGremlinQuery<TArray, TQuery>>
    {

    }
}
