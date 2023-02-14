using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using DevIO.Api.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JwtSettings _jwtSettings;

    public JwtMiddleware(IOptions<JwtSettings> jwtSettings, RequestDelegate next)
    {
        _next = next;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        if (context.Request.Path == "/api/Login")
        {
            await _next(context);
            return;
        }


        var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        if (!string.IsNullOrEmpty(token))
        {
            try
            {
 
                var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
                
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (securityToken == null)
                {
                    context.Response.StatusCode = 401;
                   
                    return;
                }

                var validateToken = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = _jwtSettings.ValidoEm,
                    ValidIssuer = _jwtSettings.Emissor
                }, out var validatedToken);
                
                context.Items["JwtToken"] = validatedToken;
            }
            catch
            {
                context.Response.StatusCode = 401;
                return;
            }
        }
        else
        {
            context.Response.StatusCode = 401;
            return;
        }

        await _next(context);
    }
}
