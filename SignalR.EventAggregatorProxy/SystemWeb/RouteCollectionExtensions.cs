﻿using System;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using SignalR.EventAggregatorProxy.Event;

namespace SignalR.EventAggregatorProxy.SystemWeb
{
    public static class RouteCollectionExtensions
    {
        public static void MapEventProxy<TEvent>(this RouteCollection routes)
        {
            var locator = new Lazy<ITypeFinder>(() => new TypeFinder<TEvent>());
            GlobalHost.DependencyResolver.Register(typeof(ITypeFinder), () => locator.Value);

            routes.Add(new Route(
                           "eventAggregation/events",
                           new EventScriptRouteHandler<TEvent>()
                           ));
        }
    }
}