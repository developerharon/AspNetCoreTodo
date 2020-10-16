using System.Collections.Generic;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Models
{
    public class ManageUsersViewModel
    {
        //Here i brought in the "Microsoft.AspNetCore.Identity;" namespace and changed ApplicationUser to IdentityUser.
        //This was where i had issue when i was following the little aspnet then too .. it really has been a while and i have forgoten what actually happend but i will try and find out and let you know... btw i am following my own solution hen to fix this.
        public IdentityUser[] Administrators { get; set; }

        public IdentityUser[] Everyone { get; set; }
    }
}