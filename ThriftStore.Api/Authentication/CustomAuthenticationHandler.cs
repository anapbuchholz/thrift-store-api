﻿using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace ThriftStore.Api.Authentication
{
    public class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private static readonly string BearerPrefix = "Bearer ";
        private readonly FirebaseApp _firebaseApp;

        public CustomAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            FirebaseApp firebaseApp) : base(options, logger, encoder, clock)
        {
            _firebaseApp = firebaseApp;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            IHeaderDictionary headers = Context.Request.Headers;
            if (!headers.ContainsKey("Authorization"))
                return AuthenticateResult.NoResult();

            string bearerToken = headers.Authorization!;

            if (bearerToken == null || !bearerToken.StartsWith(BearerPrefix))
                return AuthenticateResult.Fail("Invalid Authorization token");

            string token = bearerToken[BearerPrefix.Length..];
            try
            {
                FirebaseToken firebaseToken = await FirebaseAuth.GetAuth(_firebaseApp).VerifyIdTokenAsync(token);
                return AuthenticateResult.Success(await GetAuthenticationTicket(firebaseToken, token));
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex);
            }
        }

        private async Task<AuthenticationTicket> GetAuthenticationTicket(FirebaseToken firebaseToken, string bearerToken)
        {
            var claims = await ToClaims(firebaseToken.Claims, bearerToken);
            return new AuthenticationTicket(new ClaimsPrincipal(new List<ClaimsIdentity>
            {
                new ClaimsIdentity(claims, nameof(CustomAuthenticationHandler))
            }), JwtBearerDefaults.AuthenticationScheme);
        }

        private async Task<IEnumerable<Claim>?> ToClaims(IReadOnlyDictionary<string, object> claims, string bearerToken)
        {
            var email = claims["email"].ToString()!;

            return new List<Claim>
            {
                new Claim("id", claims["user_id"].ToString()!),
                new Claim("email", email)
            };
        }
    }
}
