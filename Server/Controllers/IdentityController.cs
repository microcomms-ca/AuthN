using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Server.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public IdentityController(IHttpContextAccessor contextAccessor) 
        {
            _contextAccessor = contextAccessor;
        }

        [HttpPost("~/Identity/Token")]
        public JsonResult Token()
        {
            var request = new TokenRequest
            {
                ClientId = _contextAccessor.HttpContext.Request.Form["client_id"],
                ClientSecret = _contextAccessor.HttpContext.Request.Form["client_secret"],
                Code = _contextAccessor.HttpContext.Request.Form["code"],
                GrantType = _contextAccessor.HttpContext.Request.Form["grant_type"],
                RedirectUri = _contextAccessor.HttpContext.Request.Form["redirect_uri"],
                CodeVerifier = _contextAccessor.HttpContext.Request.Form["code_verifier"]
            };


            var iat = (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            var claims = new List<Claim>()
            {
                new Claim("iss","https://localhost:8066"),
                new Claim("sub","nith"),
                new Claim("iat",iat.ToString())
            };

            JwtSecurityToken id_token = new JwtSecurityToken("https://localhost:8066", request.ClientId, claims, expires: DateTime.Now.AddMinutes(60));

            JwtSecurityToken access_token = new JwtSecurityToken("https://localhost:8066", request.ClientId, new List<Claim>(), expires: DateTime.Now.AddMinutes(60));

            var response = new TokenResponse
            {
                id_token = new JwtSecurityTokenHandler().WriteToken(id_token),
                access_token = new JwtSecurityTokenHandler().WriteToken(access_token),
                code = request.Code
            };

            return Json(response);
        }
    }
}
