﻿using System.Security.Claims;

namespace DVLD.Data.Helpers
{
    public static class ClaimsStore
    {
        public static List<Claim> claims = new()
        {
            new Claim("Create Student","false"),
            new Claim("Edit Student","false"),
            new Claim("Delete Student","false"),
        };
    }
}
