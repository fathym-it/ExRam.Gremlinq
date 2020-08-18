﻿// ReSharper disable ArrangeThisQualifier
// ReSharper disable CoVariantArrayConversion

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ExRam.Gremlinq.Core.GraphElements;
using Newtonsoft.Json;

namespace ExRam.Gremlinq.Core
{
    partial class GremlinQuery<TElement, TOutVertex, TInVertex, TScalar, TMeta, TFoldedQuery> :
        IGremlinQueryAdmin,

        IGremlinQuerySource,
        IGremlinQuery<TElement>,

        IArrayGremlinQuery<TElement, TScalar, TFoldedQuery>,

        IElementGremlinQuery<TElement>,

        IValueGremlinQuery<TElement>,
        IValueTupleGremlinQuery<TElement>,

        IEdgeOrVertexGremlinQuery<TElement>,
        IVertexGremlinQuery<TElement>,
        IEdgeGremlinQuery<TElement>,
        IInOrOutEdgeGremlinQuery<TElement, TOutVertex>,
        IBothEdgeGremlinQuery<TElement, TOutVertex, TInVertex>,

        IInEdgeGremlinQuery<TElement, TInVertex>,
        IOutEdgeGremlinQuery<TElement, TOutVertex>,

        IVertexPropertyGremlinQuery<TElement, TScalar>,
        IVertexPropertyGremlinQuery<TElement, TScalar, TMeta>,
        IPropertyGremlinQuery<TElement> where TMeta : class
    {
        TFoldedQuery IArrayGremlinQueryBase<TElement, TScalar, TFoldedQuery>.MeanLocal() => MeanLocal().ChangeQueryType<TFoldedQuery>();

        TFoldedQuery IArrayGremlinQueryBase<TElement, TScalar, TFoldedQuery>.Unfold() => Unfold<TFoldedQuery>();

        IValueGremlinQuery<TElement> IArrayGremlinQueryBase<TElement, TScalar>.Lower() => this;

        IValueGremlinQuery<object> IArrayGremlinQueryBase.Unfold() => Unfold<IValueGremlinQuery<object>>();

        IValueTupleGremlinQuery<TElement> IGremlinQueryBase<TElement>.ForceValueTuple() => this;

        IArrayGremlinQuery<TElement[], TElement, IGremlinQueryBase<TElement>> IGremlinQueryBase<TElement>.ForceArray() => ChangeQueryType<IArrayGremlinQuery<TElement[], TElement, IGremlinQueryBase<TElement>>>();

        IValueGremlinQuery<TScalar[]> IArrayGremlinQueryBase<TScalar>.Lower() => Cast<TScalar[]>();

        IValueGremlinQuery<object[]> IArrayGremlinQueryBase.Lower() => Cast<object[]>();

        IValueGremlinQuery<TElement> IArrayGremlinQueryBase<TElement, TScalar, TFoldedQuery>.Lower() => this;

        TFoldedQuery IArrayGremlinQueryBase<TElement, TScalar, TFoldedQuery>.SumLocal() => SumLocal().ChangeQueryType<TFoldedQuery>();

        TFoldedQuery IArrayGremlinQueryBase<TElement, TScalar, TFoldedQuery>.MinLocal() => MinLocal().ChangeQueryType<TFoldedQuery>();

        TFoldedQuery IArrayGremlinQueryBase<TElement, TScalar, TFoldedQuery>.MaxLocal() => MaxLocal().ChangeQueryType<TFoldedQuery>();

        IValueGremlinQuery<TElement> IValueGremlinQueryBase<TElement>.Sum() => SumGlobal();

        IValueGremlinQuery<object> IValueGremlinQueryBase<TElement>.SumLocal() => SumLocal();

        IValueGremlinQuery<TElement> IValueGremlinQueryBase<TElement>.Min() => MinGlobal();

        IValueGremlinQuery<object> IValueGremlinQueryBase<TElement>.MinLocal() => MinLocal();

        IValueGremlinQuery<TElement> IValueGremlinQueryBase<TElement>.Max() => MaxGlobal();

        IValueGremlinQuery<object> IValueGremlinQueryBase<TElement>.MaxLocal() => MaxLocal();

        IValueGremlinQuery<TElement> IValueGremlinQueryBase<TElement>.Mean() => MeanGlobal();

        IValueGremlinQuery<object> IValueGremlinQueryBase<TElement>.MeanLocal() => MeanLocal();

        IArrayGremlinQuery<TElement, TScalar, TFoldedQuery> IGremlinQueryBaseRec<IArrayGremlinQuery<TElement, TScalar, TFoldedQuery>>.Mute() => Mute();

        IBothEdgeGremlinQuery<TElement, TNewOutVertex, TInVertex> IInEdgeGremlinQueryBase<TElement, TInVertex>.From<TNewOutVertex>(Func<IVertexGremlinQuery<TInVertex>, IVertexGremlinQueryBase<TNewOutVertex>> fromVertexTraversal) => AddStep<TElement, TNewOutVertex, TInVertex, object, object, object>(new AddEStep.FromTraversalStep(Cast<TInVertex>().Continue(fromVertexTraversal).ToTraversal()), QuerySemantics.Edge);

        IVertexGremlinQuery<TInVertex> IInEdgeGremlinQueryBase<TElement, TInVertex>.InV() => InV<TInVertex>();

        IEdgeOrVertexGremlinQuery<TElement> IBothEdgeGremlinQueryBase<TElement, TOutVertex, TInVertex>.Lower() => this;

        IEdgeGremlinQuery<TElement> IInEdgeGremlinQueryBase<TElement, TInVertex>.Lower() => this;

        IEdgeGremlinQuery<TElement> IOutEdgeGremlinQueryBase<TElement, TOutVertex>.Lower() => this;

        IVertexGremlinQuery<TOutVertex> IOutEdgeGremlinQueryBase<TElement, TOutVertex>.OutV() => AddStepWithObjectTypes<TOutVertex>(OutVStep.Instance, QuerySemantics.Vertex);

        IBothEdgeGremlinQuery<TElement, TOutVertex, TNewInVertex> IOutEdgeGremlinQueryBase<TElement, TOutVertex>.To<TNewInVertex>(Func<IVertexGremlinQuery<TOutVertex>, IVertexGremlinQueryBase<TNewInVertex>> toVertexTraversal) => AddStep<TElement, TOutVertex, TNewInVertex, object, object, object>(new AddEStep.ToTraversalStep(Cast<TOutVertex>().Continue(toVertexTraversal).ToTraversal()), QuerySemantics.Edge);

        IEdgeOrVertexGremlinQuery<object> IBothEdgeGremlinQueryBase.Lower() => Cast<object>();

        IEdgeGremlinQuery<object> IInEdgeGremlinQueryBase.Lower() => Cast<object>();

        IEdgeGremlinQuery<object> IOutEdgeGremlinQueryBase.Lower() => Cast<object>();

        IBothEdgeGremlinQuery<TElement, TOutVertex, TInVertex> IGremlinQueryBaseRec<IBothEdgeGremlinQuery<TElement, TOutVertex, TInVertex>>.Mute() => Mute();

        IVertexGremlinQuery<object> IEdgeGremlinQueryBase.BothV() => BothV<object>();

        IVertexGremlinQuery<TVertex> IEdgeGremlinQueryBase.BothV<TVertex>() => BothV<object>().OfType<TVertex>(Environment.Model.VerticesModel);

        IOutEdgeGremlinQuery<TElement, TNewOutVertex> IEdgeGremlinQueryBase<TElement>.From<TNewOutVertex>(StepLabel<TNewOutVertex> stepLabel) => AddStep<TElement, TNewOutVertex, object, object, object, object>(new AddEStep.FromLabelStep(stepLabel), QuerySemantics.Edge);

        IEdgeOrVertexGremlinQuery<TElement> IEdgeGremlinQueryBase<TElement>.Lower() => this;

        IOutEdgeGremlinQuery<TElement, TNewOutVertex> IEdgeGremlinQueryBase<TElement>.From<TNewOutVertex>(Func<IVertexGremlinQueryBase, IVertexGremlinQueryBase<TNewOutVertex>> fromVertexTraversal) => AddStep<TElement, TNewOutVertex, object, object, object, object>(new AddEStep.FromTraversalStep(Continue(fromVertexTraversal).ToTraversal()), QuerySemantics.Edge);

        IVertexGremlinQuery<object> IEdgeGremlinQueryBase.InV() => InV<object>();

        IVertexGremlinQuery<TVertex> IEdgeGremlinQueryBase.InV<TVertex>() => InV<object>().OfType<TVertex>(Environment.Model.VerticesModel);

        IEdgeOrVertexGremlinQuery<object> IEdgeGremlinQueryBase.Lower() => Cast<object>();

        IVertexGremlinQuery<object> IEdgeGremlinQueryBase.OtherV() => OtherV<object>();

        IVertexGremlinQuery<TVertex> IEdgeGremlinQueryBase.OtherV<TVertex>() => OtherV<object>().OfType<TVertex>(Environment.Model.VerticesModel);

        IVertexGremlinQuery<object> IEdgeGremlinQueryBase.OutV() => OutV<object>();

        IVertexGremlinQuery<TVertex> IEdgeGremlinQueryBase.OutV<TVertex>() => OutV<object>().OfType<TVertex>(Environment.Model.VerticesModel);

        IPropertyGremlinQuery<Property<TValue>> IEdgeGremlinQueryBase<TElement>.Properties<TValue>(params Expression<Func<TElement, TValue>>[] projections) => Properties<Property<TValue>, TValue, object>(QuerySemantics.Property, projections);

        IPropertyGremlinQuery<Property<TValue>> IEdgeGremlinQueryBase<TElement>.Properties<TValue>(params Expression<Func<TElement, Property<TValue>>>[] projections) => Properties<Property<TValue>, TValue, object>(QuerySemantics.Property, projections);

        IPropertyGremlinQuery<Property<object>> IEdgeGremlinQueryBase<TElement>.Properties(params Expression<Func<TElement, Property<object>>>[] projections) => Properties<Property<object>, object, object>(QuerySemantics.Property, projections);

        IPropertyGremlinQuery<Property<object>> IEdgeGremlinQueryBase.Properties() => Properties<Property<object>, object, object>(Array.Empty<string>(), QuerySemantics.Property);

        IPropertyGremlinQuery<Property<TValue>> IEdgeGremlinQueryBase.Properties<TValue>() => Properties<Property<TValue>, object, object>(Array.Empty<string>(), QuerySemantics.Property);

        IInEdgeGremlinQuery<TElement, TNewInVertex> IEdgeGremlinQueryBase<TElement>.To<TNewInVertex>(StepLabel<TNewInVertex> stepLabel) => To<TElement, object, TNewInVertex>(stepLabel);

        IInEdgeGremlinQuery<TElement, TNewInVertex> IEdgeGremlinQueryBase<TElement>.To<TNewInVertex>(Func<IVertexGremlinQueryBase, IVertexGremlinQueryBase<TNewInVertex>> toVertexTraversal) => AddStep<TElement, object, TNewInVertex, object, object, object>(new AddEStep.ToTraversalStep(Continue(toVertexTraversal).ToTraversal()), QuerySemantics.Edge);

        IValueGremlinQuery<TValue> IEdgeGremlinQueryBase<TElement>.Values<TValue>(params Expression<Func<TElement, Property<TValue>>>[] projections) => ValuesForProjections<TValue>(projections);

        IValueGremlinQuery<object> IEdgeGremlinQueryBase<TElement>.Values(params Expression<Func<TElement, Property<object>>>[] projections) => ValuesForProjections<object>(projections);

        IEdgeGremlinQuery<TElement> IEdgeGremlinQueryBase<TElement>.Update(TElement element) => AddOrUpdate(element, false, false, Environment.FeatureSet.Supports(EdgeFeatures.UserSuppliedIds));

        IValueGremlinQuery<TTarget> IEdgeGremlinQueryBase<TElement>.Values<TTarget>(params Expression<Func<TElement, TTarget>>[] projections) => ValuesForProjections<TTarget>(projections);

        IEdgeGremlinQuery<TElement> IGremlinQueryBaseRec<IEdgeGremlinQuery<TElement>>.Mute() => Mute();

        IElementGremlinQuery<TElement> IEdgeOrVertexGremlinQueryBase<TElement>.Lower() => this;

        IElementGremlinQuery<object> IEdgeOrVertexGremlinQueryBase.Lower() => Cast<object>();

        IEdgeOrVertexGremlinQuery<TElement> IGremlinQueryBaseRec<IEdgeOrVertexGremlinQuery<TElement>>.Mute() => Mute();

        IValueGremlinQuery<object> IElementGremlinQueryBase.Id() => Id();

        IValueGremlinQuery<string> IElementGremlinQueryBase.Label() => Label();

        IValueGremlinQuery<IDictionary<string, TTarget>> IElementGremlinQueryBase.ValueMap<TTarget>() => ValueMap<IDictionary<string, TTarget>>(ImmutableArray<string>.Empty);

        IValueGremlinQuery<IDictionary<string, object>> IElementGremlinQueryBase.ValueMap() => ValueMap<IDictionary<string, object>>(ImmutableArray<string>.Empty);

        IValueGremlinQuery<TValue> IElementGremlinQueryBase.Values<TValue>() => ValuesForKeys<TValue>(Array.Empty<Key>());

        IValueGremlinQuery<object> IElementGremlinQueryBase.Values() => ValuesForKeys<object>(Array.Empty<Key>());

        IElementGremlinQuery<TElement> IElementGremlinQueryBase<TElement>.Update(TElement element) => AddOrUpdate(element, false, false, Environment.FeatureSet.Supports(EdgeFeatures.UserSuppliedIds) && Environment.FeatureSet.Supports(VertexFeatures.UserSuppliedIds));

        IValueGremlinQuery<TTarget> IElementGremlinQueryBase<TElement>.Values<TTarget>(params Expression<Func<TElement, TTarget>>[] projections) => ValuesForProjections<TTarget>(projections);

        IValueGremlinQuery<TTarget> IElementGremlinQueryBase<TElement>.Values<TTarget>(params Expression<Func<TElement, TTarget[]>>[] projections) => ValuesForProjections<TTarget>(projections);

        IValueGremlinQuery<IDictionary<string, TTarget>> IElementGremlinQueryBase<TElement>.ValueMap<TTarget>(params Expression<Func<TElement, TTarget>>[] keys) => ValueMap<IDictionary<string, TTarget>>(keys);

        IElementGremlinQuery<TElement> IGremlinQueryBaseRec<IElementGremlinQuery<TElement>>.Mute() => Mute();

        IGremlinQueryAdmin IGremlinQueryBase.AsAdmin() => this;

        IValueGremlinQuery<TValue> IGremlinQueryBase.Constant<TValue>(TValue constant) => AddStepWithObjectTypes<TValue>(new ConstantStep(constant!), QuerySemantics.None);

        string IGremlinQueryBase.Debug(GroovyFormatting groovyFormatting, Formatting jsonFormatting)
        {
            return JsonConvert.SerializeObject(
                Environment.Serializer
                    .ToGroovy(groovyFormatting)
                    .Serialize(this),
                jsonFormatting);
        }

        IValueGremlinQuery<long> IGremlinQueryBase.Count() => AddStepWithObjectTypes<long>(CountStep.Global, QuerySemantics.None);

        IValueGremlinQuery<long> IGremlinQueryBase.CountLocal() => AddStepWithObjectTypes<long>(CountStep.Local, QuerySemantics.None);

        IValueGremlinQuery<string> IGremlinQueryBase.Explain() => AddStepWithObjectTypes<string>(ExplainStep.Instance, QuerySemantics.None);

        TaskAwaiter IGremlinQueryBase.GetAwaiter() => ((Task)((IGremlinQuery<TElement>)this).ToAsyncEnumerable().LastOrDefaultAsync().AsTask()).GetAwaiter();

        IElementGremlinQuery<TElement> IGremlinQueryBase<TElement>.ForceElement() => this;

        IVertexGremlinQuery<TElement> IGremlinQueryBase<TElement>.ForceVertex() => this;

        IVertexPropertyGremlinQuery<TElement, TNewValue> IGremlinQueryBase<TElement>.ForceVertexProperty<TNewValue>() => ChangeQueryType<IVertexPropertyGremlinQuery<TElement, TNewValue>>();

        IVertexPropertyGremlinQuery<TElement, TNewValue, TNewMeta> IGremlinQueryBase<TElement>.ForceVertexProperty<TNewValue, TNewMeta>() where TNewMeta : class => ChangeQueryType<IVertexPropertyGremlinQuery<TElement, TNewValue, TNewMeta>>();

        IPropertyGremlinQuery<TElement> IGremlinQueryBase<TElement>.ForceProperty() => this;

        IEdgeGremlinQuery<TElement> IGremlinQueryBase<TElement>.ForceEdge() => this;

        IInEdgeGremlinQuery<TElement, TNewInVertex> IGremlinQueryBase<TElement>.ForceInEdge<TNewInVertex>() => ChangeQueryType<IInEdgeGremlinQuery<TElement, TNewInVertex>>();

        IOutEdgeGremlinQuery<TElement, TNewOutVertex> IGremlinQueryBase<TElement>.ForceOutEdge<TNewOutVertex>() => ChangeQueryType<IOutEdgeGremlinQuery<TElement, TNewOutVertex>>();

        IBothEdgeGremlinQuery<TElement, TNewOutVertex, TNewInVertex> IGremlinQueryBase<TElement>.ForceBothEdge<TNewOutVertex, TNewInVertex>() => ChangeQueryType<IBothEdgeGremlinQuery<TElement, TNewOutVertex, TNewInVertex>>();

        IValueGremlinQuery<TElement> IGremlinQueryBase<TElement>.ForceValue() => this;

        GremlinQueryAwaiter<TElement> IGremlinQueryBase<TElement>.GetAwaiter() => new GremlinQueryAwaiter<TElement>((this).ToArrayAsync().AsTask().GetAwaiter());

        IAsyncEnumerable<TElement> IGremlinQueryBase<TElement>.ToAsyncEnumerable()
        {
            var serialized = Environment.Serializer
                .Serialize(this);

            return Environment.Executor
                .Execute(serialized, Environment)
                .SelectMany(executionResult => Environment.Deserializer
                    .Deserialize<TElement>(executionResult, Environment));
        }

        IValueGremlinQuery<string> IGremlinQueryBase.Profile() => AddStepWithObjectTypes<string>(ProfileStep.Instance, QuerySemantics.None);

        TQuery IGremlinQueryBase.Select<TQuery, TStepElement>(StepLabel<TQuery, TStepElement> label) => Select(label).ChangeQueryType<TQuery>();

        IArrayGremlinQuery<TNewElement, TNewScalar, TQuery> IGremlinQueryBase.Cap<TNewElement, TNewScalar, TQuery>(StepLabel<IArrayGremlinQuery<TNewElement, TNewScalar, TQuery>, TNewElement> label) => Cap(label);

        IValueGremlinQuery<TLabelledElement> IGremlinQueryBase.Select<TLabelledElement>(StepLabel<TLabelledElement> label) => Select(label);

        IGremlinQuery<TElement> IGremlinQueryBase<TElement>.Lower() => this;

        IGremlinQuery<object> IGremlinQueryBase.Lower() => Cast<object>();

        IValueGremlinQuery<object> IGremlinQueryBase.Drop() => Drop();

        IGremlinQuery<TElement> IGremlinQueryBaseRec<IGremlinQuery<TElement>>.Mute() => Mute();

        TTargetQuery IGremlinQueryAdmin.ConfigureSteps<TTargetQuery>(Func<IImmutableStack<Step>, IImmutableStack<Step>> transformation) => ConfigureSteps<TElement>(transformation).ChangeQueryType<TTargetQuery>(false);

        TTargetQuery IGremlinQueryAdmin.AddStep<TTargetQuery>(Step step) => AddStep(step).ChangeQueryType<TTargetQuery>();

        TTargetQuery IGremlinQueryAdmin.ChangeQueryType<TTargetQuery>() => ChangeQueryType<TTargetQuery>();

        IImmutableStack<Step> IGremlinQueryAdmin.Steps => Steps;

        IGremlinQueryEnvironment IGremlinQueryAdmin.Environment => Environment;

        Traversal IGremlinQueryAdmin.ToTraversal() => ToTraversalImpl().ToImmutableArray();

        Type IGremlinQueryAdmin.ElementType { get => typeof(TElement); }

        IEdgeGremlinQuery<TEdge> IStartGremlinQuery.AddE<TEdge>(TEdge edge) => AddE(edge);

        IValueGremlinQuery<TScalar> IArrayGremlinQueryBase<TScalar>.Unfold() => Unfold<IValueGremlinQuery<TScalar>>();

        IVertexGremlinQuery<TVertex> IStartGremlinQuery.AddV<TVertex>(TVertex vertex) => AddV(vertex);

        IValueGremlinQuery<TNewElement> IStartGremlinQuery.Inject<TNewElement>(params TNewElement[] elements) => Inject(elements);

        IVertexGremlinQuery<object> IStartGremlinQuery.V(params object[] ids) => AddStepWithObjectTypes<object>(new VStep(ids.ToImmutableArray()), QuerySemantics.Vertex);

        IVertexGremlinQuery<TNewVertex> IStartGremlinQuery.ReplaceV<TNewVertex>(TNewVertex vertex) => ((IStartGremlinQuery)this).V<TNewVertex>(vertex!.GetId(Environment)).Update(vertex);

        IEdgeGremlinQuery<TEdge> IStartGremlinQuery.AddE<TEdge>() => AddE(new TEdge());

        IVertexGremlinQuery<TVertex> IStartGremlinQuery.AddV<TVertex>() => AddV(new TVertex());

        IVertexGremlinQuery<TVertex> IStartGremlinQuery.V<TVertex>(params object[] ids) => ((IStartGremlinQuery)this).V(ids).OfType<TVertex>();

        IGremlinQueryEnvironment IGremlinQuerySource.Environment => Environment;

        IEdgeGremlinQuery<object> IGremlinQuerySource.E(params object[] ids) => AddStepWithObjectTypes<object>(new EStep(ids.ToImmutableArray()), QuerySemantics.Edge);

        IEdgeGremlinQuery<TEdge> IGremlinQuerySource.E<TEdge>(params object[] ids) => ((IGremlinQuerySource)this).E(ids).OfType<TEdge>();

        IEdgeGremlinQuery<TNewEdge> IGremlinQuerySource.ReplaceE<TNewEdge>(TNewEdge edge) => ((IGremlinQuerySource)this).E<TNewEdge>(edge!.GetId(Environment)).Update(edge);

        IGremlinQuerySource IConfigurableGremlinQuerySource.ConfigureEnvironment(Func<IGremlinQueryEnvironment, IGremlinQueryEnvironment> transformation) => ConfigureEnvironment(transformation);

        IGremlinQuerySource IGremlinQuerySource.WithoutStrategies(params Type[] strategyTypes) => AddStep(new WithoutStrategiesStep(strategyTypes.ToImmutableArray()));

        IInEdgeGremlinQuery<TElement, TInVertex> IGremlinQueryBaseRec<IInEdgeGremlinQuery<TElement, TInVertex>>.Mute() => Mute();

        IBothEdgeGremlinQuery<TElement, TTargetVertex, TOutVertex> IInOrOutEdgeGremlinQueryBase<TElement, TOutVertex>.From<TTargetVertex>(StepLabel<TTargetVertex> stepLabel) => AddStep<TElement, TTargetVertex, TOutVertex, object, object, object>(new AddEStep.FromLabelStep(stepLabel), QuerySemantics.Edge);

        IBothEdgeGremlinQuery<TElement, TTargetVertex, TOutVertex> IInOrOutEdgeGremlinQueryBase<TElement, TOutVertex>.From<TTargetVertex>(Func<IVertexGremlinQuery<TOutVertex>, IVertexGremlinQueryBase<TTargetVertex>> fromVertexTraversal) => AddStep<TElement, TTargetVertex, TOutVertex, object, object, object>(new AddEStep.FromTraversalStep(Cast<TOutVertex>().Continue(fromVertexTraversal).ToTraversal()), QuerySemantics.Edge);

        IBothEdgeGremlinQuery<TElement, TOutVertex, TTargetVertex> IInOrOutEdgeGremlinQueryBase<TElement, TOutVertex>.To<TTargetVertex>(StepLabel<TTargetVertex> stepLabel) => To<TElement, TOutVertex, TTargetVertex>(stepLabel);

        IBothEdgeGremlinQuery<TElement, TOutVertex, TTargetVertex> IInOrOutEdgeGremlinQueryBase<TElement, TOutVertex>.To<TTargetVertex>(Func<IVertexGremlinQuery<TOutVertex>, IVertexGremlinQueryBase<TTargetVertex>> toVertexTraversal) => AddStep<TElement, TOutVertex, TTargetVertex, object, object, object>(new AddEStep.ToTraversalStep(Cast<TOutVertex>().Continue(toVertexTraversal).ToTraversal()), QuerySemantics.Edge);

        IInOrOutEdgeGremlinQuery<TElement, TOutVertex> IGremlinQueryBaseRec<IInOrOutEdgeGremlinQuery<TElement, TOutVertex>>.Mute() => Mute();

        IOutEdgeGremlinQuery<TElement, TOutVertex> IGremlinQueryBaseRec<IOutEdgeGremlinQuery<TElement, TOutVertex>>.Mute() => Mute();

        IValueGremlinQuery<string> IPropertyGremlinQueryBase<TElement>.Key() => Key();

        IValueGremlinQuery<TValue> IPropertyGremlinQueryBase<TElement>.Value<TValue>() => Value<TValue>();

        IValueGremlinQuery<object> IPropertyGremlinQueryBase<TElement>.Value() => Value<object>();

        IPropertyGremlinQuery<TElement> IGremlinQueryBaseRec<IPropertyGremlinQuery<TElement>>.Mute() => Mute();

        IValueGremlinQuery<TElement> IGremlinQueryBaseRec<IValueGremlinQuery<TElement>>.Mute() => Mute();

        IEdgeOrVertexGremlinQuery<TElement> IVertexGremlinQueryBase<TElement>.Lower() => this;

        IEdgeOrVertexGremlinQuery<object> IVertexGremlinQueryBase.Lower() => Cast<object>();

        IInOrOutEdgeGremlinQuery<TEdge, TElement> IVertexGremlinQueryBase<TElement>.AddE<TEdge>(TEdge edge) => AddE(edge);

        IInOrOutEdgeGremlinQuery<TEdge, TElement> IVertexGremlinQueryBase<TElement>.AddE<TEdge>() => AddE(new TEdge());

        IVertexGremlinQuery<object> IVertexGremlinQueryBase.Both() => AddStepWithObjectTypes<object>(BothStep.NoLabels, QuerySemantics.Vertex);

        IVertexGremlinQuery<object> IVertexGremlinQueryBase.Both<TEdge>() => AddStepWithObjectTypes<object>(new BothStep(Environment.Model.EdgesModel.GetFilterLabelsOrDefault(typeof(TEdge), Environment.Options.GetValue(GremlinqOption.FilterLabelsVerbosity))), QuerySemantics.Vertex);

        IEdgeGremlinQuery<object> IVertexGremlinQueryBase.BothE() => AddStepWithObjectTypes<object>(BothEStep.NoLabels, QuerySemantics.Edge);

        IEdgeGremlinQuery<TEdge> IVertexGremlinQueryBase.BothE<TEdge>() => AddStepWithObjectTypes<TEdge>(new BothEStep(Environment.Model.EdgesModel.GetFilterLabelsOrDefault(typeof(TEdge), Environment.Options.GetValue(GremlinqOption.FilterLabelsVerbosity))), QuerySemantics.Edge);

        IVertexGremlinQuery<object> IVertexGremlinQueryBase.In() => AddStepWithObjectTypes<object>(InStep.Empty, QuerySemantics.Vertex);

        IVertexGremlinQuery<object> IVertexGremlinQueryBase.In<TEdge>() => AddStepWithObjectTypes<object>(new InStep(Environment.Model.EdgesModel.GetFilterLabelsOrDefault(typeof(TEdge), Environment.Options.GetValue(GremlinqOption.FilterLabelsVerbosity))), QuerySemantics.Vertex);

        IEdgeGremlinQuery<object> IVertexGremlinQueryBase.InE() => AddStepWithObjectTypes<object>(InEStep.Empty, QuerySemantics.Edge);

        IEdgeGremlinQuery<TEdge> IVertexGremlinQueryBase.InE<TEdge>() => AddStepWithObjectTypes<TEdge>(new InEStep(Environment.Model.EdgesModel.GetFilterLabelsOrDefault(typeof(TEdge), Environment.Options.GetValue(GremlinqOption.FilterLabelsVerbosity))), QuerySemantics.Edge);

        IInEdgeGremlinQuery<TEdge, TElement> IVertexGremlinQueryBase<TElement>.InE<TEdge>() => AddStep<TEdge, object, TElement, object, object, object>(new InEStep(Environment.Model.EdgesModel.GetFilterLabelsOrDefault(typeof(TEdge), Environment.Options.GetValue(GremlinqOption.FilterLabelsVerbosity))), QuerySemantics.Edge);

        IVertexGremlinQuery<object> IVertexGremlinQueryBase.Out() => AddStepWithObjectTypes<object>(OutStep.Empty, QuerySemantics.Vertex);

        IVertexGremlinQuery<object> IVertexGremlinQueryBase.Out<TEdge>() => AddStepWithObjectTypes<object>(new OutStep(Environment.Model.EdgesModel.GetFilterLabelsOrDefault(typeof(TEdge), Environment.Options.GetValue(GremlinqOption.FilterLabelsVerbosity))), QuerySemantics.Vertex);

        IEdgeGremlinQuery<TEdge> IVertexGremlinQueryBase.OutE<TEdge>() => AddStepWithObjectTypes<TEdge>(new OutEStep(Environment.Model.EdgesModel.GetFilterLabelsOrDefault(typeof(TEdge), Environment.Options.GetValue(GremlinqOption.FilterLabelsVerbosity))), QuerySemantics.Edge);

        IEdgeGremlinQuery<object> IVertexGremlinQueryBase.OutE() => AddStepWithObjectTypes<object>(OutEStep.Empty, QuerySemantics.Edge);

        IOutEdgeGremlinQuery<TEdge, TElement> IVertexGremlinQueryBase<TElement>.OutE<TEdge>() => AddStep<TEdge, TElement, object, object, object, object>(new OutEStep(Environment.Model.EdgesModel.GetFilterLabelsOrDefault(typeof(TEdge), Environment.Options.GetValue(GremlinqOption.FilterLabelsVerbosity))), QuerySemantics.Edge);

        IVertexPropertyGremlinQuery<VertexProperty<object>, object> IVertexGremlinQueryBase<TElement>.Properties() => Properties<VertexProperty<object>, object, object>(Array.Empty<string>(), QuerySemantics.VertexProperty);

        IVertexPropertyGremlinQuery<VertexProperty<TValue>, TValue> IVertexGremlinQueryBase<TElement>.Properties<TValue>(params Expression<Func<TElement, TValue>>[] projections) => VertexProperties<TValue>(projections);

        IVertexPropertyGremlinQuery<VertexProperty<TValue>, TValue> IVertexGremlinQueryBase<TElement>.Properties<TValue>(params Expression<Func<TElement, TValue[]>>[] projections) => VertexProperties<TValue>(projections);

        IVertexPropertyGremlinQuery<VertexProperty<TValue>, TValue> IVertexGremlinQueryBase<TElement>.Properties<TValue>(params Expression<Func<TElement, VertexProperty<TValue>>>[] projections) => VertexProperties<TValue>(projections);

        IVertexPropertyGremlinQuery<VertexProperty<TValue, TNewMeta>, TValue, TNewMeta> IVertexGremlinQueryBase<TElement>.Properties<TValue, TNewMeta>(params Expression<Func<TElement, VertexProperty<TValue, TNewMeta>>>[] projections) => Properties<VertexProperty<TValue, TNewMeta>, TValue, TNewMeta>(QuerySemantics.VertexProperty, projections);

        IVertexPropertyGremlinQuery<VertexProperty<TValue>, TValue> IVertexGremlinQueryBase<TElement>.Properties<TValue>(params Expression<Func<TElement, VertexProperty<TValue>[]>>[] projections) => VertexProperties<TValue>(projections);

        IVertexPropertyGremlinQuery<VertexProperty<TValue, TNewMeta>, TValue, TNewMeta> IVertexGremlinQueryBase<TElement>.Properties<TValue, TNewMeta>(params Expression<Func<TElement, VertexProperty<TValue, TNewMeta>[]>>[] projections) => Properties<VertexProperty<TValue, TNewMeta>, TValue, TNewMeta>(QuerySemantics.VertexProperty, projections);

        IVertexPropertyGremlinQuery<VertexProperty<TValue>, TValue> IVertexGremlinQueryBase<TElement>.Properties<TValue>() => Properties<VertexProperty<TValue>, TValue, object>(Array.Empty<string>(), QuerySemantics.VertexProperty);

        IVertexPropertyGremlinQuery<VertexProperty<object>, object> IVertexGremlinQueryBase<TElement>.Properties(params Expression<Func<TElement, VertexProperty<object>>>[] projections) => VertexProperties<object>(projections);

        IValueGremlinQuery<TValue> IVertexGremlinQueryBase<TElement>.Values<TValue, TNewMeta>(params Expression<Func<TElement, VertexProperty<TValue, TNewMeta>>>[] projections) where TNewMeta : class => ValuesForProjections<TValue>(projections);

        IValueGremlinQuery<TValue> IVertexGremlinQueryBase<TElement>.Values<TValue>(params Expression<Func<TElement, VertexProperty<TValue>>>[] projections) => ValuesForProjections<TValue>(projections);

        IValueGremlinQuery<TTarget> IVertexGremlinQueryBase<TElement>.Values<TTarget>(params Expression<Func<TElement, VertexProperty<TTarget>[]>>[] projections) => ValuesForProjections<TTarget>(projections);

        IValueGremlinQuery<TTarget> IVertexGremlinQueryBase<TElement>.Values<TTarget, TTargetMeta>(params Expression<Func<TElement, VertexProperty<TTarget, TTargetMeta>[]>>[] projections) where TTargetMeta : class => ValuesForProjections<TTarget>(projections);

        IValueGremlinQuery<object> IVertexGremlinQueryBase<TElement>.Values(params Expression<Func<TElement, VertexProperty<object>>>[] projections) => ValuesForProjections<object>(projections);

        IVertexGremlinQuery<TElement> IVertexGremlinQueryBase<TElement>.Update(TElement element) => AddOrUpdate(element, false, true, Environment.FeatureSet.Supports(VertexFeatures.UserSuppliedIds));

        IVertexGremlinQuery<TElement> IVertexGremlinQuery<TElement>.Property<TProjectedValue>(Expression<Func<TElement, TProjectedValue[]>> projection, TProjectedValue value) => VertexProperty(projection, value != null ? new[] { value } : null);

        IValueGremlinQuery<TTarget> IVertexGremlinQueryBase<TElement>.Values<TTarget>(params Expression<Func<TElement, TTarget>>[] projections) => ValuesForProjections<TTarget>(projections);

        IValueGremlinQuery<TTarget> IVertexGremlinQueryBase<TElement>.Values<TTarget>(params Expression<Func<TElement, TTarget[]>>[] projections) => ValuesForProjections<TTarget>(projections);

        IVertexGremlinQuery<TElement> IGremlinQueryBaseRec<IVertexGremlinQuery<TElement>>.Mute() => Mute();

        IElementGremlinQuery<TElement> IVertexPropertyGremlinQueryBase<TElement, TScalar, TMeta>.Lower() => this;

        IPropertyGremlinQuery<Property<TValue>> IVertexPropertyGremlinQueryBase<TElement, TScalar, TMeta>.Properties<TValue>(params Expression<Func<TMeta, TValue>>[] projections) => Properties<Property<TValue>, TValue, object>(QuerySemantics.Property, projections);

        IVertexPropertyGremlinQuery<TElement, TScalar, TMeta> IVertexPropertyGremlinQueryBase<TElement, TScalar, TMeta>.Property<TValue>(Expression<Func<TMeta, TValue>> projection, TValue value) => Property(projection, value);

        IValueGremlinQuery<TScalar> IVertexPropertyGremlinQueryBase<TElement, TScalar, TMeta>.Value() => Value<TScalar>();

        IValueGremlinQuery<TMeta> IVertexPropertyGremlinQueryBase<TElement, TScalar, TMeta>.ValueMap() => ValueMap<TMeta>(ImmutableArray<string>.Empty);

        IValueGremlinQuery<TTarget> IVertexPropertyGremlinQueryBase<TElement, TScalar, TMeta>.Values<TTarget>(params Expression<Func<TMeta, TTarget>>[] projections) => ValuesForProjections<TTarget>(projections);

        IVertexPropertyGremlinQuery<TElement, TScalar, TMeta> IVertexPropertyGremlinQueryBase<TElement, TScalar, TMeta>.Where(Expression<Func<VertexProperty<TScalar, TMeta>, bool>> predicate) => Where(predicate);

        IVertexPropertyGremlinQuery<TElement, TScalar, TMeta> IGremlinQueryBaseRec<IVertexPropertyGremlinQuery<TElement, TScalar, TMeta>>.Mute() => Mute();

        IElementGremlinQuery<TElement> IVertexPropertyGremlinQueryBase<TElement, TScalar>.Lower() => this;

        IElementGremlinQuery<object> IVertexPropertyGremlinQueryBase.Lower() => Cast<object>();

        IValueGremlinQuery<IDictionary<string, TTarget>> IVertexPropertyGremlinQueryBase.ValueMap<TTarget>() => ValueMap<IDictionary<string, TTarget>>(ImmutableArray<string>.Empty);

        IValueGremlinQuery<IDictionary<string, TTarget>> IVertexPropertyGremlinQueryBase.ValueMap<TTarget>(params string[] keys) => ValueMap<IDictionary<string, TTarget>>(keys.ToImmutableArray());

        IValueGremlinQuery<IDictionary<string, object>> IVertexPropertyGremlinQueryBase.ValueMap(params string[] keys) => ValueMap<IDictionary<string, object>>(keys.ToImmutableArray());

        IValueGremlinQuery<TValue> IVertexPropertyGremlinQueryBase.Values<TValue>() => ValuesForKeys<TValue>(Array.Empty<Key>());

        IValueGremlinQuery<TValue> IVertexPropertyGremlinQueryBase.Values<TValue>(params string[] keys) => ValuesForKeys<TValue>(keys.Select(x => (Key)x).ToArray());

        IValueGremlinQuery<object> IVertexPropertyGremlinQueryBase.Values(params string[] keys) => ValuesForKeys<object>(keys.Select(x => (Key)x).ToArray());

        IPropertyGremlinQuery<Property<object>> IVertexPropertyGremlinQueryBase.Properties(params string[] keys) => Properties<Property<object>, object, object>(keys, QuerySemantics.Property);

        IVertexPropertyGremlinQuery<VertexProperty<TScalar, TNewMeta>, TScalar, TNewMeta> IVertexPropertyGremlinQueryBase<TElement, TScalar>.Meta<TNewMeta>() where TNewMeta : class => Cast<VertexProperty<TScalar, TNewMeta>, object, object, TScalar, TNewMeta, object>();

        IPropertyGremlinQuery<Property<TValue>> IVertexPropertyGremlinQueryBase<TElement, TScalar>.Properties<TValue>(params string[] keys) => Properties<Property<TValue>, object, object>(keys, QuerySemantics.Property);

        IValueGremlinQuery<TScalar> IVertexPropertyGremlinQueryBase<TElement, TScalar>.Value() => Value<TScalar>();

        IVertexPropertyGremlinQuery<TElement, TScalar> IGremlinQueryBaseRec<IVertexPropertyGremlinQuery<TElement, TScalar>>.Mute() => Mute();

        private IEnumerable<Step> ToTraversalImpl()
        {
            var steps = Steps;

            if (steps.IsEmpty)
            {
                yield return IdentityStep.Instance;
            }
            else
            {
                var stepsArray = steps.ToArray();

                for (var i = stepsArray.Length - 1; i >= 0; i--)
                {
                    yield return stepsArray[i];
                }
            }

            if ((Flags & QueryFlags.SurfaceVisible) == QueryFlags.SurfaceVisible)
            {
                switch (Semantics)
                {
                    case QuerySemantics.Vertex:
                    {
                        var option = Environment.FeatureSet.Supports(VertexFeatures.MetaProperties)
                            ? GremlinqOption.VertexProjectionSteps
                            : GremlinqOption.VertexProjectionWithoutMetaPropertiesSteps;

                        foreach (var step in Environment.Options.GetValue(option))
                        {
                            yield return step;
                        }

                        break;
                    }
                    case QuerySemantics.Edge:
                    {
                        foreach (var step in Environment.Options.GetValue(GremlinqOption.EdgeProjectionSteps))
                        {
                            yield return step;
                        }

                        break;
                    }
                }
            }
        }

        IValueTupleGremlinQuery<TElement> IGremlinQueryBaseRec<IValueTupleGremlinQuery<TElement>>.Mute() => Mute();

        IValueGremlinQuery<TTargetValue> IValueTupleGremlinQueryBase<TElement>.Select<TTargetValue>(Expression<Func<TElement, TTargetValue>> projection) => Select<IValueGremlinQuery<TTargetValue>>(projection);
    }
}
