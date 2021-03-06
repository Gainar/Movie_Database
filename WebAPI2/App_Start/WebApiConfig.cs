﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // config.Routes.MapHttpRoute(
            //     name: "Movie",
            //     routeTemplate: "api/{controller}/{tit}",
            //     defaults: new { tit = RouteParameter.Optional }
            // );

            // config.Routes.MapHttpRoute(
            //    name: "QuerrySearch",
            //    routeTemplate: "api/{controller}/{param}/{val}",
            //    defaults: new { param = RouteParameter.Optional, val = RouteParameter.Optional }
            //);
        }
    }
}
