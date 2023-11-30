using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FPT_BOOKSTORE.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FPT_BOOKSTOREUser class
public class FPT_BOOKSTOREUser : IdentityUser
{
    [PersonalData]
    [AllowNull]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [AllowNull]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Role { get; set; }
}

