﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SennedjemTests.Helpers.TokenHelpers
{
    public static class MockJwtTokens
    {
        public static string Issuer { get; } = "www.kizilay.org.tr";
        public static string Audience { get; } = "www.kizilay.org.tr";
        public static SecurityKey SecurityKey { get; }
        public static SigningCredentials SigningCredentials { get; }

        private static readonly JwtSecurityTokenHandler s_tokenHandler = new JwtSecurityTokenHandler();
        private static string KeyString = "!z2x3C4v5B*_*!z2x3C4v5B*_*";

        static MockJwtTokens()
        {
            var s_key = Encoding.UTF8.GetBytes(KeyString);
            SecurityKey = new SymmetricSecurityKey(s_key);
            SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature);

        }

        public static string GenerateJwtToken(IEnumerable<Claim> claims)
        {
            return s_tokenHandler.WriteToken(new JwtSecurityToken(Issuer,Audience, claims, DateTime.UtcNow, DateTime.UtcNow.AddSeconds(5), SigningCredentials));
        }
    }
}
