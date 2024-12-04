using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Application.Utilities;
using Microsoft.IdentityModel.Tokens;

namespace FitnessWorkoutTracker.WebAPI.Middlewares
{
    internal sealed class AuthenticationMiddlware : IMiddleware
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly TokenUtils _tokenUtils;

        public AuthenticationMiddlware(IAuthenticationService authenticationService, TokenUtils tokenUtils)
        {
            _authenticationService = authenticationService;
            _tokenUtils = tokenUtils;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var accessToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                await next(context);
                return;
            }
            var jwtToken = _tokenUtils.ReadJwtToken(accessToken);
            var userId = int.TryParse(jwtToken?.Claims.FirstOrDefault(c => c.Type == "id")?.Value, out int id);
            var refreshToken = await _authenticationService.ValidateRefreshTokenAsync(id, cancellationToken: default);

            if (string.IsNullOrWhiteSpace(refreshToken.tokenResponse?.RefreshToken))
            {
                if (string.IsNullOrWhiteSpace(refreshToken.tokenResponse?.RefreshToken))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Access token expired, and refresh token is invalid.");
                    return;
                }
            }
            try
            {
                var validatedToken = _tokenUtils.ValidateJwtToken(accessToken);

                if (validatedToken == null)
                {
                    throw new SecurityTokenExpiredException("Security token expired!");
                }
            }
            catch (SecurityTokenExpiredException)
            {
                if (string.IsNullOrWhiteSpace(refreshToken.tokenResponse?.RefreshToken))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Access token expired, and refresh token is invalid.");
                    return;
                }
                var newAccesToken = _tokenUtils.GenerateAccessToken(refreshToken.user);
                context.Request.Headers["Authorization"] = $"Bearer {newAccesToken.token}";
            }
            await next(context);
        }
    }
}
