using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PHE2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Account
            routes.MapRoute(
               name: "AccountGetAll",
               url: "API/account/",
               defaults: new { controller = "Account", action = "GetAll", id = UrlParameter.Optional }

            );

            routes.MapRoute(
                name: "AccountGetByGuid",
                url: "API/account/{guid}",
                defaults: new { controller = "Account", action = "GetByGuid", guid = UrlParameter.Optional }
            );

            //AccountRole
            routes.MapRoute(
               name: "AccountRoleGetAll",
               url: "API/accountrole/",
               defaults: new { controller = "AccountRole", action = "GetAll", id = UrlParameter.Optional }

            );
    
            routes.MapRoute(
                name: "AccountRoleGetByGuid",
                url: "API/accountrole/{guid}",
                defaults: new { controller = "AccountRole", action = "GetByGuid", guid = UrlParameter.Optional }
            );

            //Characteristic
            routes.MapRoute(
               name: "CharacteristicGetAll",
               url: "API/characteristic/",
               defaults: new { controller = "Characteristic", action = "GetAll", id = UrlParameter.Optional }

            );

            routes.MapRoute(
                name: "CharacteristicGetByGuid",
                url: "API/characteristic/{guid}",
                defaults: new { controller = "Characteristic", action = "GetByGuid", guid = UrlParameter.Optional }
            );

            //Project
            routes.MapRoute(
               name: "ProjectGetAll",
               url: "API/project/",
               defaults: new { controller = "Project", action = "GetAll", id = UrlParameter.Optional }

            );

            routes.MapRoute(
                name: "ProjectGetByGuid",
                url: "API/project/{guid}",
                defaults: new { controller = "Project", action = "GetByGuid", guid = UrlParameter.Optional }
            );

            //Role
            routes.MapRoute(
              name: "RoleGetAll",
              url: "API/Role/",
              defaults: new { controller = "Role", action = "GetAll", id = UrlParameter.Optional }

            );

            routes.MapRoute(
                name: "RoleGetByGuid",
                url: "API/Role/{guid}",
                defaults: new { controller = "Role", action = "GetByGuid", guid = UrlParameter.Optional }
            );

            //UserProject
            routes.MapRoute(
              name: "UserProjectGetAll",
              url: "API/UserProject/",
              defaults: new { controller = "UserProject", action = "GetAll", id = UrlParameter.Optional }

            );

            routes.MapRoute(
                name: "UserProjectGetByGuid",
                url: "API/UserProject/{guid}",
                defaults: new { controller = "UserProject", action = "GetByGuid", guid = UrlParameter.Optional }
            );

            //User
            routes.MapRoute(
                name: "UserGetAll",
                url:"API/user/",
                defaults: new {controller = "User", action = "GetAll", id = UrlParameter.Optional }

            );

            routes.MapRoute(
                name: "UserGetByGuid",
                url: "API/user/{guid}",
                defaults: new { controller = "User", action = "GetByGuid", guid = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "UserCreate",
                url: "API/user/{action}",
                defaults: new { controller = "User", action = "Create" }

            );

            //----------------------------------------------------------------------------
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
