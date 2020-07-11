using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TCGCollectionApp.Data
{
    // Add profile data for application users by adding properties to the User class
    //For now a dummy user extending built in Identity user
    public class User : IdentityUser
    {
    }
}
