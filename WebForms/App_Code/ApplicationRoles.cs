﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForms.Models;

namespace WebForms.App_Code
{
    internal class ApplicationRoles
    {
        public void AddUserAndRole()
        {
            var roleName = "ADMIN";
            var userEmail = "admin2@cibertec.edu.pe";
            UserManager<ApplicationUser> userManager;
            using (var userContext = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new
               RoleStore<IdentityRole>(userContext));
                if (!roleManager.RoleExists(roleName))
                    roleManager.Create(new IdentityRole { Name = roleName });

                userManager = new UserManager<ApplicationUser>(new
               UserStore<ApplicationUser>(userContext));
                if (userManager.FindByEmail(userEmail) == null)
                {
                    var appUser = new ApplicationUser
                    {
                        UserName = userEmail,
                        Email = userEmail,
                    };
                    userManager.Create(appUser, "Welcome_123");
                }
                if (!userManager.IsInRole(userManager.FindByEmail(userEmail).Id,
               roleName))
                {
                    userManager.AddToRole(userManager.FindByEmail(userEmail).Id,
                   roleName);
                }
            }
        }
    }

}