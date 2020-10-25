using System;
using System.Collections.Generic;
using Paillave.Etl.Core;
using Paillave.Etl.Core.Streams;
using Paillave.Etl.StreamNodes;

namespace Paillave.Etl.Extensions
{
    public static class SelectWithContextBagEx
    {
        public static IStream<TOut> ResolveAndSelect<TIn, TService, TOut>(this IStream<TIn> stream, string name, Func<Resolver<TIn>, Selector<TIn, TService, TOut>> selection, bool withNoDispose = false)
        {
            return new ResolveAndSelectStreamNode<TIn, TService, TOut>(name, new ResolveAndSelectArgs<TIn, TService, TOut>
            {
                Stream = stream,
                Selection = selection,
                WithNoDispose = withNoDispose
            }).Output;
        }
        public static ISingleStream<TOut> ResolveAndSelect<TIn, TService, TOut>(this ISingleStream<TIn> stream, string name, Func<Resolver<TIn>, Selector<TIn, TService, TOut>> selection, bool withNoDispose = false)
        {
            return new ResolveAndSelectSingleStreamNode<TIn, TService, TOut>(name, new ResolveAndSelectSingleArgs<TIn, TService, TOut>
            {
                Stream = stream,
                Selection = selection,
                WithNoDispose = withNoDispose
            }).Output;
        }
        public static IStream<Correlated<TOut>> ResolveAndSelect<TIn, TService, TOut>(this IStream<Correlated<TIn>> stream, string name, Func<Resolver<TIn>, Selector<TIn, TService, TOut>> selection, bool withNoDispose = false)
        {
            return new ResolveAndSelectCorrelatedStreamNode<TIn, TService, TOut>(name, new ResolveAndSelectCorrelatedArgs<TIn, TService, TOut>
            {
                Stream = stream,
                Selection = selection,
                WithNoDispose = withNoDispose
            }).Output;
        }
        public static ISingleStream<Correlated<TOut>> ResolveAndSelect<TIn, TService, TOut>(this ISingleStream<Correlated<TIn>> stream, string name, Func<Resolver<TIn>, Selector<TIn, TService, TOut>> selection, bool withNoDispose = false)
        {
            return new ResolveAndSelectCorrelatedSingleStreamNode<TIn, TService, TOut>(name, new ResolveAndSelectCorrelatedSingleArgs<TIn, TService, TOut>
            {
                Stream = stream,
                Selection = selection,
                WithNoDispose = withNoDispose
            }).Output;
        }
    }
}