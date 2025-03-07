﻿using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithASP_NET5.Services
{
    public interface ITokenService
    {
        string GenerateAcessToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredTokens(string token);
    }
}
