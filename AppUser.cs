using System;


    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
