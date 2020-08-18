﻿using System;
using System.Linq.Expressions;

namespace ExRam.Gremlinq.Core
{
    public interface IValueTupleGremlinQueryBase :
        IGremlinQueryBase
    {
    }

    public interface IValueTupleGremlinQueryBase<TElement> :
        IValueTupleGremlinQueryBase,
        IGremlinQueryBase<TElement>
    {
        IValueGremlinQuery<TTargetValue> Select<TTargetValue>(Expression<Func<TElement, TTargetValue>> projection);

        IValueTupleGremlinQuery<(T1, T2)> Select<T1, T2>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2);
        IValueTupleGremlinQuery<(T1, T2, T3)> Select<T1, T2, T3>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3);
        IValueTupleGremlinQuery<(T1, T2, T3, T4)> Select<T1, T2, T3, T4>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5)> Select<T1, T2, T3, T4, T5>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6)> Select<T1, T2, T3, T4, T5, T6>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6, T7)> Select<T1, T2, T3, T4, T5, T6, T7>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6, Expression<Func<TElement, T7>> projection7);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6, T7, T8)> Select<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6, Expression<Func<TElement, T7>> projection7, Expression<Func<TElement, T8>> projection8);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> Select<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6, Expression<Func<TElement, T7>> projection7, Expression<Func<TElement, T8>> projection8, Expression<Func<TElement, T9>> projection9);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6, Expression<Func<TElement, T7>> projection7, Expression<Func<TElement, T8>> projection8, Expression<Func<TElement, T9>> projection9, Expression<Func<TElement, T10>> projection10);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)> Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6, Expression<Func<TElement, T7>> projection7, Expression<Func<TElement, T8>> projection8, Expression<Func<TElement, T9>> projection9, Expression<Func<TElement, T10>> projection10, Expression<Func<TElement, T11>> projection11);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)> Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6, Expression<Func<TElement, T7>> projection7, Expression<Func<TElement, T8>> projection8, Expression<Func<TElement, T9>> projection9, Expression<Func<TElement, T10>> projection10, Expression<Func<TElement, T11>> projection11, Expression<Func<TElement, T12>> projection12);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)> Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6, Expression<Func<TElement, T7>> projection7, Expression<Func<TElement, T8>> projection8, Expression<Func<TElement, T9>> projection9, Expression<Func<TElement, T10>> projection10, Expression<Func<TElement, T11>> projection11, Expression<Func<TElement, T12>> projection12, Expression<Func<TElement, T13>> projection13);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)> Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6, Expression<Func<TElement, T7>> projection7, Expression<Func<TElement, T8>> projection8, Expression<Func<TElement, T9>> projection9, Expression<Func<TElement, T10>> projection10, Expression<Func<TElement, T11>> projection11, Expression<Func<TElement, T12>> projection12, Expression<Func<TElement, T13>> projection13, Expression<Func<TElement, T14>> projection14);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)> Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6, Expression<Func<TElement, T7>> projection7, Expression<Func<TElement, T8>> projection8, Expression<Func<TElement, T9>> projection9, Expression<Func<TElement, T10>> projection10, Expression<Func<TElement, T11>> projection11, Expression<Func<TElement, T12>> projection12, Expression<Func<TElement, T13>> projection13, Expression<Func<TElement, T14>> projection14, Expression<Func<TElement, T15>> projection15);
        IValueTupleGremlinQuery<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)> Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Expression<Func<TElement, T1>> projection1, Expression<Func<TElement, T2>> projection2, Expression<Func<TElement, T3>> projection3, Expression<Func<TElement, T4>> projection4, Expression<Func<TElement, T5>> projection5, Expression<Func<TElement, T6>> projection6, Expression<Func<TElement, T7>> projection7, Expression<Func<TElement, T8>> projection8, Expression<Func<TElement, T9>> projection9, Expression<Func<TElement, T10>> projection10, Expression<Func<TElement, T11>> projection11, Expression<Func<TElement, T12>> projection12, Expression<Func<TElement, T13>> projection13, Expression<Func<TElement, T14>> projection14, Expression<Func<TElement, T15>> projection15, Expression<Func<TElement, T16>> projection16);
    }

    public interface IValueTupleGremlinQuery<TElement> :
        IValueTupleGremlinQueryBase<TElement>,
        IGremlinQueryBaseRec<TElement, IValueTupleGremlinQuery<TElement>>
    {

    }
}
