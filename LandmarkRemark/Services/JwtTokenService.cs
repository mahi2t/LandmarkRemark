using LandmarkRemark.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LandmarkRemark.Services
{
    public class JwtTokenService : IJwtTokenService
    {               
        public string GenerateJwtToken(JwtTokenRequest request)
        {          
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(request.JsonWebToken.SecretKey));
            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>{
                    new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Name , request.FirstName),
                new Claim(ClaimTypes.Surname, request.LastName)
            };
            var tokeOptions = new JwtSecurityToken(
                issuer: request.JsonWebToken.Domain,
                audience: request.JsonWebToken.Domain,
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return token;
        }
    }
}
