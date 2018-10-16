using Fitness.DataModels.Entities.Token;
using Fitness.DataModels.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Fitness.WebApi.Utilities.JWT
{
    public class JWTAuthHelper : IJWTAuthHelper<UserModel>
    {
        private JwtAuthOptionsModel _jwtOptions;

        public JWTAuthHelper(IOptions<JwtAuthOptionsModel> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string Create(HttpRequest request, UserModel member)
        {
            var claims = CreateClaims(request, member);
            var header = new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Key)), SecurityAlgorithms.HmacSha256));
            var payload = new JwtPayload(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims.Claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_jwtOptions.Lifetime)),
                notBefore: DateTime.UtcNow,
                issuedAt: DateTime.UtcNow
                );
            var jwt = new JwtSecurityToken(header, payload);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        public string Extend(List<Claim> claims)
        {
            claims.Add(new Claim("sub", Guid.NewGuid().ToString()));
            var header = new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Key)), SecurityAlgorithms.HmacSha256));
            var payload = new JwtPayload(
                issuer: _jwtOptions.Issuer,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_jwtOptions.Lifetime)),
                notBefore: DateTime.UtcNow,
                issuedAt: DateTime.UtcNow
                );
            var jwt = new JwtSecurityToken(header, payload);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private ClaimsIdentity CreateClaims(HttpRequest request, UserModel member)
        {
            //var nonce = request.GetQueryParam(SolutionConstants.Nonce);
            //var clientId = request.GetHttpContextItem<string>(SolutionConstants.ClientId);
            var claims = new List<Claim>()
            {
                new Claim("usr", JsonConvert.SerializeObject(member)),
                //new Claim("nonce", nonce),
                //new Claim("client", clientId),
                new Claim("sub", Guid.NewGuid().ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, member.Role) //TODO: role based
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
